using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CpuEmulator.p16;
namespace EmulatorGui {
    public class RegisterView : IValueView {
        static NumberFormat bin = BinaryFormat.Instance32;
        static NumberFormat hex = HexadecimalFormat.Instance32;
        static NumberFormat dec = DecimalFormat.Instance;
        public RegisterView(Processor processor, uint register) {
            Processor = processor;
            Register  = register;
        }
        public Processor Processor { get; set; }
        public uint Register { get; set; }
        public override string ToString() {
            if (!Processor.ValidRegister(Register)) 
                return "N/A";

            StringBuilder builder = new StringBuilder(30);

            // Append register name
            builder.Append(names[Register]);

            // Append register value
            Processor.Get(Register, out ushort value);
            builder.Append(ValueToString(value));

            return builder.ToString();
        }

        public ushort Get() { 
            Processor.Get(Register, out ushort result);
            return result;
        }

        public void Set(ushort value) =>
            Processor.Set(Register, value);

        public static string ValueToString(ushort value) {
            StringBuilder builder = new StringBuilder(20);
            // BINARY
            builder.Append(" b");
            builder.Append(bin.To(value).Substring(16));
            
            // HEX
            builder.Append(" h");
            builder.Append(hex.To(value).Substring(4));

            builder.Append("; ");

            // Decimal
            builder.Append(' ');
            builder.Append(dec.To(value));
            return builder.ToString();
        }

        static string[] names = { 
            "GPR0", "GPR1", "GPR2", "GPR3",
            "GPR4", "GPR5", "GPR6", "GPR7",
            "GPR8", "GPR9", "GPRA", "GPRB",
            "GPRC", "GPRD", "GPRE", "GPRF",

            "IXR0", "IXR1", "IXR2", "IXR3",

            "  SP", "  SB", "  ST", "  PC",

            "IRR0", "IRR1", "IRR2", "IRR3",
            "IRR4", "IRR5", "IRR6", "IRR7",
        };
    }
}
