using System;

namespace SaaedCo.KeyMaker.Enums.Extensions
{
    public static class LagalPersonTypesExtensions
    {
        public static string GetConfigValue(this LagalPersonTypes value)
        {
            switch (value)
            {
                case LagalPersonTypes.Governmental:
                    return "Governmental";
                case LagalPersonTypes.NonGovernmental:
                    return "Non-Governmental";
                default:
                    throw new ArgumentException("Invalid value", nameof(value));
            }
        }
    }
}
