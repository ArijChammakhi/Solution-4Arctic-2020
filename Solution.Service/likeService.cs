﻿using Service.Pattern;
using Solution.Data.Infrastructure;
using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Service
{
    public class likeService :Service<Interesse>, ILikeService
    {
        static IDataBaseFactory Factory = new DataBaseFactory();
    static IUnitOfWork utk = new UnitOfWork(Factory);
    public likeService() : base(utk)
    {

    }

}
}
