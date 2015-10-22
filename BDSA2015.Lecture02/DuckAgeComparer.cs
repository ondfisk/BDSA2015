﻿using System;
using System.Collections.Generic;

namespace BDSA2015.Lecture02
{
    public class DuckAgeComparer : IComparer<Duck>
    {
        public int Compare(Duck x, Duck y)
        {
            if (x.Age < y.Age)
            {
                return -1;
            }
            if (x.Age > y.Age)
            {
                return 1;
            }
            return 0;
        }
    }
}
