using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;
using Domain.Model.Product;


namespace Infrastructure.Mapping
{
    public class WalutaType:NHibernate.Type.EnumStringType
    {
        public WalutaType()
            :base(typeof(Waluta),5)
        { }
    }
}
