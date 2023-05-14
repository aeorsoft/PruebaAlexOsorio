using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto.Core.Entities
{
   public  class PeopleApi
    {
        public int count { get; set; }

        public string next { get; set; }

        public string previous { get; set; }

        public dynamic results { get; set; }
    }
}
