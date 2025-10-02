/*
 * LeetCode Problem: Find First and Last Position of Element in Sorted Array (34)
 * URL: https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/
 * Difficulty: Medium
 *
 * Description:
 * Given a sorted array of integers, find the starting and ending position of a given target value.
 *
 * Solution Approach:
 * - This solution uses three binary searches:
 *   1. Standard binary search to find any occurrence of the target.
 *   2. Binary search to find the leftmost index of the target.
 *   3. Binary search to find the rightmost index of the target.
 *
 * Author: David Carvalho
 * Date: 2025-10-02
 */

public class Solution {
    public int[] SearchRange(int[] nums, int target) {
        int greater = -1;
        int lesser = -1;

        int middle = BinarySearch(nums, target);
        if(middle != -1){
            if(nums.Length == 1){
                return [middle, middle];
            }

            lesser = BinarySearchLeft(nums, target, middle);
            greater = BinarySearchRight(nums, target, middle);
        }

        return [lesser, greater];
    }

    public int BinarySearchLeft(int[] nums, int target, int high){
        int low = 0;
        int middle = 0;

        while(low <= high){
            middle = (low + high) / 2;

            if(nums[middle] == target){
                high = middle - 1;
            }
            else if(nums[middle] < target){
                low = middle + 1;
            }
            else if(nums[middle] > target){
                high = middle - 1;
            }
        }

        return low;
    }

        public int BinarySearchRight(int[] nums, int target, int low){
        int middle = 0;
        int high = nums.Length -1;

        while(low <= high){
            middle = (low + high) / 2;

            if(nums[middle] == target){
                low = middle + 1;
            }
            else if(nums[middle] < target){
                low = middle + 1;
            }
            else if(nums[middle] > target){
                high = middle - 1;
            }
        }

        return high;
    }

    public int BinarySearch(int[] nums, int target){
        int low = 0;
        int high = nums.Length -1;
        int middle = 0;

        while(low <= high){
            middle = (low + high) / 2;

            if(nums[middle] == target){
                return middle;
            }
            else if(nums[middle] < target){
                low = middle + 1;
            }
            else if(nums[middle] > target){
                high = middle - 1;
            }
        }

        return -1;
    }
}