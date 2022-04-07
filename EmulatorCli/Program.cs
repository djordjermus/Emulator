using CpuEmulator;
using CpuEmulator.p16;
class Program {
    public static void Main(string[] args) {
        Memory    memory           = new Memory(8192);
        Processor processor        = new Processor(memory);
        Instruction[] instructions = new Instruction[64];
        ushort a = 0;
        ushort b = 0;
        unchecked {
            a = (ushort)12;
            b = (ushort)5;
        }
        instructions[0] = EncoderDecoder.LoadUB(
            Mode.immediate, 0, 
            Mode.immediate, a);
        instructions[1] = EncoderDecoder.Load(
            Mode.immediate, 1, 
            Mode.immediate, b);

        instructions[2] = EncoderDecoder.Add(
            Mode.immediate, 2,
            Mode.register,  0,
            Mode.register,  1);
        instructions[3] = EncoderDecoder.Subtract(
            Mode.immediate, 3,
            Mode.register,  0,
            Mode.register,  1);
        instructions[4] = EncoderDecoder.Multiply(
            Mode.immediate, 4,
            Mode.register,  0,
            Mode.register,  1);
        instructions[5] = EncoderDecoder.Divide(
            Mode.immediate, 5,
            Mode.register,  0,
            Mode.register,  1);

        instructions[6] = EncoderDecoder.BitwiseAnd(
            Mode.immediate, 6,
            Mode.register,  0,
            Mode.register,  1);
        instructions[7] = EncoderDecoder.BitwiseOr(
            Mode.immediate, 7,
            Mode.register,  0,
            Mode.register,  1);
        instructions[8] = EncoderDecoder.BitwiseXor(
            Mode.immediate, 8,
            Mode.register,  0,
            Mode.register,  1);
        instructions[9] = EncoderDecoder.Invert(
            Mode.immediate, 9,
            Mode.register,  0);
        uint encAddr = 0;

        // Enocode instructions 
        for (int i = 0; i < instructions.Length; i++)
            encAddr += EncoderDecoder.Encode(memory, encAddr, ref instructions[i]);

        // Execute instructions
        for (int i = 0; i < instructions.Length; i++) {
            processor.Execute();
        }

        Console.WriteLine("Done");

    }

}