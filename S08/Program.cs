using System;

namespace S08
{
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine("Let's get that program working!");
            int accumulator = Helpers.RunProgram();
            Console.WriteLine($"Accumulator: {accumulator}");
        }
    }
}
