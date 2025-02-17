using SaaedCo.KeyMaker.Enums;
using SaaedCo.KeyMaker.Enums.Extensions;
using SaaedCo.KeyMaker.Models;
using System.Text;

namespace SaaedCo.KeyMaker.Logic
{
    public static class Gica
    {
        public static string GetConfig(LegalPersonInfo personInfo)
        {
            var result = new StringBuilder();

            result.AppendLine(@"[req]
prompt=no
distinguished_name=dn

[dn]");

            result.AppendLine($"CN={personInfo.EnglishName} [Stamp]");
            result.AppendLine($"serialNumber={personInfo.NationalIdentity}");
            result.AppendLine($"O={personInfo.PersonType.GetConfigValue()}");

            if (!string.IsNullOrWhiteSpace(personInfo.OrgUnit3))
                result.AppendLine($"4.OU={personInfo.OrgUnit3}");

            if (!string.IsNullOrWhiteSpace(personInfo.OrgUnit2))
                result.AppendLine($"3.OU={personInfo.OrgUnit2}");

            if (!string.IsNullOrWhiteSpace(personInfo.OrgUnit1))
                result.AppendLine($"2.OU={personInfo.OrgUnit1}");

            result.AppendLine($"1.OU={personInfo.PersianName}");
            result.AppendLine("C=IR");

            if (!string.IsNullOrWhiteSpace(personInfo.Email))
                result.AppendLine($"E={personInfo.Email}");

            if (!string.IsNullOrWhiteSpace(personInfo.PersianProvinceName))
                result.AppendLine($"ST={personInfo.PersianProvinceName}");

            if (!string.IsNullOrWhiteSpace(personInfo.PersianCityName))
                result.AppendLine($"L={personInfo.PersianCityName}");

            return result.ToString();
        }

        public static string GetConfig(RealPersonInfo personInfo)
        {
            var result = new StringBuilder();

            result.AppendLine(@"[req]
prompt=no
distinguished_name=dn

[dn]");

            result.AppendLine($"O={personInfo.PersonType.GetConfigValue()}");
            result.AppendLine($"CN={personInfo.EnglishFirstName} {personInfo.EnglishLastName} [Sign]");
            result.AppendLine($"serialNumber={personInfo.NationalCode}");
            result.AppendLine($"GN={personInfo.PersianFirstName}");
            result.AppendLine($"SN={personInfo.PersianLastName}");
            result.AppendLine($"ST={personInfo.PersianProvinceName}");
            result.AppendLine($"L={personInfo.PersianCityName}");
            result.AppendLine("C=IR");

            if (!string.IsNullOrWhiteSpace(personInfo.Email))
                result.AppendLine($"E={personInfo.Email}");

            if (personInfo.PersonType != RealPersonTypes.Unaffiliated)
            {
                if (!string.IsNullOrWhiteSpace(personInfo.OrgUnit3))
                    result.AppendLine($"4.OU={personInfo.OrgUnit3}");

                if (!string.IsNullOrWhiteSpace(personInfo.OrgUnit2))
                    result.AppendLine($"3.OU={personInfo.OrgUnit2}");

                if (!string.IsNullOrWhiteSpace(personInfo.OrgUnit1))
                    result.AppendLine($"2.OU={personInfo.OrgUnit1}");

                result.AppendLine($"1.OU={personInfo.PersianOrgName}");
                result.AppendLine($"T={personInfo.OrgRole}");
                result.AppendLine($"OrganizationIdentifier={personInfo.OrganizationIdentifier}");
            }

            return result.ToString();
        }
    }
}
