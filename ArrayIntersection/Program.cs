
namespace ArrayIntersection
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrA = { 1, 4, 5, 6 };
            int[] arrB = { 2, 3, 4, 5, 6 };
            int[] intersections = FindIntersection(arrA, arrB);

            if (intersections == null)
            {
                Console.WriteLine("No intersections");
            }
            else
            {
                Console.WriteLine("[{0}, {1}]", intersections[0], intersections[1]);
            }
        }

        static int[]? FindIntersection(int[] arrA, int[] arrB)
        {
            if (arrA.Length < 1 || arrB.Length < 1)
            {
                return null;
            }

            int[] intersections = { -1, -1 };

            int startIndexForLongArr = Math.Abs(arrA.Length - arrB.Length);
            if (arrA.Length >= arrB.Length)
            {
                int[] res = CheckIntersection(arrB, arrA, startIndexForLongArr);
                intersections[0] = res[1];
                intersections[1] = res[0];
            }
            else
            {
                int[] res = CheckIntersection(arrA, arrB, startIndexForLongArr);
                intersections[0] = res[0];
                intersections[1] = res[1];
            }

            if (intersections[0] == -1 && intersections[1] == -1)
            {
                return null;
            }

            return intersections;
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
