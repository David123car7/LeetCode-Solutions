/*
 * LeetCode Problem: Set Mismatch (645)
 * URL: https://leetcode.com/problems/set-mismatch/
 * Difficulty: Easy
 *
 * Description:
 * You are given an array 'nums' containing n numbers taken from the range 1..n.
 * Exactly one number is duplicated and one number is missing.
 * Return an array where:
 *   - result[0] → the duplicated number
 *   - result[1] → the missing number
 *
 * Key Insight:
 * Every number from 1..n should appear exactly once.
 * By counting the frequency of each number, we can detect:
 *   - The duplicated number appears exactly twice (freq = 2)
 *   - The missing number appears zero times (freq = 0)
 *
 * Approach:
 *   1. Initialize a dictionary with keys 1..n and frequency 0.
 *   2. Count occurrences of each value in 'nums'.
 *   3. Scan through 1..n:
 *        - If frequency is 2 → duplicated.
 *        - If frequency is 0 → missing.
 *      Stop early once both values are found.
 *
 */
public int[] FindErrorNums(int[] nums) {
    int[] result = [0, 0];
    
    Dictionary<int, int> dict= new Dictionary<int, int>();
    for(int i=1; i<=nums.Length; i++){
        dict.Add(i, 0);
    }

    for(int i=0; i<nums.Length; i++){
        dict[nums[i]] = dict[nums[i]] + 1;
    }

    for(int i=1; i<=nums.Length; i++){
        if(dict[i] == 2)
            result[0] = i;
        if(dict[i] == 0)
            result[1] = i;
        
        if(result[0] != 0 && result[1] != 0)
            break;
    }
    
    return result;
}