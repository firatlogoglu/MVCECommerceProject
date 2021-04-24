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
            string imgpath = "/Uploads/Image/Users/no_photo.jpg";
            string UserBy = "Server";

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
                ConfirmPassword = "1234",
                Role = Enums.Role.Customer,
                PhoneNumber = "05350000000",
                Address = "Havaalanı yolu",
                Status = CORE.Enums.Status.Active,
                CreatedBy = UserBy,
                ImagePath = imgpath
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
                ConfirmPassword = "32145",
                Role = Enums.Role.Customer,
                Address = "Atatürk Cad.",
                Status = CORE.Enums.Status.Active,
                PhoneNumber = "2120000000",
                CreatedBy = UserBy,
                ImagePath = imgpath
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
                Password = "32145",
                ConfirmPassword = "32145",
                Role = Enums.Role.Customer,
                Address = "Yukarı Yol Cad.",
                Status = CORE.Enums.Status.Active,
                PhoneNumber = "21200000123",
                CreatedBy = UserBy,
                ImagePath = imgpath
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
                Password = "32145",
                ConfirmPassword = "32145",
                Role = Enums.Role.Customer,
                Address = "Kestirme Sok.",
                Status = CORE.Enums.Status.Active,
                PhoneNumber = "21200000336",
                CreatedBy = UserBy,
                ImagePath = imgpath
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
                Password = "32145",
                ConfirmPassword = "32145",
                Role = Enums.Role.Customer,
                Address = "Çıkmaz Sok.",
                Status = CORE.Enums.Status.Active,
                CreatedBy = UserBy,
                ImagePath = imgpath
            });
            context.Users.AddRange(appusers);
            #endregion

            #region Çalışanlar

            IList<AppUser> appusers2 = new List<AppUser>();

            Guid emp1 = Guid.NewGuid();
            Guid emp2 = Guid.NewGuid();
            Guid emp3 = Guid.NewGuid();
            Guid emp4 = Guid.NewGuid();
            Guid emp5 = Guid.NewGuid();

            appusers2.Add(new AppUser()
            {
                ID = emp1,
                TCNO = "211111111",
                BirthDate = new DateTime(1990, 4, 1),
                BirthPlace = "İstanbul",
                Name = "Mehmet",
                SurName = "Güneş",
                Gender = Enums.Person.Gender.Male,
                BloodType = Enums.Person.BloodType.O_Positive,
                MaritalState = Enums.Person.MaritalState.Single,
                Email = "mehmetgunes@smail.com",
                Password = "1234",
                ConfirmPassword = "1234",
                Role = Enums.Role.Admin,
                PhoneNumber = "05350000000",
                Address = "Havaalanı yolu",
                Status = CORE.Enums.Status.Active,
                CreatedBy = UserBy,
                ImagePath = imgpath
            });

            appusers2.Add(new AppUser()
            {
                ID = emp2,
                TCNO = "12222222222",
                BirthDate = new DateTime(1991, 3, 1),
                BirthPlace = "Çanakkale",
                Name = "Ayşe",
                SurName = "Irmak",
                Gender = Enums.Person.Gender.Female,
                MaritalState = Enums.Person.MaritalState.Married,
                BloodType = Enums.Person.BloodType.B_Positive,
                Email = "ayseirmak@smail.com",
                Password = "32145",
                ConfirmPassword = "32145",
                Role = Enums.Role.Admin,
                Address = "Atatürk Cad.",
                Status = CORE.Enums.Status.Active,
                CreatedBy = UserBy,
                PhoneNumber = "2120000000",
                ImagePath = imgpath
            });

            appusers2.Add(new AppUser()
            {
                ID = emp3,
                TCNO = "23333333333",
                BirthDate = new DateTime(1990, 5, 1),
                BirthPlace = "Adana",
                Name = "Fırat",
                SurName = "Nur",
                Gender = Enums.Person.Gender.Male,
                BloodType = Enums.Person.BloodType.A_Positive,
                MaritalState = Enums.Person.MaritalState.Single,
                Email = "firatnur@smail.com",
                Password = "32145",
                ConfirmPassword = "32145",
                Role = Enums.Role.Admin,
                Address = "Yukarı Yol Cad.",
                Status = CORE.Enums.Status.Active,
                PhoneNumber = "21200000123",
                CreatedBy = UserBy,
                ImagePath = imgpath
            });

            appusers2.Add(new AppUser()
            {
                ID = emp4,
                TCNO = "24444444444",
                BirthDate = new DateTime(1993, 6, 4),
                BirthPlace = "Tekirdağ",
                Name = "Fatma",
                SurName = "Güney",
                Gender = Enums.Person.Gender.Female,
                BloodType = Enums.Person.BloodType.A_Positive,
                MaritalState = Enums.Person.MaritalState.Single,
                Email = "fatmaguney@smail.com",
                Password = "32145",
                ConfirmPassword = "32145",
                Role = Enums.Role.Admin,
                Address = "Kestirme Sok.",
                Status = CORE.Enums.Status.Active,
                PhoneNumber = "21200000336",
                CreatedBy = UserBy,
                ImagePath = imgpath
            });

            appusers2.Add(new AppUser()
            {
                ID = emp5,
                TCNO = "25555555555",
                BirthDate = new DateTime(1988, 5, 4),
                BirthPlace = "Hatay",
                Name = "Ali",
                SurName = "Dünya",
                Gender = Enums.Person.Gender.Male,
                BloodType = Enums.Person.BloodType.A_Positive,
                MaritalState = Enums.Person.MaritalState.Widowed,
                Email = "alidunya@smail.com",
                Password = "32145",
                ConfirmPassword = "32145",
                Role = Enums.Role.Admin,
                Address = "Çıkmaz Sok.",
                Status = CORE.Enums.Status.Active,
                CreatedBy = UserBy,
                ImagePath = imgpath
            });
            context.Users.AddRange(appusers2);
            #endregion

            #region Satıcılar

            IList<AppUser> sellers = new List<AppUser>();

            Guid s1 = Guid.NewGuid();
            Guid s2 = Guid.NewGuid();
            Guid s3 = Guid.NewGuid();
            Guid s4 = Guid.NewGuid();
            Guid s5 = Guid.NewGuid();

            sellers.Add(new AppUser()
            {
                ID = s1,
                TCNO = "31111111111",
                BirthDate = new DateTime(1990, 4, 1),
                BirthPlace = "İstanbul",
                Name = "Mehmet",
                SurName = "Kutup",
                Gender = Enums.Person.Gender.Male,
                BloodType = Enums.Person.BloodType.O_Positive,
                MaritalState = Enums.Person.MaritalState.Single,
                Email = "mehmet@kutup.com",
                Password = "1234",
                ConfirmPassword = "1234",
                Role = Enums.Role.Seller_Customer,
                PhoneNumber = "05350000000",
                Address = "Havaalanı yolu",
                Status = CORE.Enums.Status.Active,
                CreatedBy = UserBy,
                ImagePath = imgpath
            });

            sellers.Add(new AppUser()
            {
                ID = s2,
                TCNO = "32222222222",
                BirthDate = new DateTime(1991, 3, 1),
                BirthPlace = "Çanakkale",
                Name = "Ayşe",
                SurName = "Tembel",
                Gender = Enums.Person.Gender.Female,
                MaritalState = Enums.Person.MaritalState.Married,
                BloodType = Enums.Person.BloodType.B_Positive,
                Email = "aysetembel@smail.com",
                Password = "32145",
                ConfirmPassword = "32145",
                Role = Enums.Role.Seller_Customer,
                Address = "Atatürk Cad.",
                Status = CORE.Enums.Status.Active,
                PhoneNumber = "2120000000",
                CreatedBy = UserBy,
                ImagePath = imgpath
            });

            sellers.Add(new AppUser()
            {
                ID = s3,
                TCNO = "13333333333",
                BirthDate = new DateTime(1990, 5, 1),
                BirthPlace = "Adana",
                Name = "Fırat",
                SurName = "Kartal",
                Gender = Enums.Person.Gender.Male,
                BloodType = Enums.Person.BloodType.A_Positive,
                MaritalState = Enums.Person.MaritalState.Single,
                Email = "firatkartal@smail.com",
                Password = "32145",
                ConfirmPassword = "32145",
                Role = Enums.Role.Seller_Customer,
                Address = "Yukarı Yol Cad.",
                Status = CORE.Enums.Status.Active,
                PhoneNumber = "21200000123",
                CreatedBy = UserBy,
                ImagePath = imgpath
            });

            sellers.Add(new AppUser()
            {
                ID = s4,
                TCNO = "34444444444",
                BirthDate = new DateTime(1993, 6, 4),
                BirthPlace = "Tekirdağ",
                Name = "Fatma",
                SurName = "Çelikçi",
                Gender = Enums.Person.Gender.Female,
                BloodType = Enums.Person.BloodType.A_Positive,
                MaritalState = Enums.Person.MaritalState.Single,
                Email = "fatmacelikci@smail.com",
                Password = "32145",
                ConfirmPassword = "32145",
                Role = Enums.Role.Seller_Customer,
                Address = "Kestirme Sok.",
                Status = CORE.Enums.Status.Active,
                PhoneNumber = "21200000336",
                CreatedBy = UserBy,
                ImagePath = imgpath
            });

            sellers.Add(new AppUser()
            {
                ID = s5,
                TCNO = "35555555555",
                BirthDate = new DateTime(1988, 5, 4),
                BirthPlace = "Hatay",
                Name = "Ali",
                SurName = "Sabırlı",
                Gender = Enums.Person.Gender.Male,
                BloodType = Enums.Person.BloodType.A_Positive,
                MaritalState = Enums.Person.MaritalState.Widowed,
                Email = "alisabirli@smail.com",
                Password = "32145",
                ConfirmPassword = "32145",
                Role = Enums.Role.Seller_Customer,
                Address = "Çıkmaz Sok.",
                Status = CORE.Enums.Status.Active,
                CreatedBy = UserBy,
                ImagePath = imgpath
            });
            context.Users.AddRange(sellers);
            #endregion

            #region Kategoriler
            Guid c1 = Guid.NewGuid();
            Guid c2 = Guid.NewGuid();
            Guid c3 = Guid.NewGuid();
            Guid c4 = Guid.NewGuid();
            Guid c5 = Guid.NewGuid();


            #region Alt Kategoriler  - Elektronik
            SubCategory sub1 = new SubCategory()
            {
                ID = Guid.NewGuid(),
                CategoryID = c1,
                Name = "Cep Telefonu ve Aksesuar",
                Tag = "Cep Telefonu, Aksesuar",
                Description = "Cep Telefonu ve Aksesuar",
                ImagePath = imgpath,
                CreatedBy = UserBy,
                Status = CORE.Enums.Status.Active
            };

            SubCategory sub2 = new SubCategory()
            {
                ID = Guid.NewGuid(),
                CategoryID = c1,
                Name = "Bilgisayar, Tablet",
                Tag = "Bilgisayar, Tablet",
                Description = "Bilgisayar, Tablet",
                ImagePath = imgpath,
                CreatedBy = UserBy,
                Status = CORE.Enums.Status.Active
            };

            SubCategory sub3 = new SubCategory()
            {
                ID = Guid.NewGuid(),
                CategoryID = c1,
                Name = "Beyaz Eşya & Küçük Ev Aletleri",
                Tag = "Beyaz Eşya, Küçük Ev Aletleri",
                Description = "Beyaz Eşya & Küçük Ev Aletleri",
                ImagePath = imgpath,
                CreatedBy = UserBy,
                Status = CORE.Enums.Status.Active
            };

            SubCategory sub4 = new SubCategory()
            {
                ID = Guid.NewGuid(),
                CategoryID = c1,
                Name = "TV, Ses ve Görüntü Sistemleri",
                Tag = "TV, Ses, Görüntü Sistemleri",
                Description = "TV, Ses ve Görüntü Sistemleri",
                ImagePath = imgpath,
                CreatedBy = UserBy,
                Status = CORE.Enums.Status.Active
            };

            SubCategory sub5 = new SubCategory()
            {
                ID = Guid.NewGuid(),
                CategoryID = c1,
                Name = "Fotoğraf & Kamera",
                Tag = "Fotoğraf, Kamera",
                Description = "Fotoğraf & Kamera",
                ImagePath = imgpath,
                CreatedBy = UserBy,
                Status = CORE.Enums.Status.Active
            };

            SubCategory sub6 = new SubCategory()
            {
                ID = Guid.NewGuid(),
                CategoryID = c1,
                Name = "Video Oyun & Konsol",
                Tag = "Video Oyun, Konsol",
                Description = "Video Oyun & Konsol",
                ImagePath = imgpath,
                CreatedBy = UserBy,
                Status = CORE.Enums.Status.Active
            };

            SubCategory sub7 = new SubCategory()
            {
                ID = Guid.NewGuid(),
                CategoryID = c2,
                Name = "Mobilya",
                Tag = "Mobilya",
                Description = "Mobilya",
                ImagePath = imgpath,
                CreatedBy = UserBy,
                Status = CORE.Enums.Status.Active
            };
            #endregion

            IList<Category> categories = new List<Category>();


            categories.Add(new Category()
            {
                ID = c1,
                Name = "Elektronik",
                Description = "Elektronik",
                ImagePath = imgpath,
                CreatedBy = UserBy,
                SubCategories = new List<SubCategory>()
                {
                   sub1,sub2,sub3,sub4,sub5,sub6
                },
                Status = CORE.Enums.Status.Active
            });

            categories.Add(new Category()
            {
                ID = c2,
                Name = "Ev, Dekorasyon, Bahçe",
                Description = "Ev, Dekorasyon, Bahçe",
                ImagePath = imgpath,
                CreatedBy = UserBy,
                SubCategories = new List<SubCategory>()
                {
                   sub7
                },
                Status = CORE.Enums.Status.Active
            });
            context.Categories.AddRange(categories);

            #endregion
        }
    }
}