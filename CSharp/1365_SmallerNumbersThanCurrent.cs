/*
 * LeetCode Problem: Smaller Numbers Than Current (1365)
 * URL: https://leetcode.com/problems/how-many-numbers-are-smaller-than-the-current-number/
 * Difficulty: Easy
 *
 * Description:
 * Given the array nums, for each nums[i] find out how many numbers in the array are smaller than it. 
 * That is, for each nums[i] you have to count the number of valid j's such that j != i and nums[j] < nums[i].
 * Return the answer in an array.
 *
 * Approach (Brute Force):
 *   - For each element nums[i], scan the entire array and count how many values
 *     are strictly less than nums[i].
 *   - Skip comparing the element with itself (i == j).
 *
 */
public int[] SmallerNumbersThanCurrent(int[] nums) {
    int[] result = new int[nums.Length];

    int x = 0;
    for(int i=0; i<nums.Length; i++){
        int count = 0;
        for(int j=0; j<nums.Length; j++){
            if(i == j)
                continue;
            
            if(nums[i] > nums[j])
                count++;
        }
        result[x] = count;
        x++;
    }

    return result;
}

/*
 * LeetCode Problem: Smaller Numbers Than Current (1365)
 * URL: https://leetcode.com/problems/how-many-numbers-are-smaller-than-the-current-number/
 * Difficulty: Easy
 *
 * Description:
 * For each number in the input array 'nums', return how many numbers are
 * strictly smaller than nums[i]. The result must preserve the original order.
 *
 * Approach (Optimized Using Sorting + Dictionary):
 *   1. Clone and sort the array. In the sorted array, the first index of
 *      each number indicates how many values are strictly smaller than it.
 *   2. Build a dictionary that maps each unique number → its first index
 *      in the sorted array.
 *   3. For each original element in 'nums', lookup the mapped value and
 *      store it in the result.
 *
 */
public int[] SmallerNumbersThanCurrent(int[] nums) {
    Dictionary<int, int> dict = new Dictionary<int,int>();
    int[] result = new int[nums.Length];

    int[] sortedArray = (int[])nums.Clone();
    Array.Sort(sortedArray);

    for(int i=0; i<sortedArray.Length; i++){
        if(!dict.ContainsKey(sortedArray[i]))
            dict.Add(sortedArray[i], i);
    }

    for(int i=0; i<nums.Length; i++){
        result[i] = dict[nums[i]];
    }

    return result;
}