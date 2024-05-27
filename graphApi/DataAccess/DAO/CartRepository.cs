using System;
using graphApi.DataAccess.Entity;

using Microsoft.EntityFrameworkCore;

namespace graphApi.DataAccess.DAO
{
    public class CartRepository
    {
        private readonly SampleAppDbContext _sampleAppDbContext;

        public CartRepository(SampleAppDbContext sampleAppDbContext)
        {
            _sampleAppDbContext = sampleAppDbContext;
        }

        public List<Cart> GetAllCarts()
        {
            return _sampleAppDbContext
                .Cart.Include(c => c.Lines)
                .ThenInclude(l => l.Cost)
                .Include(c => c.Lines)
                .ThenInclude(l => l.Merchandise)
                .Include(c => c.Lines)
                .ThenInclude(l => l.Merchandise)
                .ThenInclude(m => m.SelectedOptions)
                .Include(c => c.Cost)
                .ToList();
        }

        public Cart? GetCart(string id)
        {
            var guid = new Guid(id);
            return _sampleAppDbContext
                .Cart.Where(c => c.Id == guid)
                .IncludeCartDetails()
                .IncludeCost()
                .IncludeProduct()
                .FirstOrDefault();
        }

        public async Task<Cart> CreateCart(Cart cart)
        {
            await _sampleAppDbContext.Cart.AddAsync(cart);
            await _sampleAppDbContext.SaveChangesAsync();
            return cart;
        }

        public async Task<Cart> CreateCart()
        {
            var newCart = new Cart
            {
                CheckoutUrl = "",
                Cost = new()
                {
                    SubtotalAmount = 0,
                    TotalAmount = 0,
                    TotalTaxAmount = 0
                }
            };
            await _sampleAppDbContext.Cart.AddAsync(newCart);
            await _sampleAppDbContext.SaveChangesAsync();
            return newCart;
        }

        public class LineItem
        {
            public int Id { get; set; }
            public int Quantity { get; set; }
        }

        public class CartLineUpdateInput
        {
            public int Id { get; set; }
            public int MerchandiseId { get; set; }
            public int Quantity { get; set; }
        }

        public async Task<Cart> CreateCart(LineItem[] lines)
        {
            var variant =
                _sampleAppDbContext
                    .ProductVariant.Where(e => e.Id == lines[0].Id)
                    .Include(e => e.Product)
                    .Include(e => e.SelectedOptions)
                    .FirstOrDefault() ?? throw new Exception("Variant not found");
            ;

            var newCartItem = new CartItem()
            {
                Quantity = lines[0].Quantity,
                Merchandise = variant,
                Cost = new() { SubtotalAmount = variant.Price, TotalAmount = variant.Price * lines[0].Quantity }
            };

            var tax = newCartItem.Cost.TotalAmount * 0.3;

            var newCart = new Cart
            {
                CheckoutUrl = "",
                Cost = new()
                {
                    SubtotalAmount = newCartItem.Cost.SubtotalAmount,
                    TotalAmount = newCartItem.Cost.TotalAmount + tax,
                    TotalTaxAmount = tax ?? 0
                },
                Lines = [newCartItem],
                TotalQuantity = lines[0].Quantity
            };
            await _sampleAppDbContext.Cart.AddAsync(newCart);
            await _sampleAppDbContext.SaveChangesAsync();
            return newCart;
        }

        public async Task<Cart> RemoveFromCart(string Id, int[] lineIds)
        {
            var guid = new Guid(Id);

            var cart =
                _sampleAppDbContext
                    .Cart.Where(c => c.Id == guid)
                    .IncludeCartDetails()
                    .IncludeCost()
                    .IncludeProduct()
                    .FirstOrDefault() ?? throw new Exception("Cart not found");

            var cartLineToRemove =
                cart.Lines.Where(l => l.Id == lineIds[0]).FirstOrDefault()
                ?? throw new Exception("Line not found");

            cart.Lines.Remove(cartLineToRemove);
            _sampleAppDbContext.Cart.Update(cart);
            await _sampleAppDbContext.SaveChangesAsync();
            return cart;
        }

        public async Task<Cart> UpdateCart(string CartId, CartLineUpdateInput[] lines)
        {
            var cartId = new Guid(CartId);

            var cart =
                _sampleAppDbContext
                    .Cart.Where(c => c.Id == cartId)
                    .IncludeCartDetails()
                    .IncludeCost()
                    .IncludeProduct()
                    .FirstOrDefault() ?? throw new Exception("Cart not found");

            foreach (var lineUpdate in lines)
            {
                var existingLine = cart.Lines.FirstOrDefault(l => l.Id == lineUpdate.Id) ?? throw new Exception($"Line with ID {lineUpdate.Id} not found in cart");
                existingLine.Quantity = lineUpdate.Quantity;

                existingLine.Cost.TotalAmount =
                    _sampleAppDbContext.ProductVariant
                        .Where(v => v.Id == lineUpdate.MerchandiseId)
                        .Select(v => v.Price)
                        .FirstOrDefault() * lineUpdate.Quantity;
           
            }

            cart.TotalQuantity = cart.Lines.Select(l => l.Quantity).Sum();

            var subtotalCost = cart.Lines.Select(l => l.Cost.TotalAmount ?? 0).Sum();
            var totalQuantity = cart.Lines.Select(l => l.Quantity).Sum();
            var tax = subtotalCost * 0.3;

            cart.TotalQuantity = totalQuantity;

            cart.Cost = new()
            {
                SubtotalAmount = subtotalCost,
                TotalAmount = subtotalCost + tax,
                TotalTaxAmount = tax
            };

            _sampleAppDbContext.Cart.Update(cart);
            await _sampleAppDbContext.SaveChangesAsync();
            return cart;
        }

        public async Task<Cart> AddToCart(string Id, LineItem[] lines)
        {
            var guid = new Guid(Id);

            System.Diagnostics.Debug.WriteLine(lines[0]);
            var cart =
                _sampleAppDbContext
                    .Cart.Where(c => c.Id == guid)
                    .IncludeCartDetails()
                    .IncludeCost()
                    .IncludeProduct()
                    .FirstOrDefault() ?? throw new Exception("Cart not found");

            var variant =
                _sampleAppDbContext
                    .ProductVariant.Where(e => e.Id == lines[0].Id)
                    .Include(e => e.Product)
                    .Include(e => e.SelectedOptions)
                    .FirstOrDefault() ?? throw new Exception("Variant not found");
            ;


            var existingItem = cart.Lines.FirstOrDefault(e => e.Merchandise.Id == lines[0].Id);

            //todo move this inside if
            var newCartItem = new CartItem()
            {
                Quantity = lines[0].Quantity,
                Merchandise = variant,
                Cost = new() { SubtotalAmount = variant.Price, TotalAmount = variant.Price }
            };

            //TODO: add shipping flat rate!?
            if ( existingItem != null )
            {
                existingItem.Quantity += lines[0].Quantity;
                existingItem.Cost = new() { TotalAmount = variant.Price * existingItem.Quantity };
            } else
            {
                cart.Lines.Add(newCartItem);
            }   

            var totalCost = cart.Lines.Select(l => l.Cost.TotalAmount ?? 0).Sum();
            var totalQuantity = cart.Lines.Select(l => l.Quantity).Sum();
            var tax = totalCost * 0.3;

            cart.TotalQuantity = totalQuantity;

            cart.Cost = new()
            {
                SubtotalAmount = totalCost,
                TotalAmount = totalCost + tax,
                TotalTaxAmount = tax
            };

            _sampleAppDbContext.Cart.Update(cart);
            await _sampleAppDbContext.SaveChangesAsync();
            return cart;
        }
    }
}
