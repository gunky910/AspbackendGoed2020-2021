using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularProjectAPI.Models
{
    public class Like
    {
        public int LikeID { get; set; }
        public bool Likee { get; set; }
        //relations
        public int ArticleID { get; set; }

        public int UserID { get; set; }
    }
}
