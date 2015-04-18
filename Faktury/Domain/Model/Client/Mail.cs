using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Domain.Model.Client
{
    public class Mail 
    {
        public virtual MailAddress Address { get; private set; }
        public Mail()
        {
            Address = new MailAddress("Przykładowy@Adres.com");
        }
        public Mail(string name, string host)
        {
            try
            {
                Address = new MailAddress(name + "@" + host);
            }
            catch(Exception e)
            {
                throw new Exception("Błąd w adresie\n" + e.Message);
            }
        }
        public override string ToString()
        {
            return "Mail: " + Address.ToString();
        }
        public string GetString()
        {
            return Address.ToString();
        }
    }
}
