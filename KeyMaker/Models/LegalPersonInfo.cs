using SaaedCo.KeyMaker.Enums;

namespace SaaedCo.KeyMaker.Models
{
    public class LegalPersonInfo
    {
        public LagalPersonTypes PersonType { get; set; }
        public string EnglishName { get; set; }
        public string PersianName { get; set; }
        public string NationalIdentity { get; set; }
        public string OrgUnit1 { get; set; }
        public string OrgUnit2 { get; set; }
        public string OrgUnit3 { get; set; }
        public string Email { get; set; }
        public string PersianProvinceName { get; set; }
        public string PersianCityName { get; set; }

        public LegalPersonInfo()
        {
            
        }

        public LegalPersonInfo(
            LagalPersonTypes personType,
            string englishName,
            string persianName,
            string nationalIdentity,
            string orgUnit1,
            string orgUnit2,
            string orgUnit3,
            string email,
            string provinceName,
            string cityName)
        {
            PersonType = personType;
            EnglishName = englishName;
            PersianName = persianName;
            NationalIdentity = nationalIdentity;
            OrgUnit1 = orgUnit1;
            OrgUnit2 = orgUnit2;
            OrgUnit3 = orgUnit3;
            Email = email;
            PersianProvinceName = provinceName;
            PersianCityName = cityName;
        }
    }
}
