namespace S02E01
{
    internal class Password
    {
        private readonly PasswordPolicy _policy;
        private readonly string _password;

        internal Password(string passwordLine)
        {
            _policy = new PasswordPolicy(passwordLine);
            _password = ParsePassword(passwordLine);
        }

        private static string ParsePassword(string passwordLine)
        {
            return passwordLine.Split(": ")[1];
        }

        internal bool IsValid() => _policy.IsValid(_password);
    }
}