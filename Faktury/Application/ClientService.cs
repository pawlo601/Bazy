using Domain.Model.Client;
using Domain.Model.Client.Repositories;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Iesi.Collections.Generic;
using Infrastructure.Repositories;

namespace Application
{
    public class ClientService : IClientService
    {
        private IClientRepositories repo;
       /* public ClientService()
        {
            repo = new ClientIM();
        }*/
        public ClientService(IClientRepositories re)
        {
            repo = re;
        }
        public System.Collections.Generic.List<Client> GetAll()
        {
            return repo.FindAll();
        }
        public ISet<Discount> GetAllDiscount(PersonalData p)
        {
            Client a = repo.FindPD(p);
            return a.ListOfDiscount;
        }
        public Mail GetContactM(PersonalData p)
        {
            Client a = repo.FindPD(p);
            return a.MailToClient;
        }
        public Phone GetContactP(PersonalData p)
        {
            Client a = repo.FindPD(p);
            return a.NumberOfPhone;
        }
        public void CreateDoc(PersonalData p)
        {
            Client a = repo.FindPD(p);
            string path = @"c:\bazy\";
            path += a.IdClient.ToString() + ".txt";
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(a.ToString());
                }
            }
        }
    }
}
