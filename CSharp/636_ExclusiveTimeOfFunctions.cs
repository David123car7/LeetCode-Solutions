/*
 * LeetCode Problem: Exclusive Time of Functions (636)
 * URL: https://leetcode.com/problems/exclusive-time-of-functions/
 * Difficulty: Medium
 *
 * Description:
 * You are given 'n' functions, all identified by IDs in the range [0, n-1].
 * A log entry is always in the format: "function_id:start_or_end:timestamp".
 *
 * Each function may call other functions, creating a call stack.
 * The goal is to compute the *exclusive time* for each function:
 *   → the total time spent running that function alone,
 *     excluding any time spent inside functions it called.
 *
 * Key Insight (Simulate Call Stack):
 * The logs describe a timeline of nested function calls.
 * A stack is used to track which function is currently executing.
 *
 * The Strategy:
 * 1. Iterate over each log entry.
 * 2. Split the log into: functionId, type ("start"/"end"), and timestamp.
 * 3. Use a stack to simulate execution:
 *      - When a function "starts":
 *          • If another function was running, update its exclusive time
 *            using the difference between timestamps.
 *          • Push the new function onto the stack.
 *
 *      - When a function "ends":
 *          • Pop it from the stack because it finished.
 *          • Add its exclusive time using (end_timestamp + 1)
 *            since the ending timestamp is inclusive.
 *
 * 4. Maintain a 'lastPosition' variable:
 *      - Tracks the last processed timestamp.
 *      - The difference (current_timestamp - lastPosition)
 *        tells how long the current function was running.
 *
 *
 * Time Complexity: O(m)
 * - m is the number of log entries. Each entry is processed once.
 *
 * Space Complexity: O(n)
 * - A stack is required to simulate nested calls.
 */
public int[] ExclusiveTime(int n, IList<string> logs) {
    int[] output = new int[n];

    int lastPosition = 0;
    Stack<int> stack = new Stack<int>();
    for(int i=0; i<logs.Count; i++){
        string[] log = logs[i].Split(":");

        int functionId = int.Parse(log[0]);
        string functionType = log[1];
        int timestamp = int.Parse(log[2]);

        if(stack.Count == 0)
            stack.Push(functionId);
        else{
            int currentFunction = stack.Peek();
            if(functionType == "start"){
                stack.Push(functionId);
            }
            else{
                stack.Pop();
                timestamp += 1;
            }
            output[currentFunction] += timestamp - lastPosition;
            lastPosition = timestamp;
        }
    }
    return output;
}
