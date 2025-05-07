using System;
using System.Collections.Generic;
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

        public double CalculerMontantTotal(Bilan bilan)
        {
            double montantTotal = bilan.Analyses.Sum(a => a.PrixResultat);

            int nombrePrelevements = GetMany(b => b.CodePatient == bilan.CodePatient).Count();

            if (nombrePrelevements > 5)
            {
                montantTotal *= 0.9;
            }

            return montantTotal;
        }
        
            public IList<(Bilan Bilan, IList<Analyse> AnalysesAnormales)> ObtenirAnalysesAnormalesParBilan(int codePatient)
        {
            var bilans = GetMany(b => b.CodePatient == codePatient && b.DatePrelevement.Year == DateTime.Now.Year).ToList();

            var result = new List<(Bilan, IList<Analyse>)>();

            foreach (var bilan in bilans)
            {
                var analysesAnormales = bilan.Analyses
                    .Where(a => a.ValeurAnalyse != null &&
                                (double.Parse(a.ValeurAnalyse) > a.ValeurMaxNormale || double.Parse(a.ValeurAnalyse) < a.ValeurMinNormale))
                    .ToList();

                if (analysesAnormales.Any())
                {
                    result.Add((bilan, analysesAnormales));
                }
            }

            return result;
        }
        public DateTime ObtenirDateRecuperationBilan(Bilan bilan)
        {
           
            var dateRecuperation = bilan.Analyses
                .Select(a => bilan.DatePrelevement.AddDays(a.DureeResultat))
                .Max();

            return dateRecuperation;
        }
    }


    
}
