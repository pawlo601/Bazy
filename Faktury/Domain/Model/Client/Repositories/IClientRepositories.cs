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
        Client FindID(String Id);
        public Client FindID(string Id);
        public Client FindNIP(NIP nip);
        public Client FindREGON(REGON regon);
        List<Client> FindAll();
        List<Discount> GetAllDiscount(String IdClient);
    }
}
