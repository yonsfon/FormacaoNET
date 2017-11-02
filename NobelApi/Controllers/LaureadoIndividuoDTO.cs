using NobelApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NobelApi.Controllers
{
    public class LaureadoIndividuoDTO
    {
        public int LaureadoId { get; set; }
        /// <summary>
        /// Nome do Laureado
        /// </summary>
        public string Nome { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public System.DateTime DataNascimento { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public Nullable<System.DateTime> DataMorte { get; set; }
        public string Sexo { get; set; }


    }
}