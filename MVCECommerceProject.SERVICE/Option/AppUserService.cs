using MVCECommerceProject.MODEL.Entities;
using MVCECommerceProject.MODEL.Enums;
using MVCECommerceProject.SERVICE.Base;

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

        public bool CheckEmail(string _email)
        {
            return Any(x => x.Email == _email);
        }

        public bool CheckTCNO(string _tcno)
        {
            return Any(x => x.TCNO == _tcno);
        }
    }
}