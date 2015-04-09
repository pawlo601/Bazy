using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Client;
using Domain.Model.Client.Repositories;
using Infrastructure.Repositories;
using System.IO;

namespace Application
{
    public class ClientService:IClientService
    {
        private IClientRepositories repo;
        public ClientService()
        {
            repo = new ClientIM();
        }
        public ClientService(IClientRepositories re)
        {
            repo = re;
        }
        List<Discount> GetAllDiscount(PersonalData p)
        {
            Client a = repo.FindPD(p);
            return a.ListOfDiscount;
        }
        Mail GetContact(PersonalData p)
        {
            Client a = repo.FindPD(p);
            return a.MailToClient;
        }
        Phone GetContact(PersonalData p)
        {
            Client a = repo.FindPD(p);
            return a.NumberOfPhone;
        }
        void CreateDoc(PersonalData p)
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
