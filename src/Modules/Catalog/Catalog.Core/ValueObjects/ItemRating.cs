using CrossCuttingConcerns.Core.ValueObjects;

namespace Catalog.Core.ValueObjects
{
    public class ItemRating : ValueData
    {
        public ItemRating(int numberOfRatings, double averageRating)
        {
            NumberOfRatings = numberOfRatings;
            AverageRating = averageRating;
        }

        public int NumberOfRatings { get; private set; }

        public double AverageRating { get; private set; }
    }
}