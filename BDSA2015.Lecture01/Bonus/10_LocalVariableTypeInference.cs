using System;
using System.Collections.Generic;

namespace BDSA2015.Lecture01.Bonus
{
    public static class LocalVariableTypeInference
    {
        // var field = "Blue";

        public static void M()
        {
            var age = 25;       // inferred type int
            var flag = false;   // inferred type bool

            var dict = new Dictionary<int, string>();

            object[] objects = {3, "Hello", 5.6};
            foreach (var val in objects)
            {
                Console.WriteLine(val);
            }
        }
    }
}
