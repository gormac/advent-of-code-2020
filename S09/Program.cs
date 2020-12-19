using System;

namespace S09
{
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine("Let's fix that encoding error!");
            Console.WriteLine("Validating Xmas data...");
            
            var xmasData = XmasData.Data;
            var xmasDataValidator = new XmasDataValidator(xmasData, 25);
            var validationSuccess = xmasDataValidator.Validate();
            
            Console.WriteLine(validationSuccess
                ? "Validation successful! WTF!?"
                : $"Validation failed! Failing number: {xmasDataValidator.InvalidNumber}");

            if (validationSuccess) return;
            
            try
            {
                Console.WriteLine("Find weakness...");
                var (min, max) = xmasDataValidator.FindWeakness(xmasDataValidator.InvalidNumber);
                Console.WriteLine($"Encryption weakness based on invalid number {xmasDataValidator.InvalidNumber} = {min} + {max} = {min + max}.");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
