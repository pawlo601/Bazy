using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Client;
using Iesi.Collections.Generic;

namespace Application
{
    public interface IClientService
    {
        System.Collections.Generic.List<Client> GetAll();
        ISet<Discount> GetAllDiscount(PersonalData p);
        Phone GetContactP(PersonalData p);
        Mail GetContactM(PersonalData p);
        void CreateDoc(PersonalData p);
    }
}
