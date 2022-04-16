using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuEmulator {
    public class Memory {

        public Memory(int size_in_bytes) { 
            _data = new byte[size_in_bytes];
        }
        public byte[] Data { get => _data; private set => _data = value; }

        public byte this[uint index] { 
            get => (byte)(index < _data.Length ? _data[index] : 255);
            set { if (index < _data.Length) _data[index] = value; }
        }
        public uint Capacity => (uint)_data.Length;
        public bool CanAccess(uint address) => 
            address < _data.Length;
        public bool CanAccessRange(uint address, uint bytes) => 
            (address + bytes) <= _data.Length;
        
        //
        // Read Interface

        public uint Read(uint address, out byte output) {
            if (address < _data.Length) {
                output = _data[address + 0];
                return sizeof(byte);
            }
            // Reading failed
            output = 0;
            return 0;
        }
        public uint Read(uint address, out sbyte output) {
            if (address < _data.Length) {
                output = (sbyte)_data[address + 0];
                return sizeof(sbyte);
            }
            // Reading failed
            output = 0;
            return 0;
        }
        public uint Read(uint address, out ushort output) {
            if ((address + 1) < _data.Length) {
                output = 0;
                output |= (ushort)(_data[address + 0] << 0);
                output |= (ushort)(_data[address + 1] << 8);
                return sizeof(ushort);
            }
            // Reading failed
            output = 0;
            return 0;

        }
        public uint Read(uint address, out short output) {
            if ((address + 1) < _data.Length) {
                output = 0;
                output |= (short)(_data[address + 0] << 0);
                output |= (short)(_data[address + 1] << 8);
                return sizeof(short);
            }
            // Reading failed
            output = 0;
            return 0;
        }
        public uint Read(uint address, out uint output) {
            if ((address + 1) < _data.Length) {
                output = 0;
                output |= (uint)(_data[address + 0] << 0);
                output |= (uint)(_data[address + 1] << 8);
                output |= (uint)(_data[address + 2] << 16);
                output |= (uint)(_data[address + 3] << 24);
                return sizeof(uint);
            }
            // Reading failed
            output = 0;
            return 0;
        }
        public uint Read(uint address, out int output) {
            if ((address + 1) < _data.Length) {
                output = 0;
                output |= (_data[address + 0] << 0);
                output |= (_data[address + 1] << 8);
                output |= (_data[address + 2] << 16);
                output |= (_data[address + 3] << 24);

                return sizeof(int);
            }
            // Reading failed
            output = 0;
            return 0u;
        }
        public uint Read(uint address, uint bytes, out byte[]? output) {
            if (bytes == 0) { 
                output = null; 
                return 0; 
            }
            if (address >= _data.Length) { 
                output = null;
                return 0;
            }

            // Find end
            uint end = address + bytes;
            if (end > _data.Length) 
                end -= (uint)(end - _data.Length);

            // Create output
            output = new byte[end - address];

            // Copy to output
            for (uint i = address; i < end; i++)
                output[i] = _data[i];

            // Handle callbacks and return
            return end - address;
        }

        //
        // Write Interface

        public uint Write(uint address, byte value) {
            if ((address + 0) < _data.Length) {
                _data[address + 0] = value;

                return sizeof(byte);
            }
            // Writing failed
            return 0u;
        }
        public uint Write(uint address, sbyte value) {
            if ((address + 0) < _data.Length) {
                _data[address + 0] = (byte)value;

                return sizeof(sbyte);
            }
            // Writing failed
            return 0u;
        }
        public uint Write(uint address, ushort value) {
            if ((address + 1) < _data.Length) {
                _data[address + 0] = (byte)(value >> 0);
                _data[address + 1] = (byte)(value >> 8);

                return sizeof(ushort);
            }
            // Writing failed
            return 0u;
        }
        public uint Write(uint address, short value) {
            if ((address + 1) < _data.Length) {
                _data[address + 0] = (byte)(value >> 0);
                _data[address + 1] = (byte)(value >> 8);

                return sizeof(short);
            }
            // Writing failed
            return 0u;
        }
        public uint Write(uint address, uint value) {
            if ((address + 3) < _data.Length) {
                _data[address + 0] = (byte)(value >> 0);
                _data[address + 1] = (byte)(value >> 8);
                _data[address + 2] = (byte)(value >> 16);
                _data[address + 3] = (byte)(value >> 24);

                return sizeof(uint);
            }
            // Writing failed
            return 0u;
        }
        public uint Write(uint address, int value) {
            if ((address + 3) < _data.Length) {
                _data[address + 0] = (byte)(value >> 0);
                _data[address + 1] = (byte)(value >> 8);
                _data[address + 2] = (byte)(value >> 16);
                _data[address + 3] = (byte)(value >> 24);

                return sizeof(int);
            }
            // Writing failed
            return 0u;
        }
        public uint Write(uint address, byte[] values) {
            if (values == null || values.Length == 0) return 0u;
            if (address >= _data.Length) return 0u;
            

            // Find end
            uint end = address + (uint)values.Length;
            if (end > _data.Length) 
                end -= (uint)(end - _data.Length);

            // Copy to output
            for (uint i = address; i < end; i++)
                _data[i] = values[i];

            return end - address;
        }

        //
        // Resize Interface

        public void Resize(uint newSize) { 

            // Create new buffer
            byte[] newData = new byte[newSize];

            // Copy memory from old buffer
            uint addr = 0;
            while (addr < newSize && addr < Capacity) {
                newData[addr] = _data[addr];
                addr++;
            }

            // Assign buffer
            _data = newData;
        }

        byte[]        _data;
    }
}
