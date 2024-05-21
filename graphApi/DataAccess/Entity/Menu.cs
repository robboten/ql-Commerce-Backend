using System.ComponentModel.DataAnnotations;

namespace graphApi.DataAccess.Entity
{
    public class Menu
    {
        public int Id { get; set; }
        public string Handle { get; set; } = string.Empty;

        public ICollection<MenuItem> Items { get; set; } = [];
    }

    public class MenuItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}
