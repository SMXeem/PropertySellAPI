using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace RealState.Manager
{
    /// <summary>
    /// Common Class
    /// </summary>
    public class Common
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string Encrypt(string plainText)
        {
            if (plainText == null) throw new ArgumentNullException(nameof(plainText));

            //encrypt data
            var data = Encoding.Unicode.GetBytes(plainText);

            //return as base64 string
            return Convert.ToBase64String(data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cipher"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public string Decrypt(string cipher)
        {
            if (cipher == null) throw new ArgumentNullException(nameof(cipher));

            //parse base64 string
            byte[] data = Convert.FromBase64String(cipher);

            return Encoding.Unicode.GetString(data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aPhoto"></param>
        /// <returns></returns>
        public static string SaveImage(HttpPostedFile aPhoto)
        {
            var imageName = Path.GetFileNameWithoutExtension(aPhoto.FileName);
            string extension = Path.GetExtension(aPhoto.FileName);
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + extension;
            var imagePath = "~/Image/" + imageName;
            imageName = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Image/"), imageName);
            aPhoto.SaveAs(imageName);
            return imagePath;
        }
    }
}