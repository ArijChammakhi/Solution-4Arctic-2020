using Service.Pattern;
using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Service
{
   public  interface IAnnonceService : IService<Annonce>
    {
        Annonce getAnnonceByName(string name);
        Annonce getAnnonceById(int id);
        IEnumerable<Annonce> getAnnoncesByName(string name);

        string GetTitleAnnonceById(string id);
        IEnumerable<Annonce> getMaisonAvendre();
        IEnumerable<Annonce> getMesAnnonces(string id);
        IEnumerable<Annonce> getAppartementAvendre();
        IEnumerable<Annonce> getStudioAvendre();
        IEnumerable<Annonce> getTerrainAvendre();
        IEnumerable<Annonce> getMaisonALouer();

        IEnumerable<Annonce> getAppartementALouer();
        IEnumerable<Annonce> getStudioALouer();
    }
    
    
}
