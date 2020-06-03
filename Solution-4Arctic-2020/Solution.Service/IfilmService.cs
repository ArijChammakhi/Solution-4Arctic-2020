using Service.Pattern;
using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Service
{
     public interface IfilmService:IService<Film>
    {
        Film GetFilmByName(string name);
        string GetTitleFilmById(int id);
    }
}
