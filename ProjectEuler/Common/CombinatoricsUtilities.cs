using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class CombinatoricsUtilities
    {
        // without self pairs amount n * n - 1, where n - amount of elements
        // with self pairs: n * n
        public static IEnumerable<Tuple<T,T>> Pairs<T>(IEnumerable<T> elements, bool includeSelfPairs = false)
        {
            var e = elements.ToArray();

            for (int i = 0; i < e.Length; i++)
            {
                for (int j = 0; j < e.Length; j++)
                {
                    if (includeSelfPairs || i != j)
                    {
                        yield return Tuple.Create(e[i], e[j]);
                    }
                }
            }
        }

        // amount n!, where n - amount of elements
        public static IEnumerable<T[]> Permutations<T>(IEnumerable<T> elements)
        {
            return PermutationsFast(elements, elements.Count());
        }

        // amount n! / (n - size)!, where n - amount of elements
        public static IEnumerable<T[]> Permutations<T>(IEnumerable<T> elements, int size)
        {
            return PermutationsFast(elements, size);
        }

        private static IEnumerable<T[]> PermutationsFast<T>(IEnumerable<T> elements, int size)
        {
            var taken = new bool[elements.Count()];

            // init taken dic
            for (int i = 0; i < elements.Count(); i++)
			{
                taken[i] = false;
            }

            return PermutationsTake(elements.ToList(),
                taken,
                0, 
                size, 
                new T[size]);
        }

        private static IEnumerable<T[]> PermutationsTake<T>(
            IList<T> elements,
            bool[] taken,
            int position,
            int size,
            T[] current)
        {
            for (int i = 0; i < elements.Count; ++i )
            {
                if (!taken[i])
                {
                    T item = elements[i];

                    // take
                    taken[i] = true;
                    current[position] = item;

                    if (position == size - 1)
                    {
                        yield return (T[])current.Clone();
                    }
                    else
                    {
                        foreach (var perm in PermutationsTake(elements, taken, position + 1, size, current))
                        {
                            yield return perm;
                        }
                    }

                    // release
                    taken[i] = false;
                }
            }
        }

        private static void Swap<T>(IList<T> elements, int i, int j)
        {
            T temp = elements[i];
            elements[i] = elements[j];
            elements[j] = temp;
        }

        private static T[] Append<T>(T[] source, T value)
        {
            int n = source != null ? source.Length : 0;

            T[] result = new T[n + 1];

            if (n > 0)
            {
                Array.Copy(source, 0, result, 1, n);
            }

            result[0] = value;

            return result;
        }

        private static IEnumerable<T[]> ProduceByAppend<T>(IEnumerable<T[]> sourceSequences, T value)
        {
            foreach (var sequence in sourceSequences)
            {
                yield return Append(sequence, value);
            }
        }

        private static IEnumerable<T[]> ProduceByAppend<T>(T[] sourceSequence, IEnumerable<T> values)
        {
            foreach (var value in values)
            {
                yield return Append(sourceSequence, value);
            }
        }
    }
}
