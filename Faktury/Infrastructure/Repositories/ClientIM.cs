using Domain.Model.Client;
using Domain.Model.Client.Repositories;
using System;
using Iesi.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ClientIM 
    {
        private System.Collections.Generic.List<Client> clients = new System.Collections.Generic.List<Client>();
        public ClientIM()
        {
            PersonalData per1 = new PersonalData("A", "B");
            Address ad1 = new Address("S1", "12", "Wrocław", "12-456", "Poland");
            Regon a1 = new Regon("2346789");
            NIP a2 = new NIP("123123");
            clients.Add(new Client(per1, ad1, a1, a2));
        }
        public void Insert(Client client)
        {
            clients.Add(client);
        }
        public void Delete(int Id)
        {
            foreach(var a in clients)
            {
                if(Id==a.IdClient)
                {
                    clients.Remove(a);
                }
            }
        }
        public Client FindID(int Id)
        {
            foreach (var a in clients)
            {
                if (Id == a.IdClient)
                {
                    return a;
                }
            }
            return null;
        }
        public Client FindNIP(NIP nip)
        {
            foreach (var a in clients)
            {
                if (nip == a.Nip)
                {
                    return a;
                }
            }
            return null;
        }
        public Client FindPD(PersonalData pd)
        {
            foreach (var a in clients)
            {
                if (pd == a.Data)
                {
                    return a;
                }
            }
            return null;
        }
        public Client FindREGON(Regon regon)
        {
            foreach (var a in clients)
            {
                if (regon == a.Regon)
                {
                    return a;
                }
            }
            return null;
        }
        public System.Collections.Generic.List<Client> FindAll()
        {
            return clients;
        }
        public ISet<Discount> GetAllDiscount(int IdClient)
        {
            return this.FindID(IdClient).ListOfDiscount;
        }
    }
}
