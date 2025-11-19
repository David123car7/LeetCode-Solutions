/*
 * LeetCode Problem: Find All Numbers Disappeared in an Array (448)
 * URL: https://leetcode.com/problems/find-all-numbers-disappeared-in-an-array/
 * Difficulty: Easy
 *
 * Description:
 * Given an array nums of n integers where nums[i] is in the range [1, n], 
 * return an array of all the integers in the range [1, n] that do not appear in nums.
 *
 * Key Insight (In-Place Modification):
 * We use the input array itself as a Hash Map to save O(n) space.
 * Since the values are in the range [1, n], they map perfectly to the array indices [0, n-1].
 *
 * The Strategy:
 * 1. Iterate through the array. For every value 'x' we encounter, treat it as an index.
 * 2. Go to the index corresponding to 'x' (index = x - 1).
 * 3. Mark the number at that index as "visited" by making it NEGATIVE.
 * (We use Math.Abs() to ensure we get the correct index even if the current number was already marked) Example: (If num[i] = -1 we cant use it as a index so we make it 1 using Math.Abs()).
 * 4. Finally, any index 'i' that still contains a POSITIVE number means the value 'i+1' was never found.
 *
 * Time Complexity: O(n)
 * - Two passes over the array (one to mark, one to collect results).
 * Space Complexity: O(1)
 * - We modify the input array in-place. No extra data structures (like Dictionary) are used.
 * (Note: The space for the returned list is usually not counted as auxiliary space).
 */
public IList<int> FindDisappearedNumbers(int[] nums) {
    List<int> list = new List<int>();
    
    for(int i=0; i<nums.Length; i++){
        int index = Math.Abs(nums[i]) - 1;
        if(nums[index] > 0)
            nums[index] *= -1;
    }

    for(int i=0; i<nums.Length; i++){
        if(nums[i] > 0)
            list.Add(i+1);
    }

    return list;
}

/*
 * LeetCode Problem: Find All Numbers Disappeared in an Array (448)
 * URL: https://leetcode.com/problems/find-all-numbers-disappeared-in-an-array/
 * Difficulty: Easy
 *
 * Description:
 * Given an array nums of n integers where nums[i] is in the range [1, n], 
 * return an array of all the integers in the range [1, n] that do not appear in nums.
 *
 * Key Insight (Dictionary Approach):
 * We use a Dictionary (Hash Map)
 * to track the existence of every number in the expected range [1, n].
 *
 * The process involves three passes:
 * 1. Initialization: Populate the dictionary with keys 1 to n (all potential numbers),
 * setting their initial count to 0.
 * 2. Counting: Iterate through the input 'nums'. For each number found, increment
 * its count in the dictionary.
 * 3. Filtering: Iterate through the expected range (1 to n) one last time.
 * If a number's count is still 0 in the dictionary, it is missing from the input.
 *
 * Time Complexity: O(n)
 * - 3n operations (Initialize Dict + Process Input + Check Dict), which simplifies to O(n).
 * Space Complexity: O(n)
 * - Requires a Dictionary to store n key-value pairs.
 *
 */
IList<int> FindDisappearedNumbers(int[] nums) {
    List<int> list = new List<int>();
    Dictionary<int, int> dict = new Dictionary<int, int>();

    for(int i=1; i<=nums.Length; i++){
        dict.Add(i, 0);
    }

    for(int i=0; i<nums.Length; i++){
        dict[nums[i]] += 1;
    }

    for(int i=1; i<=nums.Length; i++){
        if(dict[i] == 0)
            list.Add(i);
    }

    return list;
}
