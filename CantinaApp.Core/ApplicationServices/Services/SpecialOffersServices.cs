using System;
using System.Collections.Generic;
using System.Linq;
using CantinaApp.Core.DomainServices;
using CantinaApp.Core.Entity.Entities;

namespace CantinaApp.Core.ApplicationServices.Services
{
    public class SpecialOffersServices : ISpecialOffersServices
    {
        readonly ISpecialOffersRepositories _sOffersRepo;

        public SpecialOffersServices(ISpecialOffersRepositories sOffersRepo)
        {
            _sOffersRepo = sOffersRepo;
        }

        public SpecialOffers AddSpecialOffer(SpecialOffers specialOffers)
        {
            
            if (specialOffers.Price < 1)
            {
                throw new ArgumentException("Price need to be higher than 0");
            }
            if (specialOffers.SpecialOfferName == null)
            {
                throw new ArgumentException("Speciel offer need a name");
            }
            return _sOffersRepo.CreateSpecialOffers(specialOffers);
        }

        public SpecialOffers GetSpecialOffersById(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("Id need to be higher than 0");
            }

            return _sOffersRepo.ReadSpecialOffers().ToList().FirstOrDefault(spc => spc.Id == id);
        }

        public SpecialOffers DeleteSpecialOffer(int id)
        {

            if (id < 1)
            {
                throw new ArgumentException("Id need to be higher than 0");
            }
            return _sOffersRepo.DeleteSpecialOffers(id);
        }

        public List<SpecialOffers> GetSpecialOffers()
        {
            return _sOffersRepo.ReadSpecialOffers().ToList();
        }

        public SpecialOffers UpdateSpecialOffer(SpecialOffers specialOffers)
        {
            if (specialOffers.Price < 1)
            {
                throw new ArgumentException("Price need to be higher than 0");
            }
            if (specialOffers.SpecialOfferName == null)
            {
                throw new ArgumentException("Speciel offer need a name");
            }
            if (specialOffers.Id < 1)
            {
                throw new ArgumentException("Id need to be higher than 0");
            }
            return _sOffersRepo.UpdateSpecialOffers(specialOffers);
        }
    }
}
