using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;
using Domain.Model.Client;

namespace Infrastructure.Mapping
{
    public class TypType:NHibernate.Type.EnumStringType
    {
        public TypType()
            :base(typeof(Typ),15)
        { }
    }
}
