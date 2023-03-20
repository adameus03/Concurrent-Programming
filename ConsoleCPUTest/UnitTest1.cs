using NUnit.Framework;
using ConsoleCPU;

namespace ConsoleCPUTest
{
    public class Tests
    {
        private CPU cpu;
        [SetUp]
        public void Setup()
        {
            this.cpu = new CPU();
        }

        [Test]
        public void TestPowerOn()
        {
            cpu.PowerOn();
            Assert.AreEqual(true, cpu.IsPowered);
        }
        [Test]
        public void TestPowerOff()
        {
            cpu.PowerOff();
            Assert.AreEqual(false, cpu.IsPowered);
        }
        [Test]
        public void TestAdd()
        {
            cpu.Mov(CPU.Registers.ECX, 5);
            cpu.Mov(CPU.Registers.EDX, 6);
            cpu.Add(CPU.Registers.ECX, CPU.Registers.EDX);
            Assert.AreEqual(11, cpu.GetRegisterValue(CPU.Registers.ECX));
        }
        [Test]
        public void TestSub()
        {
            cpu.Mov(CPU.Registers.ECX, 56);
            cpu.Mov(CPU.Registers.EDX, 10);
            cpu.Sub(CPU.Registers.ECX, CPU.Registers.EDX);
            Assert.AreEqual(46, cpu.GetRegisterValue(CPU.Registers.ECX));
        }
        [Test]
        public void TestMul()
        {
            cpu.Mov(CPU.Registers.EAX, 15);
            cpu.Mov(CPU.Registers.EBX, 3);
            cpu.Mul(CPU.Registers.EBX);
            Assert.AreEqual(45, cpu.GetRegisterValue(CPU.Registers.EAX));
        }
        [Test]
        public void TestDiv()
        {
            cpu.Mov(CPU.Registers.EAX, 15);
            cpu.Mov(CPU.Registers.EBX, 4);
            cpu.Div(CPU.Registers.EBX);
            Assert.AreEqual(3, cpu.GetRegisterValue(CPU.Registers.EAX));
            Assert.AreEqual(3, cpu.GetRegisterValue(CPU.Registers.EDX));
        }
        [Test]
        public void TestMov()
        {
            cpu.Mov(CPU.Registers.EAX, 14);
            Assert.AreEqual(14, cpu.GetRegisterValue(CPU.Registers.EAX));
        }
        [Test]
        public void TestCmp()
        {
            cpu.Mov(CPU.Registers.EAX, 4);
            cpu.Mov(CPU.Registers.EBX, 4);
            cpu.Cmp(CPU.Registers.EAX, CPU.Registers.EBX);
            Assert.AreEqual(true, cpu.ZeroFlag);
            cpu.Mov(CPU.Registers.EBX, 5);
            cpu.Cmp(CPU.Registers.EAX, CPU.Registers.EBX);
            Assert.AreEqual(false, cpu.ZeroFlag);
        }
        [Test]
        public void TestJmp()
        {
            cpu.Jmp(5);
            Assert.AreEqual(5, cpu.GetRegisterValue(CPU.Registers.IP));
        }
        [Test]
        public void TestNop()
        {
            cpu.PowerOff();
            cpu.PowerOn();
            cpu.Nop();
            Assert.AreEqual(1, cpu.GetRegisterValue(CPU.Registers.IP));
        }
        [Test]
        public void TestJz()
        {
            cpu.Mov(CPU.Registers.EAX, 4);
            cpu.Mov(CPU.Registers.EBX, 4);
            cpu.Cmp(CPU.Registers.EAX, CPU.Registers.EBX);
            cpu.Jz(5);
            Assert.AreEqual(5, cpu.GetRegisterValue(CPU.Registers.IP));
            cpu.Mov(CPU.Registers.EBX, 5);
            cpu.Cmp(CPU.Registers.EAX, CPU.Registers.EBX);
            cpu.Jz(10);
            Assert.AreEqual(8, cpu.GetRegisterValue(CPU.Registers.IP));
        }
        [Test]
        public void TestInc()
        {
            cpu.Mov(CPU.Registers.EBX, 5);
            cpu.Inc(CPU.Registers.EBX);
            Assert.AreEqual(6, cpu.GetRegisterValue(CPU.Registers.EBX));

        }
        [Test]
        public void TestDec()
        {
            cpu.Mov(CPU.Registers.EBX, 5);
            cpu.Dec(CPU.Registers.EBX);
            Assert.AreEqual(4, cpu.GetRegisterValue(CPU.Registers.EBX));
        }

    }
}