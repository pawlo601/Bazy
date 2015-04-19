using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Client
{
    public class Phone 
    {
        private string Number;
        private string Prefix;
        public virtual string NumberPhone { get; set; }
        public Phone()
        {
            Prefix = "+48";
            Number = "123456789";
            NumberPhone = Prefix + Number;
        }
        public Phone(string prefix, string number)
        {
            if (number.Length == 9)
            {
                int[] numbers = new int[number.Length];
                for (int c = 0; c < number.Length; c++)
                    if (!int.TryParse(number.Substring(c, 1), out numbers[c]))
                        throw new Exception("Błąd w numerze.Niewłaściwe znaki.\n");
                this.Number = number;
                this.Prefix = prefix;
                NumberPhone = Prefix + Number;
            }
            else
                throw new Exception("Zła długość numeru.\n");
        }
        public override string ToString()
        {
            return string.Format("Numer telefonu: ({0}) {1}-{2}-{3}", 
                Prefix, 
                this.Number.Substring(0, 3), 
                this.Number.Substring(3, 3), 
                this.Number.Substring(6, 3));
        }
    }
}
