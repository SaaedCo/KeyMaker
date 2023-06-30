using SaaedCo.KeyMaker.Enums;
using SaaedCo.KeyMaker.Enums.Extensions;
using System.Text;

namespace SaaedCo.KeyMaker.Models
{
    public class RealPersonInfo
    {
        public RealPersonTypes PersonType { get; set; }
        public string PersianOrgName { get; set; }
        public string OrgUnit1 { get; set; }
        public string OrgUnit2 { get; set; }
        public string OrgUnit3 { get; set; }
        public string EnglishFirstName { get; set; }
        public string PersianFirstName { get; set; }
        public string EnglishLastName { get; set; }
        public string PersianLastName { get; set; }
        public string Email { get; set; }
        public string NationalCode { get; set; }
        public string OrgRole { get; set; }
        public string PersianProvinceName { get; set; }
        public string PersianCityName { get; set; }

        public RealPersonInfo()
        {

        }

        public RealPersonInfo(
            RealPersonTypes personType,
            string persianOrgName,
            string orgUnit1,
            string orgUnit2,
            string orgUnit3,
            string englishFirstName,
            string persianFirstName,
            string englishLastName,
            string persianLastName,
            string email,
            string nationalCode,
            string orgRole,
            string persianProvinceName,
            string persianCityName)
        {
            PersonType = personType;
            PersianOrgName = persianOrgName;
            OrgUnit1 = orgUnit1;
            OrgUnit2 = orgUnit2;
            OrgUnit3 = orgUnit3;
            EnglishFirstName = englishFirstName;
            PersianFirstName = persianFirstName;
            EnglishLastName = englishLastName;
            PersianLastName = persianLastName;
            Email = email;
            NationalCode = nationalCode;
            OrgRole = orgRole;
            PersianProvinceName = persianProvinceName;
            PersianCityName = persianCityName;
        }

        public string OrganizationIdentifier
        {
            get
            {
                var result = new StringBuilder();
                result.Append(PersonType.GetConfigValue());

                if (!string.IsNullOrWhiteSpace(OrgUnit2))
                    result.Append($",{OrgUnit2}");

                if (!string.IsNullOrWhiteSpace(OrgUnit1))
                    result.Append($",{OrgUnit1}");

                result.Append($",{NationalCode} {EnglishFirstName} {EnglishLastName} [Sign]");

                return result.ToString();
            }
        }
    }
}
