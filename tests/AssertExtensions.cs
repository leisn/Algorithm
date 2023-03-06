using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public static class AssertExtensions
    {
        public static Assert IsValueEqual<T>(this Assert assert, T expected, T actual) where T : IList
        {
            if (actual.Count != expected.Count)
                throw new AssertFailedException($"List Count not match: expected {expected.Count} , actual {actual.Count}");
            for (int i = 0; i < actual.Count; i++)
            {
                if (!Equals(actual[i], expected[i]))
                    throw new AssertFailedException($"Expected {expected[i]} but actual {actual[i]}, at index {i}");
            }
            return assert;
        }

        public static Assert IsValueEqual<T>(this Assert assert, T[] expected, T[] actual) where T : struct
        {
            if (actual.Length != expected.Length)
                throw new AssertFailedException($"List Count not match: expected {expected.Length} , actual {actual.Length}");
            for (int i = 0; i < actual.Length; i++)
            {
                if (!Equals(actual[i], expected[i]))
                    throw new AssertFailedException($"Expected {expected[i]} but actual {actual[i]}, at index {i}");
            }
            return assert;
        }
    }
}
