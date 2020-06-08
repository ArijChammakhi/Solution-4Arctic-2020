using Service.Pattern;
using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Service
{
     public interface IMeubleService : IService<Meuble>
    {
        Meuble getMeubleById(int id);
        IEnumerable<Meuble> getMesMeubles(string id);
        Meuble getMeubleByName(string name);
        IEnumerable<Meuble> getMeubles(string id);
    }
}
