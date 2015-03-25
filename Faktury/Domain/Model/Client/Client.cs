using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Client
{
    public class Client
    {
        public String IdClient { get { return IdClient; } }
        public PersonalData Name { get; set; }
        public Address Lokalizacja { get; set; }
        public String Type { get { return Type; } }
        public REGON Regon { get { return Regon; } }
        public NIP Nip { get; set; }
        public Phone NumberOfPhone { get; set; }
        public Mail MailToClient { get; set; }
        public List<Discount> ListOfDiscount { get { return ListOfDiscount; } }
        public Client(PersonalData name, Address lok, REGON reg, NIP nip);
        public void AddDiscount(Discount dis);
        public void ChangeTypeToCompany(REGON reg, NIP nip);
        public void ChangeTypeToPrivPer();
    }
}
