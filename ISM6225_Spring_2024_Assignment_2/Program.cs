using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                // Write your code here
                HashSet<int> seen = new HashSet<int>();  // Track numbers found in the array.
                List<int> missing = new List<int>();     // Store missing numbers.

                foreach (var num in nums)
                    seen.Add(num);  // Store each unique number in the HashSet.

                for (int i = 1; i <= nums.Length; i++)
                {
                    if (!seen.Contains(i))
                        missing.Add(i);  // Add any missing number to the result list.
                }
                return missing;
               
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                // Write your code here
                List<int> even = new List<int>();  // Store even numbers.
                List<int> odd = new List<int>();   // Store odd numbers.

                // Traverse the array and distribute numbers based on their parity.
                foreach (var num in nums)
                {
                    if (num % 2 == 0)
                        even.Add(num);  // Add to even list.
                    else
                        odd.Add(num);   // Add to odd list.
                }

                // Concatenate even and odd lists to form the result.
                even.AddRange(odd);
                return even.ToArray();  // Convert to array and return.
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                // Write your code here
                Dictionary<int, int> numIndices = new Dictionary<int, int>();

                for (int i = 0; i < nums.Length; i++)
                {
                    int complement = target - nums[i];  // Calculate the complement.

                    if (numIndices.ContainsKey(complement))
                        return new int[] { numIndices[complement], i };  // Return matching indices.

                    if (!numIndices.ContainsKey(nums[i]))  // Avoid overwriting existing keys.
                        numIndices[nums[i]] = i;
                }
                return new int[] { };  // Return an empty array if no solution found
               
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                // Write your code here
                if (nums.Length < 3)
                    throw new ArgumentException("Array must contain at least three numbers.");

                Array.Sort(nums);  // Sort the array to easily find largest and smallest numbers.
                int n = nums.Length;

                // Compare the product of the largest three numbers with the product of the two smallest and the largest.
                return Math.Max(nums[n - 1] * nums[n - 2] * nums[n - 3],
                                nums[0] * nums[1] * nums[n - 1]);
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                // Write your code here
                if (decimalNumber < 0)
                    throw new ArgumentException("Negative numbers are not supported.");

                return Convert.ToString(decimalNumber, 2);  // Convert using built-in method.
               
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                // Write your code here
                int left = 0, right = nums.Length - 1;

                while (left < right)
                {
                    int mid = left + (right - left) / 2;

                    if (nums[mid] > nums[right])
                        left = mid + 1;  // Minimum is on the right side.
                    else
                        right = mid;  // Minimum is at mid or to the left.
                }
                return nums[left];  // The minimum element.
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                // Write your code here
                if (x < 0) return false;  // Negative numbers are not palindromes.

                int original = x, reversed = 0;

                while (x != 0)
                {
                    int remainder = x % 10;
                    reversed = reversed * 10 + remainder;
                    x /= 10;
                }
                return original == reversed;  // Check if the reversed number matches the original.
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                // Write your code here
                if (n < 0) throw new ArgumentException("Input must be non-negative.");
                if (n <= 1) return n;  // Base cases.

                int a = 0, b = 1;

                for (int i = 2; i <= n; i++)
                {
                    int next = a + b;
                    a = b;
                    b = next;
                }
                return b;  // The nth Fibonacci number.
                
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
