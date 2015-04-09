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
        public void CreateInvoice(Invoice p)
        {
            throw new NotImplementedException();
        }

        public void SendToMailInvoice(Invoice p)
        {
            throw new NotImplementedException();
        }

        public void CreateReportMonth(DateTime Month)
        {
            throw new NotImplementedException();
        }

        public void CreateReport3Month(DateTime Month)
        {
            throw new NotImplementedException();
        }

        public void CreateReportYear(DateTime Date)
        {
            throw new NotImplementedException();
        }

        public List<Invoice> GetAllPerClient(Domain.Model.Client.Client p)
        {
            throw new NotImplementedException();
        }

        public List<Invoice> GetAllPerDate(DateTime p)
        {
            throw new NotImplementedException();
        }

        public List<Invoice> GetAllPerDateToDate(DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }
    }
}
