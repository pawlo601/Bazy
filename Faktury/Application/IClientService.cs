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
        List<Discount> GetAllDiscount(PersonalData p);
        Phone GetContact(PersonalData p);
        Mail GetContact(PersonalData p);
        void CreateDoc(PersonalData p);
    }
}
