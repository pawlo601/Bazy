using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Client
{
    public enum Typ {Firma, KlientPrywatny};
    public class Client
    {
        public Guid IdClient { get; private set; }
        public PersonalData Data { get; set; }
        public Address Localisation { get; set; }
        public Typ Type { get; private set; }
        public Regon Regon { get; private set; }
        public NIP Nip { get; private set; }
        public Phone NumberOfPhone { get; set; }
        public Mail MailToClient { get; set; }
        public List<Discount> ListOfDiscount { get; private set; }

        public Client(PersonalData name, Address lok, Regon reg, NIP nip)
        {
            IdClient = Guid.NewGuid();
            Data = name;
            Localisation = lok;
            if (reg == null && nip == null)
                Type = Typ.KlientPrywatny;
            else if (reg != null && nip != null)
                Type = Typ.Firma;
            else
                throw new Exception("Niewłaściwy rodzaj spółki.\n");
            Regon = reg;
            Nip = nip;
            ListOfDiscount = new List<Discount>();
        }
        public void AddDiscount(Discount dis)
        {
            ListOfDiscount.Add(dis);
        }
        public void ChangeTypeToCompany(Regon reg, NIP nip)
        {
            Type = Typ.Firma;
            Regon = reg;
            Nip = nip;
        }
        public void ChangeTypeToPrivPer()
        {
            Type = Typ.KlientPrywatny;
            Regon = null;
            Nip = null;
        }
    }
}
