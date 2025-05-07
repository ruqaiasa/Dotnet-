using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Infrimier
    {
        [Key]
        public int InfirmierId { get; set; }
        public string  NomComplet { get; set; }
        public Specialite Specialite { get; set; }
        public Laboratoire Laboratoire { get; set; }

        //public IList<Patient> Patients{ get; set; }
        public IList<Bilan> Bilans{ get; set; }
    }
}
