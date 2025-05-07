using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen.ApplicationCore.Domain;

namespace Examen.ApplicationCore.Interfaces
{
    public interface IInfirmierService : IService<Infrimier>
    {
        double CalculerPourcentageInfirmiersParSpecialite(Specialite specialite);
    }
}
