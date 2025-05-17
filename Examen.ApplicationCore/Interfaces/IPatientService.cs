using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen.ApplicationCore.Domain;

namespace Examen.ApplicationCore.Interfaces
{
    public interface IPatientService : IService<Patient>
    {
       public double CalculerMontantTotal(Bilan bilan);

    }
}
