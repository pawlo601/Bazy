using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Client.Repositories
{
    public interface IClientRepositories
    {
        void Insert(Client client);
        void Delete(String Id);
        Client FindID(Guid Id);
        Client FindNIP(NIP nip);
        Client FindREGON(Regon regon);
        List<Client> FindAll();
        List<Discount> GetAllDiscount(String IdClient);
    }
}
