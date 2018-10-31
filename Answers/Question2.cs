using System.Collections.Generic;
using System;
using System.Linq;


namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question2
    {
        public static int Answer(int[] cashflowIn, int[] cashflowOut)
        {   
            int min = int.MaxValue;

            // Check if any items are shared between In and Out
            List<int> joint = cashflowIn.Union(cashflowOut).ToList();
            List<int> unique_in = new HashSet<int>(cashflowIn).ToList();
            List<int> unique_out = new HashSet<int>(cashflowOut).ToList();

            // If there are shared items, the lengths will differ
            if (unique_in.Count + unique_out.Count != joint.Count)
                {min = 0;}
            else
                {
                
                // Otherwise, calculate sum of each subset as we go along
                List<int> powersetsums_in = PowerSetSums(unique_in);
                List<int> powersetsums_out = PowerSetSums(unique_out);
                
                // Sort both arrays and loop together, in better than O(N*M)
                powersetsums_in.Sort(); 
                powersetsums_out.Sort(); 

                int a = 0, b = 0; 
            
                // Compare diffs up to size of the larger array
                while (a < powersetsums_in.Count && b < powersetsums_out.Count) 
                { 
                    if (Math.Abs(powersetsums_in[a] - powersetsums_out[b]) < min) 
                        {min = Math.Abs(powersetsums_in[a] - powersetsums_out[b]);}
            
                    // Reuse the smaller value 
                    if (powersetsums_in[a] < powersetsums_out[b]) 
                        {a++;} 
                    else
                        {b++;} 
                }
                

                // Finally, check that an empty set solution isn't better:
                int inmin = cashflowIn.Min();
                int outmin = cashflowOut.Min();
                if (inmin < min){min = inmin;}
                if (outmin < min){min = outmin;}
                }
                


            return min;
        }

        public static List<int> PowerSetSums(List<int> items)
        {
            int N = items.Count;
            List<int> sums = new List<int>();
            
            for(int i=0; i < Math.Pow(2,N); i++)
                {
                    // Create empty list to store sum of combinations
                    int sum = 0;
                    for (int j=0; j< N; j++)
                    {
                    if ( (i >> j) % 2 == 1) // testing bit j of integer i
                        {
                        sum += items[j];
                        }
                    }
                    if (sum>0)
                    {sums.Add(sum);}
                }
            return sums;
        }
        
    }
}
