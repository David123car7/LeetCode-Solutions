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

/*
 * LeetCode Problem: Set Mismatch (645)
 * URL: https://leetcode.com/problems/set-mismatch/
 * Difficulty: Easy
 *
 * Description:
 * Given an array 'nums' where numbers from 1..n should appear exactly once,
 * one number appears twice and one number is missing.
 * Return: 
 *   result[0] → duplicated number
 *   result[1] → missing number
 *
 * Approach (Sorting + Arithmetic):
 *   1. Sort the array so that any duplicate appears next to itself.
 *   2. Compute the expected sum of numbers from 1..n using:
 *          n(n + 1) / 2
 *   3. Compute the actual sum of the sorted array.
 *   4. Find the duplicated number by checking where nums[i] == nums[i + 1].
 *   5. The missing number can then be calculated using:
 *
 *        missing = expectedSum - (sum - duplicated)
 *
 *   Is slower because it has to sort the array because first sorts the array.
 */
public int[] FindErrorNums(int[] nums) {
    int[] result = [0,0];
    Array.Sort(nums);

    int expectedSum = nums.Length * (nums.Length + 1) / 2;
    int sum = 0;
    for(int i=0; i<nums.Length; i++){
        sum += nums[i];
    }

    for(int i=0; i<nums.Length-1; i++){
        if(nums[i] == nums[i+1]){
            result[0] = nums[i];
            result[1] = expectedSum - (sum - nums[i]);
            break;
        }
    }


    return result;
}
