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
   public  class AnnonceService : Service<Annonce>, IAnnonceService
    {
        static IDataBaseFactory Factory = new DataBaseFactory();
        static IUnitOfWork utk = new UnitOfWork(Factory);
        public AnnonceService() : base(utk)
        {

        }
        public Annonce getAnnonceByName(string name)
        {
            return Get(f => f.Titre.Equals(name));
        }
        public Annonce getAnnonceById(int id)
        {
            return Get(f => f.IdAnnonce.Equals(id));
        }

        public IEnumerable<Annonce> getAnnoncesByName(string name)
        {
            return GetMany(f => f.Titre.Contains(name));
        }
        public IEnumerable<Annonce> getMesAnnonces(string id)
        {
            return GetMany(f => f.UserID.Contains(id));
        }

        public string GetTitleAnnonceById(int id)
        {
            return GetById(id).Titre;
        }
        public IEnumerable<Annonce> getMaisonAvendre()
        {
            return GetMany(f => f.type!=0 && f.Type_Dannonce.Equals("Maison"));
        }
        public IEnumerable<Annonce> getAppartementAvendre()
        {
            return GetMany(f => f.type!=0 && f.Type_Dannonce.Equals("Appartement"));
        }
        public IEnumerable<Annonce> getStudioAvendre()
        {
            return GetMany(f => f.type != 0 && f.Type_Dannonce.Equals("Studio"));
        }
        public IEnumerable<Annonce> getTerrainAvendre()
        {
            return GetMany(f => f.type != 0 && f.Type_Dannonce.Equals("Terrain"));
        }
        public IEnumerable<Annonce> getMaisonALouer()
        {
            return GetMany(f => f.type == 0 && f.Type_Dannonce.Equals("Maison"));
        }
        public IEnumerable<Annonce> getAppartementALouer()
        {
            return GetMany(f => f.type == 0 && f.Type_Dannonce.Equals("Appartement"));
        }
        public IEnumerable<Annonce> getStudioALouer()
        {
            return GetMany(f => f.type == 0 && f.Type_Dannonce.Equals("Studio"));
        }

        public string GetTitleAnnonceById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Annonce> getMesAnnonces(int id)
        {
            throw new NotImplementedException();
        }
    }
   
}
