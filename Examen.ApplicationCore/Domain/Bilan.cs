using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Bilan
    {
        public DateTime DatePrelevement { get; set; }
        public string EmailMedecin { get; set; }
        public bool Paye { get; set; }
        public Infrimier Infirmier { get; set; }
        public Patient Patient { get; set; }

        public int CodeInfirmier { get; set; }
        public int CodePatient { get; set; }
        public IList<Analyse> Analyses{ get; set; }





    }
}
