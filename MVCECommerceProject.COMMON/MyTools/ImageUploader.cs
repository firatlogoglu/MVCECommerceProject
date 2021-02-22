using System;
using System.IO;
using System.Web;

namespace MVCECommerceProject.COMMON.MyTools
{
    public class ImageUploader
    {
        /*
           1=> dosya zaten var.
           2=> dosya tipi yanlış
           3=> dosya boş.
        */

        //TODO: Güncellemede dosya boş olarak kaydediyor.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverPath">Sunucu Yolu</param>
        /// <param name="file">Dosya</param>
        /// <returns></returns>
        public static string UploadSingleImage(string serverPath, HttpPostedFileBase file)
        {
            if (file != null)
            {
                var uniqueName = Guid.NewGuid();
                serverPath = serverPath.Replace("~", string.Empty);

                var fileArray = file.FileName.Split('.');
                string extension = fileArray[fileArray.Length - 1].ToLower();
                string fileName = uniqueName + "." + extension;

                if (extension == "jpg" || extension == "png" || extension == "gif" || extension == "jpeg")
                {
                    if (File.Exists(HttpContext.Current.Server.MapPath(serverPath + fileName)))
                    {
                        //TODO: Dosya zaten var, dosya ismini guid olarak verdiğimizden dolayı yakalayamıyor.
                        return "1";
                    }
                    else
                    {
                        var filePath = HttpContext.Current.Server.MapPath(serverPath + fileName);
                        file.SaveAs(filePath);
                        return serverPath + fileName;
                    }
                }
                else
                {
                    return "2";
                }
            }
            else
            {
                return "3";
            }
        }
    }
}