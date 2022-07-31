/**
 * Given two arrays A and B, return the indices at which the two 
 * arrays intersect. If the two arrays have no intersection at 
 * all, return null. Extra credit: how would you change your 
 * code if they were linked lists instead of arrays, if the input 
 * were the two head nodes, and you returned the intersection node?
 * 
 * **/

namespace ArrayIntersection
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrA = { 1, 4, 5, 6 };
            int[] arrB = { 2, 3, 4, 5, 6 };
            int[] intersection = FindIntersection(arrA, arrB);

            if (intersection == null)
            {
                Console.WriteLine("No intersection");
            }
            else
            {
                Console.WriteLine("[{0}, {1}]", intersection[0], intersection[1]);
            }
        }

        static int[]? FindIntersection(int[] arrA, int[] arrB)
        {
            if (arrA.Length < 1 || arrB.Length < 1)
            {
                return null;
            }

            int[] intersection = { -1, -1 };

            int startIndexForLongArr = Math.Abs(arrA.Length - arrB.Length);
            if (arrA.Length >= arrB.Length)
            {
                int[] res = CheckIntersection(arrB, arrA, startIndexForLongArr);
                intersection[0] = res[1];
                intersection[1] = res[0];
            }
            else
            {
                int[] res = CheckIntersection(arrA, arrB, startIndexForLongArr);
                intersection[0] = res[0];
                intersection[1] = res[1];
            }

            if (intersection[0] == -1 && intersection[1] == -1)
            {
                return null;
            }

            return intersection;
        }

        static int[] CheckIntersection(int[] shortArr, int[] longArr, int startIndexForLongArr)
        {
            bool prevEqual = false;
            int[] intersectionIndexes = { -1, -1 };
            for (int i = 0; i < shortArr.Length; i++)
            {
                if (shortArr[i] == longArr[startIndexForLongArr] && !prevEqual)
                {
                    intersectionIndexes[0] = i;
                    intersectionIndexes[1] = startIndexForLongArr;
                    prevEqual = true;
                }
                else if (shortArr[i] != longArr[startIndexForLongArr])
                {
                    // if the next items after the first intersection are not equal
                    // reset. The assumption here is that for a true intersection,
                    // the elements have to be the same to the end.
                    intersectionIndexes[0] = -1;
                    intersectionIndexes[1] = -1;
                    prevEqual = false;
                }

                startIndexForLongArr++;
            }

            return intersectionIndexes;
        }
    }
}
