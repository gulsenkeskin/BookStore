using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreWebApi.Entities
{
    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isActive { get; set; }
    }
}