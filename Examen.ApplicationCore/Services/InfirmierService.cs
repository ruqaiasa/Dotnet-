using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;

namespace Examen.ApplicationCore.Services
{
    public class InfirmierService : Service<Infrimier>, IInfirmierService
    {
        public InfirmierService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }


        public double CalculerPourcentageInfirmiersParSpecialite(Specialite specialite)

        {
            var infirmiers = GetMany().ToList();
            int nbr = infirmiers.Count(i=>i.Specialite == specialite);
             double pourcentage = nbr/infirmiers.Count * 100;
            return pourcentage;

        }
    }
}
