using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Model.Client
{
    public enum Bonus { Zniżka, Netto};
    public class Discount
    {
        public Guid IdProduct { get; private set; }
        public Bonus Type { get; private set; }
        public double ValueOfBonus { get; private set; }
        public Discount(Guid id, Bonus type)
        {
            IdProduct = id;
            Type = Bonus.Netto;
            ValueOfBonus = 0.0f;
        }
        public Discount(Guid id, Bonus type, double bonus) 
        {
            if(bonus<0.0f||bonus>=1.0f)
                throw new Exception("Niewłaściwy bonus.\n");
            IdProduct = id;
            Type = Bonus.Zniżka;
            ValueOfBonus = bonus;
        }
        public void ChangeType(Bonus type, double bonus ) 
        {
            if (type != Bonus.Zniżka)
                this.ValueOfBonus = 0.0f;
            else
                this.ValueOfBonus = bonus;
            this.Type = type;
        }
        public void ChangeBonus(double bonus) 
        {
            if (bonus >= 0.0f && bonus < 1.0f)
                ValueOfBonus = bonus;
            else
                throw new Exception("Niewłaściwy bonus.\n");
          
        }
    }
}
