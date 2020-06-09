using Service.Pattern;
using Solution.Data.Infrastructure;
using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Service
{
    public class AbonnementService : Service<Abonnement>, IAbonnementService
    {
        static IDataBaseFactory Factory = new DataBaseFactory();
        static IUnitOfWork utk = new UnitOfWork(Factory);
        public AbonnementService() : base(utk)
        {

        }

        public Abonnement getAbonnementById(int id)
        {
            return Get(f => f.IdAbonnement.Equals(id));
        }

        public IEnumerable<Abonnement> getMesAbonnements(string uid)
        {
            return GetMany(f => f.UserID.Contains(uid));
        }

        public Abonnement confirmAbonnement(int id)
        {
            Abonnement ab = getAbonnementById(id);
            ab.State = "Confirmé";
            return ab;
        }
    }
}
