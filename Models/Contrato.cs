using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Evaluacion_Tecnica.Models
{
    public class Contrato
    {
        public Contrato(string tipoContrato, bool estado)
        {
            this.TipoContrato = tipoContrato;
            this.Estado = estado;
        }

        [Required]
        [MinLength(1), MaxLength(15)]
        public string TipoContrato { get; set; }

        public bool Estado { get; set; }
    }
}