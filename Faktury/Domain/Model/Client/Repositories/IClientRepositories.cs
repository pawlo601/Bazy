using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Client.Repositories
{
    interface IClientRepositories
    {
        void Insert(Client client);
        void Delete(String Id);
        Client Find(String Id);
        List<Client> FindAll();
    }
}
