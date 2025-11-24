/*
* LeetCode Problem: Top K Frequent Elements (347)
* URL: https://leetcode.com/problems/top-k-frequent-elements/
* Difficulty: Medium
*
* Description:
* Given an integer array 'nums' and an integer 'k', return the 'k' most frequent elements.
* You may return the answer in any order.
*
* Goal:
* Identify the numbers that appear most often with a time complexity better than O(N log N).
*/

/*
* Key Insight:
* The maximum possible frequency of any number is N (the size of the array).
* This allows us to use "Bucket Sort". Instead of sorting elements by frequency (which costs O(N log N)),
* we can create an array where the 'Index' represents the 'Frequency'.
*
* The Strategy:
* 1. Count Frequencies: Use a Dictionary to map each number to its count.
* 2. Bucket Logic:
* - Create an array of Lists 'bucket' where size is nums.Length + 1.
* - Iterate through the dictionary. If a number has count 'c', add it to the list at bucket[c].
* 3. Gather Results:
* - Iterate through the bucket array backwards (from highest frequency to lowest).
* - Add elements from the current bucket to the result array.
* - Stop adding immediately once we have collected 'k' elements to avoid overflow.
*
* Time Complexity: O(N)
* - Counting frequencies takes O(N).
* - Distributing into buckets takes O(N).
* - Gathering results takes O(N) (we stop after k elements, but traverse empty buckets quickly).
*
* Space Complexity: O(N)
* - We store counts in a Dictionary and grouping in the Bucket Array.
*/
public int[] TopKFrequent(int[] nums, int k) {
    int[] result = new int[k];
    List<int>[] bucket = new List<int>[nums.Length+1]; //Index will be the count of the numbers
    Dictionary<int, int> dict = new Dictionary<int, int>();

    for(int i=0; i<nums.Length; i++){
        if(!dict.ContainsKey(nums[i]))
            dict[nums[i]] = 1;
        else
            dict[nums[i]] += 1;
    }

    foreach (int key in dict.Keys){
        if(bucket[dict[key]] == null)
            bucket[dict[key]] = new List<int>();

        bucket[dict[key]].Add(key);
    }

    int index = 0;
    for(int i=bucket.Length-1; i>=0 && index < k; i--){
        if(bucket[i] != null && bucket[i].Count != 0){
            for(int j=0; j<bucket[i].Count; j++){
                result[index] = bucket[i][j];
                index++;
            }
        }
    }

    return result;
}

/*
* Key Insight:
* This approach uses a "Greedy Selection" strategy. Instead of using a bucket sort strategy,
* we simply perform a linear scan to find the "winner" (max frequency), remove it, and repeat the process 'k' times.
*
* The Strategy:
* 1. Frequency Map: Iterate through 'nums' to count the occurrence of each number in a Dictionary.
* 2. Selection Loop: Run a loop exactly 'k' times (to find the top k items).
* 3. Find Max:
* - Inside the loop, iterate through every key currently in the Dictionary.
* - Track the key associated with the highest frequency value found so far.
* 4. Extraction:
* - Add the "winner" key to the result array.
* - Remove the "winner" key from the Dictionary to ensure it isn't picked again in the next pass.
*
* Time Complexity: O(N * k)
* - Building the dictionary takes O(N).
* - We iterate 'k' times, and in each iteration, we scan the dictionary keys (up to N items).
* - If k is small, this is fast. If k is close to N, this approaches O(N^2).
*
* Space Complexity: O(N)
* - We store up to N distinct elements in the Dictionary.
*/
public int[] TopKFrequent(int[] nums, int k) {
    int[] result = new int[k];
    Dictionary<int, int> dict = new Dictionary<int, int>();

    for(int i=0; i<nums.Length; i++){
        if(!dict.ContainsKey(nums[i]))
            dict[nums[i]] = 1;
        else
            dict[nums[i]] += 1;
    }

    for(int i=0; i<k; i++){
        int max = int.MinValue;
        int key = 0;
        foreach(int x in dict.Keys){
            if(dict[x] > max){
                max = dict[x];
                key = x;
            }
        }
        dict.Remove(key);
        result[i] = key;
    }

    return result;
}
