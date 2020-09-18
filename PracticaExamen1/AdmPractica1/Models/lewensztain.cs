using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdmPractica1.Models
{
    public enum placeType
    {
        toby,
        burguerking,
        casadelcamba,
        kfc,
        cinecenter,
        ventura
    }
    public class lewensztain
    {
        [Key]
        public int lewensztainID { get; set; }

        [Required]
        [Display(Name = "Nombre Completo")]
        [StringLength(24, MinimumLength = 2)]
        public string Friendoflewensztain { get; set; }

        [Required]
        public placeType place { get; set; }

        [EmailAddress]
        public string email { get; set; }

        [Display(Name = "Cumpleaños")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        [DataType(DataType.Date)]
        public DateTime birthdate { get; set; }


    }
}