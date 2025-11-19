/*
 * LeetCode Problem: Build an Array With Stack Operations (1441)
 * URL: https://leetcode.com/problems/build-an-array-with-stack-operations/
 * Difficulty: Easy
 *
 * Description:
 * You are given a strictly increasing target array of unique integers taken from the range [1, n].
 * You must simulate reading numbers from 1 to n and building the target array using only two operations:
 *  - "Push": Put the current number into the array
 *  - "Pop" : Remove the last pushed number (used only when the number is not part of the target)
 *
 * Goal:
 * Return a list of operations that will generate the target array using this process.
 *
 * Key Insight:
 * You do NOT need an actual stack data structure. Instead, we only track which operations
 * should occur while conceptually treating the list of "Push"/"Pop" as the simulated stack.
 *
 * The Strategy:
 * 1. Maintain an index that points to the next required value in the target array.
 * 2. Iterate from 'i = 1' up to 'n' (or until the entire target array is built).
 * 3. For every number 'i':
 *      - Always perform a "Push" (since you read the stream value).
 *      - If 'i' matches the current target[index], keep it (just move index forward).
 *      - If 'i' does NOT match the target[index], immediately "Pop" (discard the number).
 * 4. Stop when all values of target have been constructed (index == target.Length).
 *
 *
 * Time Complexity: O(n)
 * - Each number from 1 to n is processed at most once.
 *
 * Space Complexity: O(1)
 * - Aside from the returned list of operations, no additional structures are needed.
 */
public IList<string> BuildArray(int[] target, int n) {
    List<string> list = new List<string>();
    int index = 0;

    for(int i=1; i<=n && index < target.Length; i++){
        list.Add("Push");
        if(i == target[index]){
            index++;
        }
        else if (i != target[index]){
            list.Add("Pop");
        }
    }

    return list;
}
