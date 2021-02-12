using MVCECommerceProject.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace MVCECommerceProject.MODEL.Context
{
    public class SampleData : DropCreateDatabaseAlways<ProjectContext> /*: DropCreateDatabaseIfModelChanges<ProjectContext>*/
    {
        protected override void Seed(ProjectContext context)
        {
            #region Müsteriler

            IList<AppUser> appusers = new List<AppUser>();

            Guid ap1 = Guid.NewGuid();
            Guid ap2 = Guid.NewGuid();
            Guid ap3 = Guid.NewGuid();
            Guid ap4 = Guid.NewGuid();
            Guid ap5 = Guid.NewGuid();

            appusers.Add(new AppUser()
            {
                ID = ap1,
                TCNO = "11111111111",
                BirthDate = new DateTime(1990, 4, 1),
                BirthPlace = "İstanbul",
                Name = "Mehmet",
                SurName = "Gün",
                Gender = Enums.Person.Gender.Male,
                BloodType = Enums.Person.BloodType.O_Positive,
                MaritalState = Enums.Person.MaritalState.Single,
                Email = "mehmetgun@smail.com",
                Password = "1234",
                Role = Enums.Role.Member,
                PhoneNumber = "05350000000",
                Address = "Havaalanı yolu",
                Status = CORE.Enums.Status.Active,

            });

            appusers.Add(new AppUser()
            {
                ID = ap2,
                TCNO = "22222222222",
                BirthDate = new DateTime(1991, 3, 1),
                BirthPlace = "Çanakkale",
                Name = "Ayşe",
                SurName = "Çalışkan",
                Gender = Enums.Person.Gender.Female,
                MaritalState = Enums.Person.MaritalState.Married,
                BloodType = Enums.Person.BloodType.B_Positive,
                Email = "aysecaliskan@smail.com",
                Password = "32145",
                Role = Enums.Role.Member,
                Address = "Atatürk Cad.",
                Status = CORE.Enums.Status.Active,
                PhoneNumber = "2120000000"
            });

            appusers.Add(new AppUser()
            {
                ID = ap3,
                TCNO = "33333333333",
                BirthDate = new DateTime(1990, 5, 1),
                BirthPlace = "Adana",
                Name = "Fırat",
                SurName = "Şahin",
                Gender = Enums.Person.Gender.Male,
                BloodType = Enums.Person.BloodType.A_Positive,
                MaritalState = Enums.Person.MaritalState.Single,
                Email = "firatsahin@smail.com",
                Password = "456312",
                Role = Enums.Role.Member,
                Address = "Yukarı Yol Cad.",
                Status = CORE.Enums.Status.Active,
                PhoneNumber = "21200000123"
            });

            appusers.Add(new AppUser()
            {
                ID = ap4,
                TCNO = "44444444444",
                BirthDate = new DateTime(1993, 6, 4),
                BirthPlace = "Tekirdağ",
                Name = "Fatma",
                SurName = "Irmak",
                Gender = Enums.Person.Gender.Female,
                BloodType = Enums.Person.BloodType.A_Positive,
                MaritalState = Enums.Person.MaritalState.Single,
                Email = "fatmagirmak@smail.com",
                Password = "1324",
                Role = Enums.Role.Member,
                Address = "Kestirme Sok.",
                Status = CORE.Enums.Status.Active,
                PhoneNumber = "21200000336"

            });

            appusers.Add(new AppUser()
            {
                ID = ap5,
                TCNO = "55555555555",
                BirthDate = new DateTime(1988, 5, 4),
                BirthPlace = "Hatay",
                Name = "Ali",
                SurName = "Gün",
                Gender = Enums.Person.Gender.Male,
                BloodType = Enums.Person.BloodType.A_Positive,
                MaritalState = Enums.Person.MaritalState.Widowed,
                Email = "aligun@smail.com",
                Password = "1123",
                Role = Enums.Role.Member,
                Address = "Çıkmaz Sok.",
                Status = CORE.Enums.Status.Active
            });
            #endregion
        }
    }
}