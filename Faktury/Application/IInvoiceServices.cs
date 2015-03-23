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
        void CreateInvoice(Invoice p);
        void CreateReceipt(Invoice p);
        void SendToMailInvoice(Invoice p);
        void CreateReportMonth(DateTime Month);
        void CreateReport3Month(DateTime Month);
        void CreateReportYear(DateTime Date);
        List<Invoice> GetAllPerClient(Client p);
        List<Invoice> GetAllPerDate(DateTime p);
        List<Invoice> GetAllPerDateToDate(DateTime from, DateTime to);
    }
}
