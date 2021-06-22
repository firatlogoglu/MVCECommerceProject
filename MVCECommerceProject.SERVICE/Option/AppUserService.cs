using MVCECommerceProject.MODEL.Entities;
using MVCECommerceProject.MODEL.Enums;
using MVCECommerceProject.SERVICE.Base;
using MVCECommerceProject.COMMON.MyTools;
using System.Web;
using System;

namespace MVCECommerceProject.SERVICE.Option
{
    public class AppUserService : BaseService<AppUser>
    {
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="_username">Kullanıcı adı</param>
        ///// <param name="_password">Şifre</param>
        ///// <returns></returns>
        //public bool CheckCredentials(string _username, string _password)
        //{
        //    return Any(x => x.UserName == _username && x.Password == _password);
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_email">E-posta adresi</param>
        /// <param name="_password">Şifre</param>
        /// <returns></returns>
        public bool CheckCredentials(string _email, string _password)
        {
            return Any(x => x.Email == _email && x.Password == _password);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_email">E-posta adresi</param>
        /// <param name="_password">Şifre</param>
        /// <param name="_role">Yetki</param>
        /// <returns></returns>
        public bool CheckEmpoyeeUsers(string _email, string _password, Role _role)
        {
            return Any(x => x.Email == _email && x.Password == _password && x.Role == _role);
        }

        /// <summary>
        /// /
        /// </summary>
        /// <param name="_email">E-posta adresi</param>
        /// <returns></returns>
        public bool CheckEmail(string _email)
        {
            return Any(x => x.Email == _email);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_tcno"></param>
        /// <returns></returns>
        public bool CheckTCNO(string _tcno)
        {
            return Any(x => x.TCNO == _tcno);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appUser">AppUser In</param>
        /// <param name="errorMsg">Hata Mesaji</param>
        /// <param name="appUserOut">AppUser Out</param>
        /// <returns></returns>
        public bool CheckAgainEmailAddres(AppUser appUser, out string errorMsg, out AppUser appUserOut)
        {
            errorMsg = null;
            appUserOut = appUser;

            if (appUser.Email != GetById(appUser.ID).Email)
            {
                if (CheckEmail(appUser.Email))
                {
                    errorMsg = appUser.Email + " e-posta adresi, kayıtlarımızda mevcut.";
                    appUser.ImagePath = GetById(appUser.ID).ImagePath;
                    appUserOut = appUser;
                    return true;
                }
                return false;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appUser"></param>
        /// <param name="errorMsg"></param>
        /// <param name="appUserOut"></param>
        /// <param name="cEmailMsg"></param>
        /// <returns></returns>
        public bool CheckAgainEmailAddres(AppUser appUser, out string errorMsg, out AppUser appUserOut, out string cEmailMsg)
        {
            errorMsg = null;
            appUserOut = appUser;
            cEmailMsg = null;

            if (appUser.Email != GetById(appUser.ID).Email)
            {
                if (CheckEmail(appUser.Email))
                {
                    errorMsg = appUser.Email + " e-posta adresi, kayıtlarımızda mevcut.";
                    appUser.ImagePath = GetById(appUser.ID).ImagePath;
                    appUserOut = appUser;
                    return true;
                }
                cEmailMsg = "E-posta adresiniz, isteğiniz üzerine, " + appUser.Email + " şeklinde değiştirilmiştir: ";
                return false;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appUser">AppUser In</param>
        /// <param name="userDetailImagePath">userDetailImagePath</param>
        /// <param name="ImagePath">ImagePath</param>
        public void CheckImageFullEmpty(AppUser appUser, string userDetailImagePath, HttpPostedFileBase ImagePath)
        {
            if (ImagePath != null)
            {
                appUser.ImagePath = ImageUploader.UploadSingleImage("~/Uploads/Image/Users/", ImagePath);
                Update(appUser);
            }
            else
            {
                appUser.ImagePath = userDetailImagePath;
                Update(appUser);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appUser">AppUser appUser</param>
        /// <param name="userDetail">AppUser userDetail</param>
        /// <param name="ImagePath">ImagePath</param>
        /// <param name="cEmail">cEmail</param>
        /// <param name="cEmailMsg">cEmailMsg</param>
        public void CheckImageFullEmpty(AppUser appUser, AppUser userDetail, HttpPostedFileBase ImagePath, string cEmailMsg)
        {
            string subject = "Hesap Değişikliği";
            string cEmail = GetById(appUser.ID).Email;
            string body1 = "Sayın " + appUser.Name + " " + appUser.SurName + "," + "\n" + "İsteğiniz üzerine müşteri hesabınız değiştirilmiştir." + "\n" + "Bu hesap değiştirme işlemi: " + userDetail.Name + " " + userDetail.SurName + " (" + userDetail.Email + ") " + "tarafından isteğiniz üzerine yapılmıştır.";
            string body2 = "Sayın " + appUser.Name + " " + appUser.SurName + "," + "\n" + "İsteğiniz üzerine müşteri hesabınız değiştirilmiştir." + "\n" + cEmailMsg + "\n" + "Bu hesap değiştirme işlemi: " + userDetail.Name + " " + userDetail.SurName + " (" + userDetail.Email + ") " + "tarafından isteğiniz üzerine yapılmıştır.";

            if (ImagePath != null)
            {
                appUser.ImagePath = ImageUploader.UploadSingleImage("~/Uploads/Image/Users/", ImagePath);
            }
            else
            {
                appUser.ImagePath = userDetail.ImagePath;
            }

            Update(appUser);
            if (cEmailMsg == null)
            {
                MailSender.SendEmail(appUser.Email, body1, subject);
            }
            else
            {
                MailSender.SendEmail(cEmail, body2, subject);
                MailSender.SendEmail(appUser.Email, body2, subject);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appUser">AppUser In</param>
        /// <param name="errorMsg">Hata Mesaji</param>
        /// <param name="appUserOut">AppUser Out</param>
        /// <returns></returns>
        public bool CheckAgainUserChangeTCNO(AppUser appUser, out string errorMsg, out AppUser appUserOut)
        {
            errorMsg = null;
            appUserOut = appUser;

            if (GetById(appUser.ID).TCNO != appUser.TCNO)
            {
                if (CheckTCNO(appUser.TCNO))
                {
                    errorMsg = appUser.TCNO + " TCKNO, kayıtlarımızda mevcut.";
                    appUser.ImagePath = GetById(appUser.ID).ImagePath;
                    appUserOut = appUser;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Guid id</param>
        public void ResetPassword(Guid id)
        {
            AppUser appUser = GetById(id);
            appUser.Password = appUser.ConfirmPassword = Guid.NewGuid().ToString();
            appUser.ModifiedBy = "192.168.1.1";
            Update(appUser);

            string subject = "Şifreniz sıfırlandı";
            string body = "Sayın " + appUser.Name + " " + appUser.SurName + "," + "\n" + "İsteğiniz üzerine şifreniz sıfırlandı." + "\n" + "Yeni Şifreniz: " + appUser.Password + "\n" + "Giriş yaptıktan sonra lütfen şifrenizi değiştiriniz!";

            MailSender.SendEmail(appUser.Email, body, subject);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Guid id</param>
        /// <param name="userDetail">AppUser userDetail</param>
        public void ResetPassword(Guid id, AppUser userDetail)
        {
            AppUser appUser = GetById(id);
            appUser.Password = appUser.ConfirmPassword = Guid.NewGuid().ToString();
            appUser.ModifiedBy = userDetail.Email;
            Update(appUser);

            string subject = "Şifreniz sıfırlandı";
            string body = "Sayın " + appUser.Name + " " + appUser.SurName + "," + "\n" + "İsteğiniz üzerine şifreniz sıfırlandı." + "\n" + "Yeni Şifreniz: " + appUser.Password + "\n" + "Bu işlemi: " + userDetail.Name + " " + userDetail.SurName + " (" + userDetail.Email + ") " + "tarafından isteğiniz üzerine yapılmıştır." + "\n" + "Giriş yaptıktan sonra lütfen şifrenizi değiştiriniz!";

            MailSender.SendEmail(appUser.Email, body, subject);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mail"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public bool ForgotPassword(string mail, /*Role role,*/ out string errorMsg)
        {
            errorMsg = null;
            Guid id = Guid.Empty;

            if (mail == string.Empty)
            {
                errorMsg = "Lütfen alanları boş bırakmayın";
                return false;
            }
            else
            {
                if (CheckEmail(mail))
                {
                    id = GetAll().Find(x => x.Email == mail).ID;

                    ResetPassword(id);

                    //TODO: Role kontrollü yapılacak.

                    //if (role != GetById(id).Role)
                    //{
                    //    errorMsg = "Şifre başarılı bir şekilde sıfırlandı." + " Ancak, sıfrılamayı yanlış giriş panelinde yaptınız. " + "Bu panelden yetkiniz bulunmuyor.";
                    //}
                    return true;
                }
                else
                {
                    errorMsg = "Bu e-posta adresi kayıtlarımızda mevcut değildir.";
                    return false;
                }
            }
        }
    }
}