using System;

namespace BDSA2015.Lecture01.Bonus
{
    public class Class
    {
        public const int Number = 42;

        private int _field = 0;

        private string _propertyWithBackingField;

        public string PropertyWithBackingField
        {
            get { return _propertyWithBackingField; }
            set { _propertyWithBackingField = value; }
        }

        public int Property { get; set; }

        private readonly string _readonlyField;

        public string ReadOnlyProperty1
        {
            get { return _readonlyField; }
        }

        public int ReadOnlyProperty2 { get; } = 42;

        public int ReadOnlyProperty3 { get; }

        public string PrivateSetter { get; private set; }
        public string PrivateGetter { private get; set; }

        public Class(string readonlyField)
        {
            _readonlyField = readonlyField;

            ReadOnlyProperty3 = 42;
        }

        public string Method()
        {
            return "stuff";
        }

        public void Command(string word)
        {
            Console.WriteLine(word);
        }

        public void Command2(string word) => Console.WriteLine(word);
    }
}
