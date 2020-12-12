using System;

namespace S09
{
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine("Let's fix that encoding error!");
            var xmasData = XmasData.Data;
            var xmasDataValidator = new XmasDataValidator(xmasData, 25);
            Console.WriteLine(xmasDataValidator.Validate()
                ? "Validation successful! WTF!?"
                : $"Validation failed! Failing number: {xmasDataValidator.FailingNumber}");
        }
    }
}
