using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace DIS_Assignmnet1_Fall_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1
            Console.WriteLine("Q1 : Enter the string:");
            string s = Console.ReadLine();
            bool pos = HalvesAreAlike(s);
            if (pos)
            {
                Console.WriteLine("Both Halfs of the string are alike");
            }
            else
            {
                Console.WriteLine("Both Halfs of the string are not alike");
            }

            Console.WriteLine();
            
            //Question 2:
            Console.WriteLine(" Q2 : Enter the string to check for pangram:");
            string s1 = Console.ReadLine();
            bool flag = CheckIfPangram(s1);
            if (flag)
            {
                Console.WriteLine("Yes, the given string is a pangram");
            }
            else
            {
                Console.WriteLine("No, the given string is not a pangram");
            }
            Console.WriteLine();

            //Question 3:
            int[,] arr = new int[,] { { 1, 2, 3 }, { 3, 2, 1 } };
            int Wealth = MaximumWealth(arr);
            Console.WriteLine("Q3:");
            Console.WriteLine("Richest person has a wealth of {0}", Wealth);

            Console.WriteLine();
            //Question 4:
            string jewels = "aA";
            string stones = "aAAbbbb";
            Console.WriteLine("Q4:");
            int num = NumJewelsInStones(jewels, stones);
            Console.WriteLine("the number of stones you have that are also jewels are {0}:", num);
            Console.WriteLine();

            Console.WriteLine();
            //Question 5:
            Console.WriteLine("Q5:");
            String word2 = "aiohn";
            int[] indices = { 3, 1, 4, 2, 0 };
            String rotated_string = RestoreString(word2, indices);
            Console.WriteLine("The Final string after rotation is "+ rotated_string);

            Console.WriteLine();
            //Quesiton 6:
            Console.WriteLine("Q6: Enter the sentence to convert:");
            int[] nums = { 0, 1, 2, 3, 4 };
            int[] index = { 0, 1, 2, 2, 1 };
            int[] target = CreateTargetArray(nums, index);
            Console.WriteLine("Target array  for the Given array's is:");
            for (int i = 0; i < target.Length; i++)
            {
                Console.Write(target[i] + "\t");
            }
            Console.WriteLine();

        }

        /* 
        <summary>
        You are given a string s of even length. Split this string into two halves of equal lengths, 
        and let a be the first half and b be the second half.
        Two strings are alike if they have the same number of vowels ('a', 'e', 'i', 'o', 'u', 'A', 'E', 
        'I', 'O', 'U'). Notice that s contains uppercase and lowercase letters.
        Return true if a and b are alike. Otherwise, return false

        Example 1:
        Input: s = "book"
        Output: true
        Explanation: a = "bo" and b = "ok". a has 1 vowel and b has 1 vowel. Therefore, they are alike.
        </summary>
        */
        private static bool HalvesAreAlike(string s)
        {
            try
            {
                int str_len = s.Length;
                bool checkaplha;
                int count = 0;

                if (str_len >= 2 && str_len <= 1000) //check 1 if given string lies between 2 and 1000
                {
                    if (str_len % 2 == 0) //check 2 if string length is even
                    {
                        var regex = new Regex("^[a-zA-Z]+$");
                        checkaplha = regex.IsMatch(s);
                        if (checkaplha == true) //check 3 string contains lowercase and uppercase english letters
                        {
                            string str_vowels = "aeiouAEIOU";
                            for (int a = 0, b = s.Length/2; a < s.Length / 2; a++,b++)
                            {
                                
                                    if (str_vowels.IndexOf(s[a]) >= 0)
                                    {
                                        count ++;
                                    }
                                    if (str_vowels.IndexOf(s[b]) >= 0)
                                    {
                                        count --;
                                    }
                            }
                        } //check 3 string contains lowercase and uppercase english letters
                    }//check 2 if string length is even ends 
                }//check 1 if given string lies between 2 and 1000 ends 
                return count == 0;
            }
            catch (Exception)
            {
                throw;
            }

        }

        /* 
 <summary>
A pangram is a sentence where every letter of the English alphabet appears at least once.
Given a string sentence containing only lowercase English letters, return true if sentence is a pangram, or false otherwise.
Example 1:
Input: sentence = "thequickbrownfoxjumpsoverthelazydog"
Output: true
Explanation: sentence contains at least one of every letter of the English alphabet.
</summary>
</returns> true/false </returns>
Note: Use of String function (Contains) and hasmap is not allowed, think of other ways how you could the numbers be represented
*/
        private static bool CheckIfPangram(string s)
        {
            try
            {
                bool[] output_data = new bool[26];
                int index = 0;
                
                for (int i=0; i<s.Length;i++)
                {
                    if ('A' <= s[i] && s[i] <= 'Z')
                        index = s[i] - 'A';
                    else if ('a' <= s[i] && s[i] <= 'z')
                        index = s[i] - 'a';
                    else
                        continue;
                    output_data[index] = true;
                }

                for (int j = 0; j <= 25; j++)
                {
                    if (output_data[j] == false)
                        return false;
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }

        }
        /*
        <summary> 
        You are given an m x n integer grid accounts where accounts[i][j] is the amount of money the ith customer has in the jth bank. Return the wealth that the richest customer has.
       A customer's wealth is the amount of money they have in all their bank accounts. The richest customer is the customer that has the maximum wealth.

       Example 1:
       Input: accounts = [[1,2,3],[3,2,1]]
       Output: 6
       Explanation:
       1st customer has wealth = 1 + 2 + 3 = 6
       2nd customer has wealth = 3 + 2 + 1 = 6
       Both customers are considered the richest with a wealth of 6 each, so return 6.
       </summary>
        */
        private static int MaximumWealth(int[,] accounts)
        {
            try
            {
                int wealth = 0;
                for (int m=0; m<accounts.GetLength(0);m++)
                {
                    int sum = 0;
                    for(int n=0; n<accounts.GetLength(1);n++)
                    {
                        sum = sum + accounts[m, n];
                    }
                    wealth = Math.Max(wealth, sum);
                }
                return wealth;

            }
            catch (Exception)
            {
                throw;
            }
        }
        /*
 <summary>
You're given strings jewels representing the types of stones that are jewels, and stones representing the stones you have.
Each character in stones is a type of stone you have. You want to know how many of the stones you have are also jewels.
Letters are case sensitive, so "a" is considered a different type of stone from "A".
 
Example 1:
Input: jewels = "aA", stones = "aAAbbbb"
Output: 3
Example 2:
Input: jewels = "z", stones = "ZZ"
Output: 0
 
Constraints:
•	1 <= jewels.length, stones.length <= 50
•	jewels and stones consist of only English letters.
•	All the characters of jewels are unique.
</summary>
 */
        private static int NumJewelsInStones(string jewels, string stones)
        {
            try
            {
                int count = 0;
                bool jw_letters;
                bool st_letters;
                if ((jewels.Length >= 1 && jewels.Length <= 50) && (stones.Length >= 1 && stones.Length <= 50)) //check 1 of input lengths between the range
                {
                    var regexletters = new Regex("^[a-zA-Z]+$");
                    jw_letters = regexletters.IsMatch(jewels);
                    st_letters = regexletters.IsMatch(stones);

                    if (jw_letters == true && st_letters == true) //check 2 strings jewel and stone conatins only english letters
                    {                       
                        for (int i = 0; i < stones.Length; i++)
                        {
                            for (int j = 0; j < jewels.Length; j++)
                            {
                                if (jewels[j] == stones[i])
                                    count++;
                            }
                        }
                    }//check 2 strings jewel and stone conatins only english letters ends
                }//check 1 of input lengths between the range ends
               
                return count;
            }
            catch (Exception e)
            {

                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }

        }



        /*

        <summary>
        Given a string s and an integer array indices of the same length.
        The string s will be shuffled such that the character at the ith position moves to indices[i] in the shuffled string.
        Return the shuffled string.

        Example 3:
        Input: s = "aiohn", indices = [3,1,4,2,0]
        Output: "nihao"
        */

        private static string RestoreString(string s, int[] indices)
        {
            try
            {
                int n;
                bool checklower;

                //constraints check 
                if (s.Length == indices.Length) //check 1 of same input lengths
                {
                    n = s.Length;
                    if (n >= 1 && n <= 100) //check 2 of values between 1 and 100 range
                    {
                        var regex = new Regex("^[a-z]+$");
                        checklower = regex.IsMatch(s); //check 3 string contains only lower case english letters
                        if (checklower == true)
                        {
                            bool isduplicate = false;
                            for (int k = 0; k < indices.Length; k++) //check 4 unique elements in indices 
                            {
                                //bool isduplicate = false;
                                for (int j = 0; j < k; j++)
                                {
                                    if (indices[k] == indices[j])
                                    {
                                        isduplicate = true;
                                        break;
                                    }
                                    else
                                        isduplicate = false;
                                }
                            }
                            if (isduplicate == false)
                            {
                                //convert string to char array of same length
                                char[] res = new char[s.Length];

                                //assigning values as per indices 
                                for (int i = 0; i < s.Length; i++)
                                    res[indices[i]] = s[i];
                                
                                //reverting array to string again
                                string result = new string(res);
                                return result;

                            }//check 4 ends 
                        }//check 3 ends 
                    }//check 2 ends 
                }//check 1 ends
                return null;  
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }

        /*
        <summary>
Given two arrays of integers nums and index. Your task is to create target array under the following rules:
•	Initially target array is empty.
•	From left to right read nums[i] and index[i], insert at index index[i] the value nums[i] in target array.
•	Repeat the previous step until there are no elements to read in nums and index.
Return the target array.
It is guaranteed that the insertion operations will be valid.
 
Example 1:
Input: nums = [0,1,2,3,4], index = [0,1,2,2,1]
Output: [0,4,1,3,2]


Explanation:
nums       index     target
0            0        [0]
1            1        [0,1]
2            2        [0,1,2]
3            2        [0,1,3,2]
4            1        [0,4,1,3,2]
*/
        private static int[] CreateTargetArray(int[] nums, int[] index)
        {
            try
            {
                if((nums.Length>=1 && nums.Length<=100)&&(index.Length>=1 && index.Length<=100)) //check 1 of values between range
                {
                    if (nums.Length == index.Length) //check 2 if length of both are equal
                    {
                        int[] target = new int[index.Length];
                        List<int> newtarget = new List<int>(index.Length);
                        for (int i = 0; i < index.Length; i++)
                        {
                            newtarget.Insert(index[i], nums[i]);
                        }
                        target = newtarget.ToArray();
                        return target;
                    } //check 2 ends
                    
                } //check 1 ends 
                return null;
                
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
