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
        public int IdProduct { get; set; }
        public Bonus Type { get; set; }
        public float ValueOfBonus { get;  set; }

        public Discount()
        {
            Random rand = new Random();
            IdProduct = rand.Next(1,1000);
            if(rand.Next(0,100)>50)
                Type = Bonus.Netto;
            else
                Type = Bonus.Zniżka;
            ValueOfBonus = (float)(rand.NextDouble());
        }
        public Discount(int idProduct, Bonus type)
        {
            IdProduct = idProduct;
            Type = Bonus.Netto;
            ValueOfBonus = 0.0f;
        }
        public Discount(int idProduct, Bonus type, float bonus)
        {
            if(bonus<0.0f||bonus>=1.0f)
                throw new Exception("Niewłaściwy bonus.\n");
            IdProduct = idProduct;
            Type = Bonus.Zniżka;
            ValueOfBonus = bonus;
        }
        public void ChangeType(Bonus type, float bonus ) 
        {
            if (type != Bonus.Zniżka)
                this.ValueOfBonus = 0.0f;
            else
                this.ValueOfBonus = bonus;
            this.Type = type;
        }
        public void ChangeBonus(float bonus) 
        {
            if (bonus >= 0.0f && bonus < 1.0f)
                ValueOfBonus = bonus;
            else
                throw new Exception("Niewłaściwy bonus.\n");
          
        }
        public override string ToString()
        {
            return String.Format("ID produktu: {1}{0}Typ bonusu: {2}{0}Wartość zniżki: {3}{0}",
                        Environment.NewLine, IdProduct.ToString(), Type.ToString(), ValueOfBonus.ToString());
        }
    }
}
