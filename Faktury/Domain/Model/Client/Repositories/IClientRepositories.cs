using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iesi.Collections.Generic;

namespace Domain.Model.Client.Repositories
{
    public interface IClientRepositories
    {
        void Insert(Client client);
        void Delete(int Id);
        Client FindID(int Id);
        Client FindNIP(NIP nip);
        Client FindPD(PersonalData pd);
        Client FindREGON(Regon regon);
        System.Collections.Generic.List<Client> FindAll();
        ISet<Discount> GetAllDiscount(int IdClient);
    }
}
