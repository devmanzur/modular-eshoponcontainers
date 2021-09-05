using System;
using CrossCuttingConcerns.Core.ValueObjects;

namespace Catalog.Core.ValueObjects
{
    public class UserData : ValueData
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
    }
}