/*
 * LeetCode Problem: Set Mismatch (645)
 * URL: https://leetcode.com/problems/set-mismatch/
 * Difficulty: Easy
 *
 * Description:
 * You are given an array nums representing numbers from 1 to n.
 * Exactly one number appears twice (the duplicated number),
 * and exactly one number is missing from the range [1, n].
 * Return an array: [duplicate, missing].
 *
 * Key Insight (In-Place Marking Technique):
 * Since each value must map to an index (value -> index = value - 1),
 * we can treat the array as its own bookkeeping structure.
 * By flipping numbers to NEGATIVE at their mapped index, we "mark" them as visited.
 *
 * The Strategy:
 * 1. First Pass — Find the Duplicated Number:
 *    - For each number x, compute index = abs(x) - 1.
 *    - If nums[index] is already negative, it means we've visited this number before → duplicate found.
 *    - Otherwise, make nums[index] negative to mark it as visited.
 *
 * 2. Second Pass — Find the Missing Number:
 *    - After marking, any index 'i' whose value is still POSITIVE was never visited.
 *    - This means the missing number is i + 1.
 *
 * Example:
 * If nums[index] is negative, it means the number (index + 1) appeared before.
 * If nums[index] stays positive, it means the number (index + 1) never appeared.
 *
 * Time Complexity: O(n)
 * - One pass to detect the duplicate, one pass to detect the missing number.
 *
 * Space Complexity: O(1)
 * - In-place marking, no extra data structures used.
 *   (Ignore the returned result array, as per standard conventions.)
 */
public int[] FindErrorNums(int[] nums) {
    int[] result = [0, 0];
    
    for(int i=0; i<nums.Length; i++){
        int index = Math.Abs(nums[i]) - 1;
        if(nums[index] < 0){    
            result[0] = index+1;
        }
        else
            nums[index] *= -1;
    }

    for(int i=0; i<nums.Length; i++){
        if(nums[i] > 0){
            result[1] = i+1;
        }
    }


    return result;
}

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
