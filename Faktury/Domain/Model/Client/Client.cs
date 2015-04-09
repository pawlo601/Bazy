using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Client
{
    public class Client
    {
        public Guid IdClient { get; private set; }
        public PersonalData Data { get; set; }
        public Address Localisation { get; set; }
        public Regon Regon { get; private set; }
        public NIP Nip { get; private set; }
        public Phone NumberOfPhone { get; set; }
        public Mail MailToClient { get; set; }
        public List<Discount> ListOfDiscount { get; private set; }
        public Client(PersonalData name, Address lok)
        {
            if (!name.Type.Equals(Typ.KlientPrywatny))
                throw new Exception("Niezgode dane.");
            ClientCreate(name, lok);
        }
        public Client(PersonalData name, Address lok, Regon reg, NIP nip)
        {
            if (!name.Type.Equals(Typ.Firma))
                throw new Exception("Niezgode dane.");
            ClientCreate(name, lok);
            Regon = reg;
            Nip = nip;
        }
        private void ClientCreate(PersonalData name, Address lok)
        {
            IdClient = Guid.NewGuid();
            Data = name;
            Localisation = lok;
            Regon = null;
            Nip = null;
            ListOfDiscount = new List<Discount>();
        }
        public void AddDiscount(Discount dis)
        {
            ListOfDiscount.Add(dis);
        }
        public void ChangeTypeToCompany(Regon reg, NIP nip)
        {
            Data.ChangeToCompany(this.Data.NameOfCompany);
            Regon = reg;
            Nip = nip;
        }
        public void ChangeTypeToPrivPer()
        {
            Data.ChangeToPrivate(this.Data.Name,this.Data.SurName);
            Regon = null;
            Nip = null;
        }
    }
}
