using System;
using Catalog.Core.Enums;
using Catalog.Core.ValueObjects;
using CrossCuttingConcerns.Core.Models;

namespace Catalog.Core.Models
{
    public class Review : BaseEntity
    {
        public Guid ProductId { get; set; }
        public UserData User { get; private set; }
        public Rating Rating { get; private set; }
        public string Details { get; private set; }
    }
}