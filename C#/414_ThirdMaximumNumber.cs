/*
 * LeetCode Problem: Third Maximum Number (414)
 * URL: https://leetcode.com/problems/third-maximum-number/
 * Difficulty: Easy
 *
 * Description:
 * Given an integer array 'nums', return the third distinct maximum number.
 * If the third distinct maximum does not exist, return the maximum number instead.
 *
 * Key Insight:
 * Instead of sorting the array (O(n log n)), we can track the top three unique
 * maximum values in a single pass using three optional variables:
 *   - firstMax  → largest
 *   - secondMax → second largest
 *   - thirdMax  → third largest
 *
 * For each number:
 *   - Skip it if it matches any of the already stored max values (duplicate).
 *   - Otherwise, compare it in descending order:
 *        If greater than firstMax → shift first→second→third and update firstMax.
 *        Else if greater than secondMax → shift second→third and update secondMax.
 *        Else if greater than thirdMax → update thirdMax.
 *
 * Time Complexity: O(n)
 *   - Only one pass through the array.
 * Space Complexity: O(1)
 *   - Only three optional variables are used regardless of input size.
 *
 */
public int ThirdMax(int[] nums) {
    int? firstMax = null;
    int? secondMax = null;
    int? thirdMax = null;

    int size = 0;
    for(int i=0; i<nums.Length; i++){
        int num = nums[i];
        
        if(num == firstMax || num == secondMax || num == thirdMax)
            continue;

        if(firstMax == null || num > firstMax){
            thirdMax = secondMax;
            secondMax = firstMax;
            firstMax = num;
        }
        else if(secondMax == null || num > secondMax){
            thirdMax = secondMax;
            secondMax = num;
        }
        else if(thirdMax == null || num > thirdMax){
            thirdMax = num;
        }

        size++;
    }

    if(size >= 3) return thirdMax.Value;
    else return firstMax.Value;
}
