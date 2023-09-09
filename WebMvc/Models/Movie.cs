using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMvc.Models
{
    public class Movie
    {
        public int MovieID { get; set; }

        [Required(ErrorMessage = "Ingrese el título de la pelicula")]
        [Display(Name ="Título")]
        public string Title { get; set; }

        [Required(ErrorMessage ="Ingrese la fecha de lanzamiento")]
        [DataType(DataType.Date)]
        [Display(Name ="Fecha de lanzamiento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString ="{0:yyyy-MM-dd}")]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage ="Ingrese el género")]
        [Display(Name ="Género")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Ingrese el precio")]
        [Range(1,100)]
        [DataType(DataType.Currency)]
        [Display(Name ="Precio")]
        public decimal Price { get; set; }

        [StringLength(5)]
        [Required(ErrorMessage ="Ingrese el rating")]
        public string Rating { get; set; }
    }
}