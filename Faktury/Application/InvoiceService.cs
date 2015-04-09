using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Invoice;
using Domain.Model.Invoice.Repositories;
using Infrastructure.Repositories;
using System.IO;

namespace Application
{
    public class InvoiceService:IInvoiceServices
    {
        private IInvoiceRepositories repo;
        public InvoiceService()
        {
            repo = new InvoiceIM();
        }
        public InvoiceService(IInvoiceRepositories re)
        {
            repo = re;
        }
        public void CreateInvoice(string id)
        {
            Invoice a = repo.Find(id);
            string path = @"c:\bazy\";
            path += a.Title + ".txt";
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(a.ToString());
                }
            }
        }
        public void SendToMailInvoice(string id)
        {
            throw new NotImplementedException();
        }
        public List<Invoice> GetAllPerClient(Domain.Model.Client.PersonalData pd)
        {
            return repo.FindAllPerContractor(pd);
        }
        public List<Invoice> GetAllPerDate(DateTime p)
        {
            return repo.FindAllPerData(p);
        }
        public List<Invoice> GetAllPerDateToDate(DateTime from, DateTime to)
        {
            List<Invoice> a = new List<Invoice>();
            while(from!=to)
            {
                a.AddRange(repo.FindAllPerData(from));
                from.AddDays(1);
            }
            return a;
        }
    }
}
