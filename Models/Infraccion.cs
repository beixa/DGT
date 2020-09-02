using System.ComponentModel.DataAnnotations;

namespace DGT.Models
{
    public class Infraccion
    {
        public int Id { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public int DescuentoPuntos { get; set; }
    }
}