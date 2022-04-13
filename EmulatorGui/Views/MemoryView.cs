using CpuEmulator.p16;
using System.Text;

namespace EmulatorGui {
    public class MemoryView : IValueView {
        static NumberFormat bin8 = BinaryFormat.Instance8;
        static NumberFormat hex8 = HexadecimalFormat.Instance8;
        static NumberFormat dec  = DecimalFormat.Instance;
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
            builder.Append(bin8.To(lsb));


            builder.Append(" h");
            builder.Append(hex8.To(lsb));

            builder.Append("; ");

            // BINARY + HEX MSB
            builder.Append(" b");
            builder.Append(bin8.To(msb));


            builder.Append(" h");
            builder.Append(hex8.To(msb));

            builder.Append("; ");

            // Decimal
            builder.Append(' ');
            builder.Append(dec.To(value));
            return builder.ToString();
        }
        public ushort Get() =>
             (ushort)(Memory.Read(Address, out ushort value) == 2 ? value : 0);
        public void Set(ushort value) =>
            Memory.Write(Address, value);
        
    }
}
