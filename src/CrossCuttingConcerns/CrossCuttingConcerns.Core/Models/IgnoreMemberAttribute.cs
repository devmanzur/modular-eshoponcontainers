using System;

namespace CrossCuttingConcerns.Core.Models
{
   
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class IgnoreMemberAttribute : Attribute
    {
    }
}