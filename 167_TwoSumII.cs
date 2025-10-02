/*
 * Problem: 167. Two Sum II - Input Array Is Sorted
 * Source: https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/
 * 
 * Description:
 * Given a 1-indexed array of integers sorted in non-decreasing order,
 * find two numbers such that they add up to a specific target.
 * Return their indices [index1, index2], where 1 <= index1 < index2 <= numbers.length.
 * Each input has exactly one solution, and you cannot use the same element twice.
 *
 * Approach:
 * - Use the two-pointer technique:
 *   - Initialize one pointer at the start (low) and one at the end (high).
 *   - If the sum of numbers[low] + numbers[high] is greater than the target,
 *     move the high pointer left to reduce the sum.
 *   - If the sum is smaller, move the low pointer right to increase the sum.
 *   - Continue until the correct pair is found.
 *
 * Complexity:
 * - Time: O(n), since each pointer moves at most n steps.
 * - Space: O(1), constant extra space (just a few variables).
 *
 * Note: The return indices are 1-indexed as required by the problem statement.
 */

public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        int low = 0;
        int high = numbers.Length-1;

        while(low < high){
            int sum = numbers[low] + numbers[high];
            if(sum == target){
                break;
            }
            else if(sum > target)
                high--;
            else if(sum < target){
                low++;
            }
        }
        return [low+1,high+1];
    }
}