using System;
using Catalog.Core.Models;
using CrossCuttingConcerns.Core.ValueObjects;

namespace Catalog.Core.ValueObjects
{
    public class Discount : ValueData
    {
        public Discount(SpecialOffer offer, Price price)
        {
            OfferId = offer.Id;
            Title = offer.Title;
            Details = offer.Details;
            Duration = offer.Duration;
            Price = price;
        }

        public Guid OfferId { get; private set; }
        public string Title { get; private set; }
        public string Details { get; private set; }
        public Duration Duration { get; private set; }
        public Price Price { get; private set; }

        public bool IsActive()
        {
            return Duration.IsActive();
        }
    }
}