using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baitap2._2
{
    class TinhDiem
    {
        public static double averageScore(Array array)
        {
            double sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += (double)array.GetValue(i);
            }
            return sum / array.Length;
        }
        public static double maxScore(Array array)
        {
            double maxScore = (double)array.GetValue(0);
            foreach (var d in array)
            {
                if ((double)d > maxScore)
                    maxScore = (double)d;
            }
            return maxScore;
        }
        public static double minScore(Array array)
        {
            double minScore = (double)array.GetValue(0);
            foreach (var d in array)
            {
                if ((double)d < minScore)
                    minScore = (double)d;
            }
            return minScore;
        }
    }
}
