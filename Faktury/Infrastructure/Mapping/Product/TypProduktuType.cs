using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Product;
using NHibernate;
using NHibernate.Cfg;

namespace Infrastructure.Mapping
{
    public class TypProduktuType:NHibernate.Type.EnumStringType
    {
        public TypProduktuType()
            :base(typeof(TypProduktu),10)
        { }
    }
}
