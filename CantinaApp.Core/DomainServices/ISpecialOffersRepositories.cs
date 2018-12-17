using CantinaApp.Core.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CantinaApp.Core.DomainServices
{
    public interface ISpecialOffersRepositories
    {
        IEnumerable<SpecialOffers> ReadSpecialOffers();

        SpecialOffers CreateSpecialOffers(SpecialOffers specialOffers);

        SpecialOffers DeleteSpecialOffers(int id);

        SpecialOffers UpdateSpecialOffers(SpecialOffers specialOffers);

        SpecialOffers ReadByIdIncludeIngr(int id);

        IEnumerable<SpecialOffers> ReadTodaySpecielOffers(DateTime date);
    }
}
