using System.Linq;

namespace S02E01
{
    internal class PasswordPolicy
    {
        public int MaxOccurrences { get; }
        public int MinOccurrences { get; }
        public char Character { get; }

        internal PasswordPolicy(string passwordLine)
        {
            string policyText = passwordLine.Split(": ")[0];
            MinOccurrences = int.Parse(policyText.Split(' ')[0].Split('-')[0]);
            MaxOccurrences = int.Parse(policyText.Split(' ')[0].Split('-')[1]);
            Character = policyText.Split(' ')[1].First();
        }

        internal bool IsValid(string password)
        {
            int characterCount = password.Count(ch => ch.Equals(Character));
            return characterCount >= MinOccurrences && characterCount <= MaxOccurrences;
        }
    }
}