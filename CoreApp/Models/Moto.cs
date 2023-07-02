using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CoreApp.Models
{
    public class Moto
    {
        public int MotoId { get; set; }

        [Display(Name = "Make and Model")]
        public string MakeModel { get; set; }
        public string Type { get; set; }
        public string CC { get; set; }




    }
}
