using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;

namespace Examen.ApplicationCore.Services
{
    public class BilanService: Service<Bilan>, IBilanService
    {
        public BilanService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }



        public IEnumerable<IGrouping<Bilan, Analyse>> ObtenirAnalysesAnormalesParBilan(Patient p)
        {
            // Récupérer les bilans de cette année
            var bilans = p.Bilans
                .Where(b => b.DatePrelevement.Year == DateTime.Now.Year)
                .ToList();

            // Aplatir toutes les analyses avec leur bilan associé
            var analysesAvecBilan = bilans
                .SelectMany(
                    b => b.Analyses,
                    (bilan, analyse) => new { Bilan = bilan, Analyse = analyse }
                );

            // Filtrer les analyses anormales
            var analysesAnormales = analysesAvecBilan
                .Where(x =>
                    double.TryParse(x.Analyse.ValeurAnalyse, out double valeur)
                    && (valeur < x.Analyse.ValeurMinNormale || valeur > x.Analyse.ValeurMaxNormale)
                );

            // Regrouper les résultats par bilan
            var resultats = analysesAnormales
                .GroupBy(x => x.Bilan, x => x.Analyse);

            return resultats;
        }
        public DateTime ObtenirDateRecuperationBilan(Bilan bilan)
        {
            var max = 0;

            foreach (var analyse in bilan.Analyses)
            {
                if (analyse.DureeResultat > max)
                {
                    max = analyse.DureeResultat;
                }
            }

              var  dateRecuperation= bilan.DatePrelevement.AddDays(max);



            return dateRecuperation;
        }
    }


    
}
