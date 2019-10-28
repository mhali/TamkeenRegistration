using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.SessionState;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;

namespace TamkeenRegistration
{
    public static class SharedUtilities 
    {
        public const string SqlConnection = @"Data Source=localhost;Initial Catalog=TamkeenRegistration;Integrated Security=true;";
        const int SALT_SIZE = 12; // size in bytes
        const int HASH_SIZE = 32; // size in bytes
        const int ITERATIONS = 30000; // number of pbkdf2 iterations

        public static bool AutheticateOldCredentials(string saltString, string passwordHash, string password)
        {

            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            //var salt = Encoding.ASCII.GetBytes("VxEZbwrVrleU");
            var salt = Encoding.ASCII.GetBytes(saltString);

            // Generate the hash
            //Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes("P@ssw0rd2018", salt, ITERATIONS, HashAlgorithmName.SHA256);
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, ITERATIONS, HashAlgorithmName.SHA256);
            var hash = pbkdf2.GetBytes(HASH_SIZE);

            var iterationCountBtyeArr = BitConverter.GetBytes(ITERATIONS);

            var valueToSave = new byte[HASH_SIZE];
            Buffer.BlockCopy(hash, 0, valueToSave, 0, HASH_SIZE);

            var hashValue = Convert.ToBase64String(valueToSave); 

            if (hashValue == passwordHash)
                return true;

            return false;
            //Console.WriteLine(hashValue);
        }

        public static void LoadFromCookies(HttpSessionState Session, HttpRequest Request)
        {
            if (Session["AccountType"] == null)
            {
                Session["User"] = Request.Cookies["User"].Value;
                Session["AccountType"] = Request.Cookies["AccountType"].Value;
                Session["ID"] = Request.Cookies["ID"].Value;
                Session["IsAdmin"] = Request.Cookies["IsAdmin"].Value;
                Session["IsSocialMediaAdmin"] = Request.Cookies["IsSocialMediaAdmin"].Value;
                Session["IsRegistrationAdmin"] = Request.Cookies["IsRegistrationAdmin"].Value;
                Session["IsBudgetAdmin"] = Request.Cookies["IsBudgetAdmin"].Value;
                Session["IsSubBudgetAdmin"] = Request.Cookies["IsSubBudgetAdmin"].Value;
                Session["IsTaskManagementAdmin"] = Request.Cookies["IsTaskManagementAdmin"].Value;
                Session["NickName"] = Request.Cookies["NickName"].Value;
            }
        }

        public static string GetCurrentUser(HttpSessionState Session)
        {
            return Session["User"].ToString();
        }

        public static bool HasAnyAdminRights(HttpSessionState Session)
        {
            if (Session["IsAdmin"].ToString() == "True"
                || Session["IsSocialMediaAdmin"].ToString() == "True"
                || Session["IsRegistrationAdmin"].ToString() == "True"
                || Session["IsBudgetAdmin"].ToString() == "True"
                || Session["IsSubBudgetAdmin"].ToString() == "True"
                || Session["IsTaskManagementAdmin"].ToString() == "True"
                )
            {
                return true;
            }

            return false;
        }

        public static bool HasRegistrationAdminRights(HttpSessionState Session)
        {
            if (Session["IsAdmin"].ToString() == "True"
                || Session["IsRegistrationAdmin"].ToString() == "True"
                )
            {
                return true;
            }

            return false;
        }

        public static bool HasSocialMediaAdminRights(HttpSessionState Session)
        {
            if (Session["IsAdmin"].ToString() == "True"
                || Session["IsSocialMediaAdmin"].ToString() == "True"
                )
            {
                return true;
            }

            return false;
        }

        public static bool HasBudgetAdminRights(HttpSessionState Session)
        {
            if (Session["IsAdmin"].ToString() == "True"
                || Session["IsBudgetAdmin"].ToString() == "True"
                )
            {
                return true;
            }

            return false;
        }
        public static bool HasSubBudgetAdminRights(HttpSessionState Session)
        {
            if (Session["IsAdmin"].ToString() == "True"
                || Session["IsSubBudgetAdmin"].ToString() == "True"
                )
            {
                return true;
            }

            return false;
        }
        public static bool HasParentRights(HttpSessionState Session)
        {
            if (Session["AccountType"].ToString() == "Family")
            {
                return true;
            }

            return false;
        }

        public static bool HasTamkeenerRights(HttpSessionState Session)
        {
            if (Session["AccountType"].ToString() == "Tamkeener")
            {
                return true;
            }

            return false;
        }

    }
}