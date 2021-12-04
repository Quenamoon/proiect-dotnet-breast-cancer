using System.Text.RegularExpressions;

namespace WebAPI.Utils.RegexUtils
{
    public class StringValidator
    {
        public static bool isValidEmail(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            return regex.Match(email).Success;
        }
    }
}