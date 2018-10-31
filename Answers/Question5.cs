using System;

namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question5
    {

       public static int Answer(int[] numOfShares, int totalValueOfShares)
        { 
            // Use dynamic programming solution to account for
            // overlapping subproblems

            // We work our way up to totalValueOfShares, reusing calculations 
            // from the factors to find the smallest path from 0 to totalValueOfShares

            // Create a table 
            int[] table = new int[totalValueOfShares + 1]; 
        
            // Default to totalValueOfShares = 0
            table[0] = 0; 
        

            for (int i=1; i<=totalValueOfShares; i++) 
            { 
                // Initialise all to MaxInt
                table[i] = int.MaxValue;
                
                for (int j=0; j<numOfShares.Length; j++) 
                if (numOfShares[j] <= i) 
                { 
                    int sub_result = table[i - numOfShares[j]]; 
                    if (sub_result != int.MaxValue &&  
                        sub_result + 1 < table[i]) 
                        table[i] = sub_result + 1; 
                } 
            } 
            if (table[totalValueOfShares] == int.MaxValue)
                {table[totalValueOfShares] = 0;}
            return table[totalValueOfShares]; 
            
        } 
    }
}
