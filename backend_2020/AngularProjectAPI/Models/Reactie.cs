using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularProjectAPI.Models
{
    public class Reactie
        
    {
        public int ReactieID { get; set; }
        public string Reactiee { get; set; }
        //relations
        public int ArticleID { get; set; }

        public int UserID { get; set; }
    }
}
