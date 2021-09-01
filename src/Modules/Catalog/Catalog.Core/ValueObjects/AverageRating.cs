using CrossCuttingConcerns.Core.ValueObjects;

namespace Catalog.Core.ValueObjects
{
    public class AverageRating : ValueData
    {
        public AverageRating(int numberOfRatings, double average)
        {
            NumberOfRatings = numberOfRatings;
            Average = average;
        }

        public int NumberOfRatings { get; private set; }

        public double Average { get; private set; }
    }
}