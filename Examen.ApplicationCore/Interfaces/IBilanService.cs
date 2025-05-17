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


        public IEnumerable<IGrouping<Bilan, Analyse>> ObtenirAnalysesAnormalesParBilan(Patient p);

        public DateTime ObtenirDateRecuperationBilan(Bilan bilan);

    }

}
