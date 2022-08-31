
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Common
{
    public static class Tools
    {
        public static string EncodingUTF8(string password)
        {
            Byte[] passBytes = Encoding.UTF8.GetBytes(password);
            string passE = "";
            foreach (byte b in passBytes)
                passE += b;
            return passE;
        }
        public static string ChangeStatus(string isActive)
        {
            if (isActive == "A")
                isActive = "I";
            else if (isActive == "I")
                isActive = "A";
            return isActive;
        }
        public static BaseResponse CheckPassword(string password)
        {
            if (password.Length < 8)
                return Response.InvalidPasswordResponse("password must have atleast 8 characters");
            if (!password.Any(ch => Char.IsDigit(ch)))
                return Response.InvalidPasswordResponse("password must have digit characters");
            if (!password.Any(ch => Char.IsLetter(ch)))
                return Response.InvalidPasswordResponse("password must have letter characters");
            if (!password.Any(ch => Char.IsLetterOrDigit(ch)))
                return Response.InvalidPasswordResponse("password must have special characters");
            if (!password.Any(ch => Char.IsUpper(ch)))
                return Response.InvalidPasswordResponse("password must have upper characters");
            if (!password.Any(ch => Char.IsLower(ch)))
                return Response.InvalidPasswordResponse("password must have lower characters");
            return null;
        }
    }
}
