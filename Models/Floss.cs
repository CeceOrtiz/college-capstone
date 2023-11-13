using System.ComponentModel.DataAnnotations;

namespace D424.Models
#nullable disable
{
    public class Floss
    {
        [Key]
        public int FlossID { get; set; }
        public string NumOrName { get; }
        public string Brand { get; }
        public string Color { get; }
    }
}