using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    
    public class Studio:Annonce
    {
       
        public Studio()
        {

        }
   
        public TypeStudio typeStudio { get; set; }
    }
}
