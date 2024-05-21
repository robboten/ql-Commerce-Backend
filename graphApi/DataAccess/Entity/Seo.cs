using System.ComponentModel.DataAnnotations;

namespace graphApi.DataAccess.Entity
{
    public class Seo
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
