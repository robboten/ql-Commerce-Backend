using System.Drawing;
using System.Text.RegularExpressions;
using Bogus;
using graphApi.DataAccess.Entity;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace graphApi.DataAccess
{
    public partial class Seed
    {
        private static List<Product> products = [];
        private static List<Page> pages = [];
        private static List<Collection> productCollections = new List<Collection>();
        private static List<Menu> menuCollections = new List<Menu>();

        public static async Task InitAsync(SampleAppDbContext ctx)
        {
            //if any product exists don't seed again
           // if (await ctx.Product.AnyAsync()) return;
            //products = GenerateProducts(400);
            pages = GeneratePages(4);
            productCollections = GenerateCollections();
            menuCollections = GenerateMenus();

            //ctx.AddRange(products);
            ctx.AddRange(pages);
            ctx.AddRange(productCollections);
            ctx.AddRange(menuCollections);
            await ctx.SaveChangesAsync();
        }

        private static readonly string[] colors =
        [
            "Red",
            "Orange",
            "Yellow",
            "Green",
            "Blue",
            "Violet"
        ];

        private static readonly string[] sizes = ["S", "M", "L", "XL", "XS"];

        private static List<Menu> GenerateMenus()
        {
            var menus = new List<Menu>();
            var footerMenu = new Menu()
            {
                Handle = "next-js-frontend-header-menu",
                Items =
                [
                    new() { Title = "All", Url = "/collections/" },
                    new()
                    {
                        Title = "Clothes",
                        Url = "/collections/clothes"
                    },
                    new()
                    {
                        Title = "Toys",
                        Url = "/collections/toys"
                    },
                    new()
                    {
                        Title = "Posters",
                        Url = "/collections/posters"
                    }
                    ,
                    new()
                    {
                        Title = "Electronics",
                        Url = "/collections/electronics"
                    }

                ]
            };

            var topMenu = new Menu()
            {
                Handle = "next-js-frontend-footer-menu",
                Items =
                [
                    new() { Title = "About us", Url = "/pages/about/" },
                    new() { Title = "Terms & Conditions", Url = "/pages/terms_tonditions" }
                ]
            };

            menus.Add(topMenu);
            menus.Add(footerMenu);
            return menus;
        }

        private static List<Product> GenerateProducts(int amount, string keyword)
        {
            var faker = new Faker<Product>()
                .Rules(
                    (f, o) =>
                    {
                        o.Title =
                            $"{f.Commerce.Color()} {f.Commerce.ProductAdjective().ToLowerInvariant()} {f.Commerce.Product().ToLowerInvariant()}";
                        o.Description = f.Lorem.Paragraphs();
                        o.AvailableForSale = true;
                        o.Tags = [];
                        o.Seo = new() { Title = f.Lorem.Word(), Description = f.Lorem.Sentence(), };
                        //o.Handle = Regex.Replace(f.Commerce.Product().ToLowerInvariant(), @"\s", "_");

                        o.Price = Math.Round(f.Random.Double() * 100, 0);
                        o.FeaturedImage = new()
                        {
                            Url = f.Image.LoremFlickrUrl(640, 480, keyword),
                            AltText = "Featured Image Alt Text",
                            Width = 640,
                            Height = 480
                        };
                        o.Images =
                        [
                            new()
                            {
                                Url = f.Image.LoremFlickrUrl(640, 480, keyword),
                                AltText = "Image Alt Text",
                                Width = 640,
                                Height = 480
                            },
                            new()
                            {
                                Url = f.Image.LoremFlickrUrl(640, 480, keyword),
                                AltText = "Image Alt Text",
                                Width = 640,
                                Height = 480
                            },
                            new()
                            {
                                Url = f.Image.LoremFlickrUrl(640, 480, keyword),
                                AltText = "Image Alt Text",
                                Width = 640,
                                Height = 480
                            }
                        ];
                        o.Variants =
                        [
                            new()
                            {
                                Title =
                                    f.Random.ArrayElement(colors)
                                    + f.Random.ArrayElement(sizes)
                                    + f.Random.Int().ToString(),
                                AvailableForSale = true,
                                Price = Math.Round(f.Random.Double() * 1000, 0),
                                SelectedOptions =
                                [
                                    new() { Name = "Color", Value = f.Random.ArrayElement(colors) },
                                    new() { Name = "Size", Value = f.Random.ArrayElement(sizes) },
                                ]
                            },
                            new()
                            {
                                Title =
                                    f.Random.ArrayElement(colors)
                                    + f.Random.ArrayElement(sizes)
                                    + f.Random.Int().ToString(),
                                AvailableForSale = true,
                                Price = Math.Round(f.Random.Double() * 1000, 0),
                                SelectedOptions =
                                [
                                    new() { Name = "Color", Value = f.Random.ArrayElement(colors) },
                                    new() { Name = "Size", Value = f.Random.ArrayElement(sizes) },
                                ]
                            },
                            new()
                            {
                                Title =
                                    f.Random.ArrayElement(colors)
                                    + f.Random.ArrayElement(sizes)
                                    + f.Random.Int().ToString(),
                                AvailableForSale = true,
                                Price = Math.Round(f.Random.Double() * 1000, 0),
                                SelectedOptions =
                                [
                                    new() { Name = "Color", Value = f.Random.ArrayElement(colors) },
                                    new() { Name = "Size", Value = f.Random.ArrayElement(sizes) },
                                ]
                            },
                            new()
                            {
                                Title =
                                    f.Random.ArrayElement(colors)
                                    + f.Random.ArrayElement(sizes)
                                    + f.Random.Int().ToString(),
                                AvailableForSale = true,
                                Price = Math.Round(f.Random.Double() * 1000, 0),
                                SelectedOptions =
                                [
                                    new() { Name = "Color", Value = f.Random.ArrayElement(colors) },
                                    new() { Name = "Size", Value = f.Random.ArrayElement(sizes) },
                                ]
                            },
                            new()
                            {
                                Title =
                                    f.Random.ArrayElement(colors)
                                    + f.Random.ArrayElement(sizes)
                                    + f.Random.Int().ToString(),
                                AvailableForSale = true,
                                Price = Math.Round(f.Random.Double() * 1000, 0),
                                SelectedOptions =
                                [
                                    new() { Name = "Color", Value = f.Random.ArrayElement(colors) },
                                    new() { Name = "Size", Value = f.Random.ArrayElement(sizes) },
                                ]
                            }
                        ];
                        o.Options =
                        [
                            new() { Name = "Color", Values = colors },
                            new() { Name = "Size", Values = sizes }
                        ];
                        o.PriceRange = new PriceRange(
                            o.Variants.Min(e=>e.Price),
                            o.Variants.Max(e => e.Price)
                        );
                    }
                )
                .RuleFor(
                    o => o.Handle,
                    (f, u) => HandleRegex().Replace(u.Title.ToLowerInvariant(), "_")
                );
            var products = faker.Generate(amount);
            return products;
        }

        private static List<Page> GeneratePages(int amount)
        {
            var faker = new Faker<Page>().Rules(
                (f, o) =>
                {
                    o.Title = string.Join(" ", f.Lorem.Words());
                    o.Handle = f.Lorem.Slug();
                    o.Body = f.Lorem.Paragraphs(3);
                    o.BodySummary = f.Lorem.Paragraphs(1);
                    o.Seo = new()
                    {
                        Title = string.Join(" ", f.Lorem.Words()),
                        Description = f.Lorem.Paragraphs(1)
                    };
                }
            );
            var pages = faker.Generate(amount);
            var aboutPage = new Faker<Page>()
                .Rules(
                    (f, o) =>
                    {
                        o.Title = "About us";
                        o.Handle = "about";
                        o.Body = f.Lorem.Paragraphs(3);
                        o.BodySummary = f.Lorem.Paragraphs(1);
                        o.Seo = new() { Title = "About us", Description = f.Lorem.Paragraphs(1) };
                    }
                )
                .Generate();
            var termsPage = new Faker<Page>()
                .Rules(
                    (f, o) =>
                    {
                        o.Title = "Terms & Conditions";
                        o.Handle = "terms_tonditions";
                        o.Body = f.Lorem.Paragraphs(3);
                        o.BodySummary = f.Lorem.Paragraphs(1);
                        o.Seo = new()
                        {
                            Title = "Terms & Conditions",
                            Description = f.Lorem.Paragraphs(1)
                        };
                    }
                )
                .Generate();

            pages.Add(aboutPage);
            pages.Add(termsPage);
            return pages;
        }

        private static List<Collection> GenerateCollections()
        {
            var products = GenerateProducts(50, "electronics");
            var collections = new List<Collection>();
            var electronicsCollection = new Faker<Collection>()
                .Rules(
                    (f, o) =>
                    {
                        o.Title = "Electronics";
                        o.Handle = "electronics";
                        o.Description = f.Lorem.Paragraphs(1);
                        o.Products = products.ToList();
                    }
                )
                .Generate();

            products = GenerateProducts(50, "toys");
            var toysCollection = new Faker<Collection>()
                .Rules(
                    (f, o) =>
                    {
                        o.Title = "Toys";
                        o.Handle = "toys";
                        o.Description = f.Lorem.Paragraphs(2);
                        o.Products = products.ToList();
                    }
                )
                .Generate();

            products = GenerateProducts(20, "posters");
            var postersCollection = new Faker<Collection>()
                .Rules(
                    (f, o) =>
                    {
                        o.Title = "Posters";
                        o.Handle = "posters";
                        o.Description = f.Lorem.Paragraphs(1);
                        o.Products = products.ToList();
                    }
                )
                .Generate();

            products = GenerateProducts(100, "clothes");
            var clothesCollection = new Faker<Collection>()
                .Rules(
                    (f, o) =>
                    {
                        o.Title = "Clothes";
                        o.Handle = "clothes";
                        o.Description = f.Lorem.Paragraphs(1);
                        o.Products = products.ToList();
                    }
                )
                .Generate();

            var frontCollection = new Faker<Collection>()
                .Rules(
                    (f, o) =>
                    {
                        o.Title = "Carousel Home";
                        o.Handle = "hidden-homepage-carousel";
                        o.Description = f.Lorem.Paragraphs(1);
                        o.Products = f.Random.ArrayElements<Product>([.. clothesCollection.Products], 10).ToList();
                    }
                )
                .Generate();

            var featuredCollection = new Faker<Collection>()
                .Rules(
                    (f, o) =>
                    {
                        o.Title = "Featured Items";
                        o.Handle = "hidden-homepage-featured-items";
                        o.Description = f.Lorem.Paragraphs();
                        o.Products = f.Random.ArrayElements<Product>([.. toysCollection.Products], 10).ToList();
                    }
                )
                .Generate();

            collections.Add(featuredCollection);
            collections.Add(electronicsCollection);
            collections.Add(clothesCollection);
            collections.Add(frontCollection);
            collections.Add(postersCollection);
            collections.Add(toysCollection);

            return collections;
        }

        [GeneratedRegex(@"\s")]
        private static partial Regex HandleRegex();
    }
}
