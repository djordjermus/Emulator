using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuEmulator.p16 {
    public partial class EncoderDecoder {
        public static Instruction FromAsm(string str, out bool success) {
            success = false;
            str = str.ToLower();
            string[] components = str.Split(
                ' ', 
                StringSplitOptions.TrimEntries | 
                StringSplitOptions.RemoveEmptyEntries);

            uint elem = (uint)components.Length;
            
            // BAD OP COUNT
            if (elem > 4) return new Instruction();

            return new Instruction();
        }

        public static string ToAsm(ref Instruction instruction) { 
            StringBuilder sb = new StringBuilder();

            return sb.ToString();
        }

        
    }
}
