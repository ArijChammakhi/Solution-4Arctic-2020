using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Data.CustomConventions
{
    class DateTime2Convention:Convention
    {
        public DateTime2Convention()
        {
            Properties<DateTime>().Configure(prop => prop.HasColumnType("datetime2"));
        }
    }
}
