using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Client;

namespace Finance.ObjectMothers
{
    public class ClientObjectMothers
    {
        public static Client CreateClientPrivateWithoutDiscount()
        {
            PersonalData per = new PersonalData("Imie", "Nazwisko");
            Address addr = new Address();
            Client a = new Client(per, addr);
            return a;
        }
        public static Client CreateClientPrivateWithDiscountNetto()
        {
            PersonalData per = new PersonalData("Imie", "Nazwisko");
            Address addr = new Address();
            Client a = new Client(per, addr);
            Discount dis = new Discount(new Guid(), Bonus.Netto);
            a.AddDiscount(dis);
            return a;
        }
        public static Client CreateClientPrivateWithDiscountZnizka()
        {
            PersonalData per = new PersonalData("Imie", "Nazwisko");
            Address addr = new Address();
            Client a = new Client(per, addr);
            Discount dis = new Discount(new Guid(), Bonus.Zniżka, 0.10f);
            a.AddDiscount(dis);
            return a;
        }
        public static Client CreateClientCompanyWithoutDiscount()
        {
            PersonalData per = new PersonalData("Firma");
            Address addr = new Address();
            Regon reg = new Regon();
            NIP nip = new NIP();
            Client a = new Client(per, addr, reg, nip);
            return a;
        }
        public static Client CreateClientCompanyWithDiscountNetto()
        {
            PersonalData per = new PersonalData("Firma");
            Address addr = new Address();
            Regon reg = new Regon();
            NIP nip = new NIP();
            Client a = new Client(per, addr, reg, nip);
            Discount dis = new Discount(new Guid(), Bonus.Netto);
            a.AddDiscount(dis);
            return a;
        }
        public static Client CreateClientCompanyWithDiscountZnizka()
        {
            PersonalData per = new PersonalData("Firma");
            Address addr = new Address();
            Regon reg = new Regon();
            NIP nip = new NIP();
            Client a = new Client(per, addr, reg, nip);
            Discount dis = new Discount(new Guid(), Bonus.Zniżka, 0.1f);
            a.AddDiscount(dis);
            return a;
        }
        public static Address CreateAddress()
        {
            Address addr = new Address("Ulica", "5/6", "Wrocław", "12-345", "Poland");
            return addr;
        }
        public static Discount CreateDiscountNetto()
        {
            Discount dis = new Discount(new Guid(), Bonus.Netto);
            return dis;
        }
        public static Discount CreateDiscountZnizka()
        {
            Discount dis = new Discount(new Guid(), Bonus.Zniżka);
            return dis;
        }
        public static Regon CreateRegon()
        {
            return new Regon();
        }
        public static NIP CreateNip()
        {
            return new NIP();
        }
    }
}
