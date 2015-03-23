using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Model.Client
{
    public class Discount
    {
        private String IdProduct;
        public String Type { get { return Type; } }
        public Double Bonus { get { return Bonus; } }
        public Discount(String type, Double bonus = 0.0f) { }
        public String GetId() { return null; }
        public void ChangeType(String type, Double bonus = 0.0f) { }
        public void ChangeBonus(Double bonus) { }
    }
}
