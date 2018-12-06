using System;
using System.Collections.Generic;
using System.Text;

namespace CantinaApp.Core.Entity.Entities
{
    public class SpecialOffers
    {
        public int Id { get; set; }
        public String SpecialOfferName { get; set; }
        public Double Price { get; set; }
        public int FoodIconId { get; set; }
    }
}
