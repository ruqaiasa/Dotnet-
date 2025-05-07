using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen.ApplicationCore.Domain;

namespace Examen.ApplicationCore.Interfaces
{
    public interface IBilanService : IService<Bilan> 
    {
        double CalculerMontantTotal(Bilan bilan);


        public IList<(Bilan Bilan, IList<Analyse> AnalysesAnormales)> ObtenirAnalysesAnormalesParBilan(int codePatient);

        public DateTime ObtenirDateRecuperationBilan(Bilan bilan);

    }

}
