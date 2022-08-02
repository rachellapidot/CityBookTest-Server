using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Weather.App.Domain.Model
{
    [Table("FavoriteCities", Schema =" dbo")]
    public class FavoriteCities
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int CityKey { get; set; }
        public string CityName { get; set; }

    }
}
