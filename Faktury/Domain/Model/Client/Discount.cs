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
        public virtual int IdDiscount { get; set; }
        public virtual int IdClient { get; set; }
        public virtual int IdProduct { get; set; }
        public virtual Bonus Type { get; set; }
        public virtual float ValueOfBonus { get;  set; }

        public Discount()
        {
            IdDiscount = -1;
            IdClient = -1;
            IdProduct = -1;
            Type = Bonus.Netto;
            ValueOfBonus = 0.0f;
        }
        public Discount(int idProduct, Bonus type)
        {
            IdDiscount = -1;
            IdClient = -1;
            IdProduct = idProduct;
            Type = Bonus.Netto;
            ValueOfBonus = 0.0f;
        }
        public Discount(int idProduct, Bonus type, float bonus) 
        {
            IdDiscount = -1;
            IdClient = -1;
            if(bonus<0.0f||bonus>=1.0f)
                throw new Exception("Niewłaściwy bonus.\n");
            IdProduct = idProduct;
            Type = Bonus.Zniżka;
            ValueOfBonus = bonus;
        }
        public virtual void ChangeType(Bonus type, float bonus ) 
        {
            if (type != Bonus.Zniżka)
                this.ValueOfBonus = 0.0f;
            else
                this.ValueOfBonus = bonus;
            this.Type = type;
        }
        public virtual void ChangeBonus(float bonus) 
        {
            if (bonus >= 0.0f && bonus < 1.0f)
                ValueOfBonus = bonus;
            else
                throw new Exception("Niewłaściwy bonus.\n");
          
        }
    }
}
