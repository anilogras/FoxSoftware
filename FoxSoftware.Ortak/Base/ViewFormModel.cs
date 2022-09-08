using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxSoftware.Ortak.Base
{
    public class ViewFormModel<T>
        where T : BaseClass, new()
    {

        public ViewFormModel()
        {
            Model = new T();
        }
        public T Model { get; set; }
        public DbContext Context { get; set; }
        public T CreateModel()
        {
            if (Model.Id == 0)
            {
                Model = this.Context.Set<T>().Add(new T { });
            }

            return Model;
        }
    }
}
