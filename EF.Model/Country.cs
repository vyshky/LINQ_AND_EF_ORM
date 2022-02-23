using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EF.Model
{
    public record Country
    {
        [Required] [Display(Name = "Id")] public int Id { get; set; }
        [Required] [Display(Name = "Name")] public string Name { get; set; }
        [Required] [Display(Name = "Residents")] public int Residents { get; set; }
        [Required] [Display(Name = "Area")] public double Area { get; set; }
        [Required] [Display(Name = "BigCity")] public ICollection<BigCity> BigCity { get; set; }
    }
}