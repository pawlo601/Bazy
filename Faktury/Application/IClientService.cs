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
        List<Client> GetAll();
        List<Discount> GetAllDiscount(PersonalData p);
        Phone GetContactP(PersonalData p);
        Mail GetContactM(PersonalData p);
        void CreateDoc(PersonalData p);
    }
}
