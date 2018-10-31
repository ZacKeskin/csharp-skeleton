using System;
using System.Collections.Generic;

namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question4
    {
        public static int Answer(string[,] machineToBeFixed, int numOfConsecutiveMachines)
        {
                int min_value = int.MaxValue;
                int n_rows = machineToBeFixed.GetLength(0);
                int n_seats = machineToBeFixed.GetLength(1); 

                // window to store recently parsed strings
                List<int> window = new List<int>();

                for (int i = 0; i < n_rows; i++)    
                {
                    window.Clear(); //Empty the window for each new row
                    int window_sum = 0;
                    int window_size = 0;
                    for(int j=0; j<n_seats; j++)
                        {
                            int number;  
                            bool isInt = int.TryParse(machineToBeFixed[i,j],out number);
                            
                            // If we encounter 'X':
                            if (isInt == false || number > min_value-numOfConsecutiveMachines+1)
                            {
                                // Reset window
                                window.Clear();
                                window_size=0;
                                window_sum=0;
                                if (j+numOfConsecutiveMachines >= n_seats){break;}
                            }
                            else{
                                window.Add(number);
                                window_sum += number;
                                window_size += 1;
                                if (window_size == numOfConsecutiveMachines)
                                    {
                                    if (window_sum < min_value) 
                                        {min_value = window_sum;}
                                    window_sum -= window[0];
                                    window.RemoveAt(0);
                                    window_size -= 1;
					                }
                            }
                        }
                }
            if (min_value == int.MaxValue){min_value=0;}
            return min_value;
        }
    }
}
