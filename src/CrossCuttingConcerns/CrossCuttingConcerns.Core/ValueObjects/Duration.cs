using System;

namespace CrossCuttingConcerns.Core.ValueObjects
{
    public class Duration
    {
        public Duration(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }

        public bool IsActive()
        {
            return Start < DateTime.UtcNow && End > DateTime.UtcNow;
        }
    }
}