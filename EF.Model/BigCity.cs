using System.ComponentModel.DataAnnotations;

namespace EF.Model
{
    public class BigCity
    {
        [Required] [Display(Name = "Id")] public int Id { get; set; }

        [Required] [Display(Name = "IdCountry")] public Country IdCountry { get; set; }

        [Required] [Display(Name = "Name")] public string Name { get; set; }

        [Required] [Display(Name = "Residents")] public int Residents { get; set; }
    }
}