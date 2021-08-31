using CrossCuttingConcerns.Core.ValueObjects;

namespace Catalog.Core.ValueObjects
{
    public class Rating : ValueData
    {
        public Rating(int numberOfRatings, double averageRating)
        {
            NumberOfRatings = numberOfRatings;
            AverageRating = averageRating;
        }

        public int NumberOfRatings { get; private set; }

        public double AverageRating { get; private set; }
    }
}