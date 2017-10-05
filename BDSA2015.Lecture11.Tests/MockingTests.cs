using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;

namespace BDSA2015.Lecture11.Tests
{
    [TestClass]
    public class MockingTests
    {
        [TestMethod]
        public void ManualMockAnimal()
        {
            var animal = new MockAnimal();

            Assert.AreEqual("Mock", animal.Name);

            animal.Speak();

            Assert.AreEqual("I'm a mock", WriterValue());
        }

        [TestMethod]
        public void ManualStubAnimal()
        {
            var animal = new StubAnimal();

            Assert.AreEqual(null, animal.Name);

            animal.Speak();

            Assert.AreEqual(string.Empty, WriterValue());
        }

        [TestMethod]
        public void AutoStubAnimal()
        {
            var mock = new Mock<IAnimal>();

            var animal = mock.Object;

            Assert.AreEqual(null, animal.Name);

            animal.Speak();

            Assert.AreEqual(string.Empty, WriterValue());
        }

        [TestMethod]
        public void AutoMockAnimal()
        {
            var mock = new Mock<IAnimal>();
            mock.Setup(a => a.Name).Returns("Wolf");
            mock.Setup(a => a.Speak()).Callback(() => Console.WriteLine("Howl"));

            var animal = mock.Object;

            Assert.AreEqual("Wolf", animal.Name);

            animal.Speak();

            Assert.AreEqual("Howl", WriterValue());
        }

        [TestMethod]
        public void RuntimeMockAnimal()
        {
            var animal = CreateCow();

            Assert.AreEqual("Cow", animal.Name);

            animal.Speak();

            Assert.AreEqual("Moo", WriterValue());
        }

        private StringWriter _writer;

        public string WriterValue()
        {
            return _writer.GetStringBuilder().ToString().TrimEnd();
        }

        [TestInitialize]
        public void Initialize()
        {
            _writer = new StringWriter();
            Console.SetOut(_writer);
        }

        public IAnimal CreateCow()
        {
            var assembly = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName("DynamicAssembly"), AssemblyBuilderAccess.Run);
            var module = assembly.DefineDynamicModule("DynamicModule");
            var type = module.DefineType("DynamicType", TypeAttributes.Public | TypeAttributes.Class);
            type.AddInterfaceImplementation(typeof(IAnimal));

            var property = type.DefineProperty("Name", PropertyAttributes.HasDefault, typeof(string), null);

            var get = type.DefineMethod("get_Name", MethodAttributes.Private | MethodAttributes.Virtual, typeof(string), Type.EmptyTypes);
            var getGenerator = get.GetILGenerator();
            getGenerator.Emit(OpCodes.Ldstr, "Cow");
            getGenerator.Emit(OpCodes.Ret);

            property.SetGetMethod(get);

            type.DefineMethodOverride(get, typeof(IAnimal).GetProperty("Name").GetGetMethod());

            var speak = type.DefineMethod("Speak", MethodAttributes.Public | MethodAttributes.Virtual, typeof(void), Type.EmptyTypes);
            var speakGenerator = speak.GetILGenerator();
            speakGenerator.EmitWriteLine("Moo");
            speakGenerator.Emit(OpCodes.Ret);

            type.DefineMethodOverride(speak, typeof(IAnimal).GetMethod("Speak"));

            var t = type.CreateType();

            var cow = Activator.CreateInstance(t) as IAnimal;

            return cow;
        }
    }

    public interface IAnimal
    {
        string Name { get; }

        void Speak();
    }

    public class Duck : IAnimal
    {
        public string Name => "Duck";

        public void Speak()
        {
            Console.WriteLine("Quack");
        }
    }

    public class StubAnimal : IAnimal
    {
        public string Name => null;

        public void Speak()
        {
        }
    }

    public class MockAnimal : IAnimal
    {
        public string Name => "Mock";

        public void Speak()
        {
            Console.WriteLine("I'm a mock");
        }
    }
}
