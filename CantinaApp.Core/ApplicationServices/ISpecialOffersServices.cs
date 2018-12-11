using CantinaApp.Core.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CantinaApp.Core.ApplicationServices
{
    public interface ISpecialOffersServices
    {
        SpecialOffers GetSpecialOffersById (int id);

        List<SpecialOffers> GetSpecialOffers();

        SpecialOffers AddSpecialOffer(SpecialOffers specialOffers);

        SpecialOffers DeleteSpecialOffer(int id);

        SpecialOffers UpdateSpecialOffer(SpecialOffers specialOffers);

        IEnumerable<SpecialOffers> ReadTodaySpecielOffers(DateTime date);
    }
}
