using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Patient
    {
        [Key]
        [StringLength(5 ,ErrorMessage=("erreur, 5 caracteres !!"))]
        public int CodePatient { get; set; }
        public string EmailPatient  { get; set; }
        [Display(Name ="Informations Supplementaires")]
        public string Informations { get; set; }
        public string NomComplet { get; set; }
        public string NumeroTel { get; set; }
        public IList<Bilan> Bilans { get; set; }
    }
}
