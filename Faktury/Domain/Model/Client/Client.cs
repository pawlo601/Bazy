using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iesi.Collections;
using Iesi.Collections.Generic;
/*
 drop table ListOfDiscount
 go
  
 create table ListOfDiscount
(
	ID_Client int,
	IdProduct int,
	ValueOfBonus float,
	Type varchar(10)
)
go
 */
namespace Domain.Model.Client
{
    public class Client
    {
        public virtual int IdClient { get; set; }
        public virtual PersonalData Data { get; set; }
        public virtual Address Localisation { get; set; }
        public virtual Regon Regon { get; set; }
        public virtual NIP Nip { get; set; }
        public virtual Phone NumberOfPhone { get; set; }
        public virtual Mail MailToClient { get; set; }
        public virtual Iesi.Collections.Generic.ISet<Discount> ListOfDiscount { get; set; }

        public Client()
        {
            IdClient = 1;
            Data = new PersonalData();
            Localisation = new Address();
            Regon = new Regon();
            Nip = new NIP();
            NumberOfPhone = new Phone();
            MailToClient = new Mail();
            ListOfDiscount = new HashedSet<Discount>();
        }
        public virtual void AddSomeDiscounts()
        {
            Random rand = new Random();
            int j=rand.Next(1,6);
            for (int i = 0; i < j; i++)
            {
                ListOfDiscount.Add(new Discount());
                System.Threading.Thread.Sleep(50);
            }
        }
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
            IdClient = -1;
            Data = name;
            Localisation = lok;
            Regon = null;
            Nip = null;
            ListOfDiscount = new HashedSet<Discount>();
        }
        public virtual void AddDiscount(Discount dis)
        {
            ListOfDiscount.Add(dis);
        }
        public virtual void ChangeTypeToCompany(Regon reg, NIP nip)
        {
            Data.ChangeToCompany(this.Data.NameOfCompany);
            Regon = reg;
            Nip = nip;
        }
        public virtual void ChangeTypeToPrivPer()
        {
            Data.ChangeToPrivate(this.Data.Name,this.Data.SurName);
            Regon = null;
            Nip = null;
        }
        public override string ToString()
        {
            string text = String.Format("ID klienta: {1}{0}", Environment.NewLine, IdClient.ToString()) +
                                    "====================================" +
                                    String.Format("Dane:{0}{0}{1}", Environment.NewLine, Data.ToString()) +
                                    "====================================" +
                                    String.Format("Adres:{0}{0}{1}", Environment.NewLine, Localisation.ToString()) +
                                    "====================================" +
                                    String.Format("Regon, NIP:{0}{1}{0}{2}", Environment.NewLine, Regon.ToString(), Nip.ToString()) +
                                    "====================================" +
                                    String.Format("Kontakt:{0}{1}{0}{2}", Environment.NewLine, MailToClient.ToString(), NumberOfPhone.ToString()) +
                                    "====================================" +
                                    String.Format("Zniżki:{0}", Environment.NewLine);
            foreach (Discount a in ListOfDiscount)
                text += a.ToString() + "------------------------------------";

            return text;
        }
    }
}
