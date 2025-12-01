/*
 * LeetCode Problem: Product of Array Except Self (238)
 * URL: https://leetcode.com/problems/product-of-array-except-self/
 * Difficulty: Medium
 *
 * Description:
 * Given an integer array nums, return an array answer such that answer[i] is equal to
 * the product of all the elements of nums except nums[i].
 *
 * Goal:
 * Calculate the product of all other elements for each index without using division
 * and in O(n) time.
 *
 * Key Insight:
 * The product of "all elements except self" is mathematically equivalent to:
 * (Product of all elements to the Left) * (Product of all elements to the Right).
 *
 * The Strategy:
 * 1. Prefix Array: Create an array where index 'i' contains the product of all numbers
 * from index 0 up to 'i'.
 * 2. Suffix Array: Create an array where index 'i' contains the product of all numbers
 * from the end of the array down to 'i'.
 * 3. Result Construction:
 * - For the first element: Take the suffix of the next element.
 * - For the last element: Take the prefix of the previous element.
 * - For middle elements: Multiply prefix[i-1] * suffix[i+1].
 *
 * Time Complexity: O(N)
 * - We perform three distinct linear passes over the array.
 *
 * Space Complexity: O(N)
 * - We use two auxiliary arrays (prefix and suffix) of size N.
 */
    public int[] ProductExceptSelf(int[] nums) {
        int[] result = new int[nums.Length];
        int[] prefix = new int[nums.Length];
        int[] sufix = new int[nums.Length];

        prefix[0] = nums[0];
        sufix[nums.Length-1] = nums[nums.Length-1];

        int index = nums.Length-2;
        for(int i=1; i<nums.Length; i++){
            prefix[i] = nums[i] * prefix[i-1];
            sufix[index] = nums[index] * sufix[index+1];
            index--;
        }

        result[0] = sufix[1];
        result[nums.Length-1] = prefix[nums.Length-2];
        for(int i=1; i<nums.Length-1; i++){
            result[i] = prefix[i-1] * sufix[i+1];
        }

        return result;
    }
