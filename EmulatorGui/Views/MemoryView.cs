using CpuEmulator.p16;
using System.Text;

namespace EmulatorGui {
    public class MemoryView : IValueView {
        public MemoryView(CpuEmulator.Memory memory, uint address) {
            Memory  = memory;
            Address = address;
        }
        public CpuEmulator.Memory Memory { get; set; }
        public uint Address { get; set; }
        public override string ToString() {
            if (!Memory.CanAccessRange(Address, 2))
                return "N/A";

            StringBuilder builder = new StringBuilder(30);

            // Append address name
            builder.Append(Address.ToString("X4"));

            // Append memory value
            Memory.Read(Address, out ushort value);
            builder.Append(ValueToString(value));

            return builder.ToString();
        }
        public string ValueToString(ushort value) {
            StringBuilder builder = new StringBuilder(20);
            byte lsb = (byte)(((value >> 0) & 0xFF));
            byte msb = (byte)(((value >> 8) & 0xFF));
            // BINARY + HEX LSB
            builder.Append(" b");
            builder.Append(Utility.ToBin(lsb));


            builder.Append(" h");
            builder.Append((lsb).ToString("X2"));

            builder.Append("; ");

            // BINARY + HEX MSB
            builder.Append(" b");
            builder.Append(Utility.ToBin(msb));


            builder.Append(" h");
            builder.Append((msb).ToString("X2"));

            builder.Append("; ");

            // Decimal
            builder.Append(' ');
            builder.Append(value.ToString("00000"));
            return builder.ToString();
        }
        public ushort Get() =>
             (ushort)(Memory.Read(Address, out ushort value) == 2 ? value : 0);
        public void Set(ushort value) =>
            Memory.Write(Address, value);
        
    }
}
