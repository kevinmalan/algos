using System;
using System.Collections.Generic;
using System.Text;

namespace Algos.Services
{
    public class ArrayService
    {
        /// <summary>
        /// Given a 2D array of 6 X 6 that contains 16 hourglasses
        /// Each hourglass  consist of 7 values: r0c0, r0c1, r0c2, r1c1, r2c0, r2c1, r2c2 (r == row, c == column)
        /// Calculate the sum of each hourglass and return the highest value.
        /// Each index range from -9 to 9
        /// Space Complexity: O(1) because we limtied the loop length to '3'. Thus increasing the array size won't make a difference.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int GetHighestHourglassSum(int[][] arr)
        {
            int lowestSum = -63;
            for (int i = 0; i <= 3; i++)
            {
                for (int y = 0; y <= 3; y++)
                {
                    var sum = arr[i][y] + arr[i][y + 1] + arr[i][y + 2] + arr[i + 1][y + 1] +
                        arr[i + 2][y] + arr[i + 2][y + 1] + arr[i + 2][y + 2];

                    if (sum > lowestSum) lowestSum = sum;
                }
            }

            return lowestSum;
        }
    }
}