using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxSoftware.Entites.Concreate
{
    public class BaseClass
    {
        [Key]
        public int Id { get; set; }

        public bool Silinmis { get; set; }

    }
}
