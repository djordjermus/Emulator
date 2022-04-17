using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuEmulator.p16 {
    //40 instrukcija
    public enum OpCode : ushort {

        // X => instruction
        // Y => operand count
        // A/B/C => addressing mode of op1/2/3
        // * => unused
        //          XXXXXX_YY_AABBCC**
        noop    = 0b0000_00_00_00000000,
        
        // Memory management

        load    = 0b0001_00_00_00000000, // Loads word
        loadub  = 0b0001_01_00_00000000, // Load unsigned byte
        loadsb  = 0b0001_10_00_00000000, // Load signed byte

        store   = 0b0010_00_00_00000000, // Stores word to memory
        storelb = 0b0010_01_00_00000000, // Stores lower byte to memory
        storehb = 0b0010_10_00_00000000, // Stores higher byte to memory

        push    = 0b0011_00_00_00000000, // Pushes word onto stack
        pushlb  = 0b0011_01_00_00000000, // Pushes lower byte onto stack
        pushhb  = 0b0011_10_00_00000000, // Pushes heigher byte onto stack

        pop     = 0b0100_00_00_00000000, // Pops word off of stack
        popub   = 0b0100_01_00_00000000, // Post unsigned byte off of stack
        popsb   = 0b0100_10_00_00000000, // Post signed byte off of stack

        // Arithmetic

        add     = 0b0101_00_00_00000000,
        sub     = 0b0101_01_00_00000000,
        mul     = 0b0101_10_00_00000000,
        div     = 0b0101_11_00_00000000,



        // Bitwise

        band    = 0b0110_00_00_00000000, // Bitwise and
        bor     = 0b0110_01_00_00000000, // Bitwise or
        bxor    = 0b0110_10_00_00000000, // Bitwise xor
        binv    = 0b0110_11_00_00000000, // Bitwise not
        lsr     = 0b0111_00_00_00000000, // Logical shift right
        lsl     = 0b0111_01_00_00000000, // Logical shift left

        // Logical

        and     = 0b1000_00_00_00000000, // and
        or      = 0b1000_01_00_00000000, // or
        xor     = 0b1000_10_00_00000000, // xor
        not     = 0b1000_11_00_00000000, // not

        // Comparison
        
        eq      = 0b1001_00_00_00000000, // Equals
        neq     = 0b1001_01_00_00000000, // Not Equals
        ugt     = 0b1001_10_00_00000000, // Unsigned greater than
        ult     = 0b1001_11_00_00000000, // Unsigned lesser than
        sgt     = 0b1010_00_00_00000000, // Signed greater than
        slt     = 0b1010_01_00_00000000, // Signed lesser than
        tst     = 0b1010_10_00_00000000, // Test(SF I ZF)

        // Jumps

        jmp     = 0b1011_00_00_00000000, // Jump unconditionally
        jeq     = 0b1011_01_00_00000000, // Jump if two operands are equal
        jne     = 0b1011_10_00_00000000, // Jump if two operands are not equal
        rjmp    = 0b1100_00_00_00000000, // Relative jump unconditionally
        rjeq    = 0b1100_01_00_00000000, // Relative jump if two operands are equal
        rjne    = 0b1100_10_00_00000000, // Relative jump if two operands are not equal
    }
}
