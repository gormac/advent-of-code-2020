using System.Linq;

namespace S02E01
{
    internal class PasswordPolicy
    {
        public int FirstOccurrenceIndex { get; }
        public int SecondOccurrenceIndex { get; }
        public char Character { get; }

        internal PasswordPolicy(string passwordLine)
        {
            string policyText = passwordLine.Split(": ")[0];
            FirstOccurrenceIndex = int.Parse(policyText.Split(' ')[0].Split('-')[0]) - 1;
            SecondOccurrenceIndex = int.Parse(policyText.Split(' ')[0].Split('-')[1]) - 1;
            Character = policyText.Split(' ')[1].First();
        }

        internal bool IsValid(string password)
            => password[FirstOccurrenceIndex].Equals(Character) ^ password[SecondOccurrenceIndex].Equals(Character);
    }
}