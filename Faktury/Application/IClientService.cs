using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Client;

namespace Application
{
    public interface IClientService
    {
        List<Discount> GetAllDiscount(Client p);
        IdentificationNumber GetContact(Client p);
        void CreateDoc(Client p);
    }
}
