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
        public virtual string MailClient { get; set; }
        private MailAddress Address;
        public Mail()
        {
            MailClient = "Przykładowy@Adres.com";
            Address = new MailAddress(MailClient);
        }
        public Mail(string name, string host)
        {
            try
            {
                MailClient = name + "@" + host;
                Address = new MailAddress(MailClient);
            }
            catch(Exception e)
            {
                throw new Exception("Błąd w adresie\n" + e.Message);
            }
        }
        public override string ToString()
        {
            return "Mail: " + MailClient;
        }
    }
}
