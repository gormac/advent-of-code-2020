namespace S08
{
    public class Instruction
    {
        public Instruction(string programLine)
        {
            Operation = programLine.Split(' ')[0];
            Argument = int.Parse(programLine.Split(' ')[1]);
        }

        public int Argument { get; }

        public int HitCount { get; private set; }

        public string Operation { get; }

        public int Execute()
        {
            HitCount++;

            switch (Operation)
            {
                case "acc":
                    Helpers.Accumulator += Argument;
                    break;
                case "jmp":
                    return Argument;
                case "nop":
                    break;
            }

            return 1;
        }
    }
}
