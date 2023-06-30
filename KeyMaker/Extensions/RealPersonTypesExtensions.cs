using System;

namespace SaaedCo.KeyMaker.Enums.Extensions
{
    public static class RealPersonTypesExtensions
    {
        public static string GetConfigValue(this RealPersonTypes value)
        {
            switch (value)
            {
                case RealPersonTypes.Governmental:
                    return "Governmental";
                case RealPersonTypes.NonGovernmental:
                    return "Non-Governmental";
                case RealPersonTypes.Unaffiliated:
                    return "Unaffiliated";
                default:
                    throw new ArgumentException("Invalid value", nameof(value));
            }
        }
    }
}
