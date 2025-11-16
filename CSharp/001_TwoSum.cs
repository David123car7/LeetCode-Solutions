/*
 * LeetCode Problem: Two Sum (1)
 * URL: https://leetcode.com/problems/two-sum/
 * Difficulty: Easy
 *
 * Description:
 * Given an array of integers 'nums' and an integer 'target', return indices of the two numbers
 * such that they add up to target. Each input has exactly one solution, and you may not use 
 * the same element twice. You can return the answer in any order.
 *
 * Solution Approaches:
 * 1. Optimized Dictionary Approach (O(n) time, O(n) space):
 *    - Iterate through the array once.
 *    - For each element 'x', compute 'target - x' (the complement) and check if it exists in a dictionary.
 *    - If the complement exists, return the stored index and current index.
 *    - Otherwise, store the current number with its index in the dictionary.
 * 
 * 2. Brute Force Approach (O(n^2) time, O(1) space):
 *    - Use nested loops to check every pair of numbers.
 *    - Return indices if a pair sums to the target.
 *
 *
 * Author: David Carvalho
 * Date: 2025-10-02
 * Note: Do not think like x + y = Target but think like y = Target - x
 */

public class Solution {
    public int[] TwoSum(int[] nums, int target) { 
        Dictionary<int, int> dict = new Dictionary<int, int>();
        for(int i=0; i<nums.Length; i++){
            int diff = target - nums[i];
            if(dict.ContainsKey(diff)){
                return [dict[diff], i];
            }
            else{
                dict[nums[i]] = i;
            }
        }

        return new int[0];
    }

    public int[] TwoSumNotOptimized(int[] nums, int target) {
        for(int i = 0; i< nums.Length; i++){
            for(int j = i+1; j< nums.Length; j++){
                if(nums[i] + nums[j] == target){
                    return [i, j];
                }
            }
        }
        return new int[0];
    }
}    