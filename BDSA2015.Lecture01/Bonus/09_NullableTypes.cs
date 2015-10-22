using System;

namespace BDSA2015.Lecture01.Bonus
{
    public class NullableTypes
    {
        public void Operations()
        {
            int? numberA = null;
            int? numberB = 3;
            int? numberC;

            numberA++;                      // null
            numberC = numberA + numberB;    // null

            bool? b1 = null;
            bool? b2 = false;
            bool? b3 = true;

            // bool? == Nullable<bool>
            Nullable<bool> b4;
        }

        public void Conversions()
        {
            int? numA = 3;
            int? numB = null;
            int numC = 5;
            int numD = 4;

            numA = numD;    // implicit conversion from int to int?

            numC = (int) numA;    // numC = numA.Value();
            numC = (int) numB;    // throws InvalidOperationException
        }

        public void NullCoalescingOperator()
        {
            int? val1 = null;
            int? val2 = 4;

            int? val3 = val1 ?? val2 ?? 0;

            if (val1.HasValue)
            {
                val3 = val1;
            }
            else
            {
                val3 = val2;
            }
        }
    }
}
