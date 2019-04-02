namespace Guesthouse.Core.Utils
{
    public static class ConstValues
    {
        public const int PASSWORD_MIN_LENGTH = 8;
        public const int PASSWORD_MAX_LENGTH = 32;
        public const string CLIENT_DEFAULT_ROLE = "User";
        public const string PHONE_NUMBER_REGEX = @"(?<!\w)(\(?(\+|00)?48\)?)?[ -]?\d{3}[ -]?\d{3}[ -]?\d{3}(?!\w)";
        public const string COMPANY_NAME = "My Guesthouse";
    }
}