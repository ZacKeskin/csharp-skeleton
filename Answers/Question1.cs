using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question1
    {
       public static int Answer(int[] portfolios) 
        {
            int max_xor = 0;
            int xor = 0;
            int N = portfolios.Length;

            // Loop over all combinations
            for(int i=0; i<N; i++){
                for (int j=i+1; j<N; j++)
                    {
                    //compare if xor is > answer
                    xor  = portfolios[i] ^ portfolios[j];     
                    if (xor > max_xor)
                        {max_xor = xor;}
                    }

                }
            return max_xor;
        }
    }
    
}
