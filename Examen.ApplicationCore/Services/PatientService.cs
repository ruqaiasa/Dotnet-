using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;

namespace Examen.ApplicationCore.Services
{
    public class PatientService : Service<Patient>, IPatientService
    {
        public PatientService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public double CalculerMontantTotal(Bilan bilan)
        {
            double montantTotal = bilan.Analyses.Sum(a => a.PrixResultat);

           if( GetMany().SelectMany(p => p.Bilans).Count()>5)

                    return montantTotal * 0.9;
            else return montantTotal;





        }
    }
}
