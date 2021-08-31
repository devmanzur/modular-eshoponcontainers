using System;
using Catalog.Core.Rules;
using FluentAssertions;
using Xunit;

namespace Catalog.Core.Tests.Core.Rules
{
    public partial class BusinessRulesTests
    {
        [Fact]
        public void Given_valid_image_extension_it_is_accepted_as_valid_image_url()
        {
            var imageUrl = GetValidImageUrl();
            var rule = new ImageIdMustEndWithValidImageExtensionRule(imageUrl);
            var broken = rule.IsBroken();

            broken.Should().BeFalse();
        }
    }
}