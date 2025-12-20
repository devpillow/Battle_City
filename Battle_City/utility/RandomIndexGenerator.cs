using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_City.utility
{
    public class RandomIndexGenerator
    {
        public int[] GenerateRandomIndices(int[] array)
        {
            // Calculate the total size for the result array
            int totalCount = array.Sum();
            int[] indicesArray = new int[totalCount];
            int index = 0;

            // Fill the array based on the values in the input array
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i]; j++)
                {
                    indicesArray[index++] = i; // Assign the index to the result array
                }
            }

            // Shuffle the array to randomize the order
            Random random = new Random();
            return indicesArray.OrderBy(x => random.Next()).ToArray();
        }

    }
}
