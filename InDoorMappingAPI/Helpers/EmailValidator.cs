using System.Text.RegularExpressions;

namespace InDoorMappingAPI.Helpers
{
    public static class EmailValidator
    {
        private static readonly Regex _isepRegex = new Regex(@"^\d{7}@isep\.ipp\.pt$", RegexOptions.Compiled);

        public static bool IsValidIsepEmail(string email)
        {
            return _isepRegex.IsMatch(email);
        }
    }

}
