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
    public class MeubleService : Service<Meuble>, IMeubleService
    {
        static IDataBaseFactory Factory = new DataBaseFactory();
        static IUnitOfWork utk = new UnitOfWork(Factory);
        public MeubleService() : base(utk)
        {

        }

        public IEnumerable<Meuble> getMesMeubles(string id)
        {
            return GetMany(f => f.UserID.Contains(id));
        }
        public IEnumerable<Meuble> getMeubles(string id)
        {
            return GetMany(f => f.Titre.Equals(id));
        }

        public Meuble getMeubleById(int id)
        {
            return Get(f => f.IdMeuble.Equals(id));
        }

        public Meuble getMeubleByName(string name)
        {
            return Get(f => f.Titre.Equals(name));
        }
    }
}