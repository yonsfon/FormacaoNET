using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NobelMVC.Models
{
    public partial class PremioNobelMetada
    {
        public int PremioNobelId { get; set; }

        [Display(Name = "Year")]
        public int Ano { get; set; }

        public int CategoriaId { get; set; }

        [Display(Name = "Title")]
        public string Titulo { get; set; }

        [Display(Name = "Motivation")]
        [DataType(DataType.MultilineText)]
        public string Motivacao { get; set; }

    }

    public partial class CategoriaMetada
    {
        public int CategoriaId { get; set; }

        [Display(Name = "Category")]
        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage = "The Category must have [5-100] chars length")]
        public string Nome { get; set; }

    }
}