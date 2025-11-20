/*
 * LeetCode Problem: Daily Temperatures (739)
 * URL: https://leetcode.com/problems/daily-temperatures/
 * Difficulty: Medium
 *
 * Description:
 * Given an array 'temperatures', where temperatures[i] represents the temperature
 * of the i-th day, compute for each day how many days you must wait until a
 * warmer temperature appears. If no warmer day exists, the answer is 0.
 *
 * The Strategy (Monotonic Stack – O(n) Solution):
 * 1. Use a stack to store indices of days whose next warmer temperature
 *    has not yet been found.
 * 2. Iterate through the array:
 *      - While the current day's temperature is greater than the temperature
 *        at the index on top of the stack, the current day is the next
 *        warmer day for that index. Pop the index and compute the difference.
 *      - Push the current index after all applicable updates have been made.
 *
 * This approach ensures each index is pushed and popped at most once and
 * avoids the need for nested loops.
 *
 * Time Complexity: O(n)
 * - Each index is processed at most twice (one push, one pop).
 *
 * Space Complexity: O(n)
 * - The stack may contain up to n indices in the worst case.
 */
public int[] DailyTemperatures(int[] temperatures) {
    int[] output = new int[temperatures.Length];
    Stack<int> stack = new Stack<int>();

    for(int i=0; i<temperatures.Length; i++){
        while(stack.Count > 0 && temperatures[i] > temperatures[stack.Peek()]){
            int x = stack.Pop();
            output[x] = i - x;
        }
        stack.Push(i);
    }

    return output;
}
