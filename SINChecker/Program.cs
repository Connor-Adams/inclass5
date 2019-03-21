using System;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.PortableExecutable;

namespace SINChecker
{
    class Program
    {

        static void ReverseString()
        {
            Console.WriteLine("Input text to reverse");
            String input = Console.ReadLine();
            Console.WriteLine("The reverse of the entered text is:");
            
            //loop starts at the highest value of the string array (starts at the very last character entered) 
            //this loop effectivly goes through the users input in a descending order
            for (int i = input.Length; i > 0; i--)
            {
             //prints the current letter   
                Console.Write(input[i-1]);
            }
            Console.WriteLine("");
        }

        static void SinCheck(string sin)
        {
            //variable designation
            string operand = "121212121";
            int sum = 0;
            int tempNum = 0;
            string sinDigit;
            string operandDigit;
            string tempDigit;
            int convertedNumber;
            int doubledigitSum;
            
            //for loop that runs once for every sin digit
            for (int i = 0; i < sin.Length; i++)
            {
                //get a sin digit for each iteration of the loop
                sinDigit = sin[i].ToString();
                //get a operand digit (121212121) for each iteration of the loop
                operandDigit = operand[i].ToString();
                
                //Multiply the sin digit and operand digit
                tempNum = int.Parse(sinDigit) * int.Parse(operandDigit);
                
                //Convert the temp number (Assigned above) to a string to check for length
                String tempString = tempNum.ToString();
                
                //Checks if the number has multiple digits (i.e. 12) if yes, starts a for loop to add the digits together
                if (tempString.Length > 1)
                {
                    //temp variable that gets cleared every itieration of the loop below to avoid excessive addding
                    doubledigitSum = 0;
                    
                    //Loop for adding the digits of a number together
                    for (int j = 0; j < tempString.Length; j++)
                    {
                        tempDigit = tempString[j].ToString();
                        convertedNumber = int.Parse(tempDigit);

                        doubledigitSum += convertedNumber;
                    }
                    //add the result of the added digits to the overall sum
                    sum += doubledigitSum;
                }
                
                //if the current number only has a single digit, add it to the sum
                else
                {
                    sum += tempNum;
                }

            }

            //Check to see if the the sum is evenly divisible by 10 (% modulo operator to check for remainder)
            if ((sum % 10) == 0)
            {
                Console.WriteLine("Sin is Valid");
            }
            else
            {
                Console.Write("Sin is not vaild");
            }

        }
        
        static void Main(string[] args)
        {
            

            do
            {
                Console.WriteLine("Please Select an Option");
                Console.WriteLine("1. Sin Vailidity Checker");
                Console.WriteLine("2. String Reverser");
                Console.WriteLine("3. End Program");
                string input = Console.ReadLine();
                if (input.Equals("1"))
                {
                    Console.WriteLine("input your sin as a continuous number");
                    String SinPut = Console.ReadLine();
                    SinCheck(SinPut);
                    
                }else if (input.Equals("2"))
                {
                    ReverseString();
                }else if (input.Equals("3"))
                {
                    Console.WriteLine("Program Exiting");
                    break;
                }

            } while (true);

        }
    
    }
}