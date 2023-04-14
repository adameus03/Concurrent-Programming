using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCPU
{
    public class CPU
    {
        private uint eax = 0;
        private uint ebx = 0;
        private uint ecx = 0;
        private uint edx = 0;
        private uint ip = 0;

        private bool zeroFlag = false;

        private bool isPowered = false;

        public enum Registers { EAX, EBX, ECX, EDX, IP };

        public CPU()
        {

        }

        public void PowerOn()
        {
            this.isPowered = true;
            this.ip = 0;
        }
        public void PowerOff()
        {
            this.isPowered = false;
            this.ip = 0;
        }



        public void Add(Registers r1, Registers r2)
        {
            SetRegisterValue(r1, GetRegisterValue(r1) + GetRegisterValue(r2));
            this.ip++;
        }
        public void Sub(Registers r1, Registers r2)
        {
            SetRegisterValue(r1, GetRegisterValue(r1) - GetRegisterValue(r2));
            this.ip++;
        }
        public void Mul(Registers r)
        {
            this.eax *= GetRegisterValue(r);
            this.ip++;
        }
        public void Div(Registers r)
        {
            this.edx = this.eax % GetRegisterValue(r);
            this.eax /= GetRegisterValue(r);
            this.ip++;
        }

        public void Mov(Registers r, uint v)
        {
            SetRegisterValue(r, v);
            this.ip++;
        }
        public void Cmp(Registers r1, Registers r2)
        {
            this.zeroFlag = GetRegisterValue(r1) == GetRegisterValue(r2);
            this.ip++;
        }
        public void Jmp(uint addr)
        {
            SetRegisterValue(Registers.IP, addr);
        }
        public void Nop()
        {
            this.ip++;
        }
        public void Jz(uint addr)
        {
            if (this.zeroFlag)
            {
                SetRegisterValue(Registers.IP, addr);
            }
            else this.ip++;
        }
        public void Inc(Registers r)
        {
            SetRegisterValue(r, GetRegisterValue(r) + 1);
            this.ip++;
        }
        public void Dec(Registers r)
        {
            SetRegisterValue(r, GetRegisterValue(r) - 1);
            this.ip++;
        }



        public uint GetRegisterValue(Registers r)
        {
            if (r == Registers.EAX)
            {
                return this.eax;
            }
            else if (r == Registers.EBX)
            {
                return this.ebx;
            }
            else if (r == Registers.ECX)
            {
                return this.ecx;
            }
            else if (r == Registers.EDX)
            {
                return this.edx;
            }
            return this.ip;
        }
        private void SetRegisterValue(Registers r, uint value)
        {
            if (r == Registers.EAX)
            {
                this.eax = value;
            }
            else if (r == Registers.EBX)
            {
                this.ebx = value;
            }
            else if (r == Registers.ECX)
            {
                this.ecx = value;
            }
            else if (r == Registers.EDX)
            {
                this.edx = value;
            }
            else this.ip = value;
        }

        public uint Eax => eax;
        public uint Ebx => ebx;
        public uint Ecx => ecx;
        public uint Edx => edx;
        public uint Ip => ip;

        public bool ZeroFlag => zeroFlag;

        public bool IsPowered => isPowered;

    }
}
