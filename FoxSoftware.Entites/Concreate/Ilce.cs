using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxSoftware.Entites.Concreate
{
    public class Ilce : BaseTanimClass
    {
        public int IlId { get; set; }
        public virtual Il Il { get; set; }
    }
}
