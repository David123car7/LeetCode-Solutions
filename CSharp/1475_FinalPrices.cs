/*
 * LeetCode Problem: Final Prices With a Special Discount in a Shop (1475)
 * URL: https://leetcode.com/problems/final-prices-with-a-special-discount-in-a-shop/
 * Difficulty: Easy
 *
 * Description:
 * You are given an array 'prices' where prices[i] represents the cost of the i-th item.
 * For each item i, you search for the first item j > i such that prices[j] <= prices[i].
 * If such an item exists, prices[j] is the discount applied to prices[i].
 * If no such item exists, the discount is 0.
 */

/* The Strategy (Monotonic Stack):
 * 1. Use a stack to store indices of items whose discount has not been determined yet.
 * 2. Iterate through the array:
 *      - While the current price is less than or equal to the price at the index
 *        on top of the stack, the current price becomes the discount for that index.
 *        Pop the index and apply the discount.
 *      - Push the current index after all applicable discounts have been applied.
 *
 * This ensures each index is pushed and popped at most once, allowing us to
 * efficiently determine the first price to the right that is less than or equal
 * to the current one without redundant scanning.
 *
 * Time Complexity: O(n)
 * - Each element is processed at most twice (pushed once, popped once).
 *
 * Space Complexity: O(n)
 * - The stack may contain up to n indices in the worst case.
 */
public int[] FinalPrices(int[] prices) {
    int[] output = prices;
    Stack<int> stack = new Stack<int>();
    for(int i=0; i<prices.Length; i++){
        while(stack.Count != 0 && output[i] <= output[stack.Peek()]){
            int x = stack.Pop();
            output[x] -= output[i];
        }
        stack.Push(i);
    }

    return output;
}



/*
 * The Strategy (Brute Force Approach):
 * 1. For each price at index i:
 *      - Scan forward in the array (j = i + 1 to end).
 *      - Find the first j where prices[j] <= prices[i].
 *      - Apply this value as the discount.
 *
 * 2. If no valid j is found, discount remains 0.
 *
 * Time Complexity: O(n²)
 * - For each element, we may scan the rest of the array.
 *
 * Space Complexity: O(n)
 * - Output array of size n. No extra data structures used.
 *
 * Note:
 * The optimal solution uses a Monotonic Stack and runs in O(n),
 * but this brute-force version is simple and easy to understand.
 */
public int[] FinalPrices(int[] prices) {
    int[] output = new int[prices.Length];
    for(int i=0; i<prices.Length; i++){
        int descount = 0;
        for(int j=i+1; j<prices.Length; j++){
            if(prices[j] <= prices[i]){
                descount = prices[j];
                break;
            }
        }
        output[i] = prices[i] - descount;
    }
    return output;
}


