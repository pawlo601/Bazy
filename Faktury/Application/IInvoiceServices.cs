using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Invoice;
using Domain.Model.Client;

namespace Application
{
    public interface IInvoiceServices 
    {
        void CreateInvoice(string id);
        void SendToMailInvoice(string id);
        List<Invoice> GetAllPerClient(Domain.Model.Client.PersonalData pd);
        List<Invoice> GetAllPerDate(DateTime p);
        List<Invoice> GetAllPerDateToDate(DateTime from, DateTime to);
    }
}
