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
    public class FilmService : Service<Film>, IfilmService

    {
        static IDataBaseFactory Factory = new DataBaseFactory();
        static IUnitOfWork utk = new UnitOfWork(Factory);
        public FilmService() : base(utk)
        {

        }

        public Film GetFilmByName(string name)
        {
            return Get(f => f.Title.Equals(name));
        }

        public string GetTitleFilmById(int id)
        {
            return GetById(id).Title;
        }
    }
}
