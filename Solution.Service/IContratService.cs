using Service.Pattern;
using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Service
{
    public interface IContratService : IService<Contrat>
    {
        Contrat GetContrat(string IDClient, int IDAnnonce);
        Contrat ModContrat(string IDClient, int IDAnnonce, Contrat contrat);
        bool RemoveContrat(string IDClient, int IDAnnonce);

    }
}
