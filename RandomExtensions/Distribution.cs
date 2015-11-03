using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace HermansGameDev.RandomExtensions
{
    public class Distribution<T>
    {
        private Random _rand;
        private Dictionary<Range, T> _ranges;
        private Dictionary<T, int> _distribution; 

        internal Distribution(Random rand, Dictionary<T, int> distribution)
        {
            _rand = rand;
            _distribution = distribution;
            _ranges = DistributionToRanges(_distribution);
        }

        [Pure]
        private static Dictionary<Range, T> DistributionToRanges(Dictionary<T, int> distribution)
        {
            var ranges = new Dictionary<Range, T>();

            int total = 0;
            foreach (var kv in distribution) {
                var min = total;
                total += kv.Value;
                var max = total;
                ranges.Add(new Range(min, max), kv.Key);
            }

            return ranges;
        } 

        public T NextValue()
        {
            var max = _ranges.Max(kv => kv.Key.Max);
            var selection = _rand.Next(max);

            return _ranges.First(kv => kv.Key.Min <= selection && kv.Key.Max > selection).Value;
        }
    }

    internal struct Range
    {
        public int Min { get; }
        public int Max { get; }

        public Range(int min, int max)
        {
            Min = min;
            Max = max;
        }
    }
}