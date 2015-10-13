using System;
using System.Collections.Generic;

namespace RandomExtensions.System
{
    public static class RandomExtensions
    {
        public static T Choose<T>(this Random rand, List<T> list) => list[rand.Next(list.Count)];
    }
}
