/*
 * LeetCode Problem: Evaluate Reverse Polish Notation (150)
 * URL: https://leetcode.com/problems/evaluate-reverse-polish-notation/
 * Difficulty: Medium
 *
 * Description:
 * You are given an array of tokens representing an arithmetic expression in Reverse Polish Notation (RPN).
 * Valid tokens include integers and the operators: "+", "-", "*", "/".
 * The RPN evaluation rules are:
 *   - When a number is seen → push it to the stack.
 *   - When an operator is seen → pop the top two numbers, apply the operator,
 *     and push the result back onto the stack.
 *
 * The Strategy:
 * 1. Iterate through all tokens.
 * 2. If the token is a number:
 *       - Convert and push it to the stack.
 * 3. If the token is an operator:
 *       - Pop the top two numbers (order matters: first popped = right operand).
 *       - Apply the operation: num1 <op> num2.
 *       - Push the resulting value back onto the stack.
 * 4. After all tokens are processed, the stack will contain exactly one value → the final result.
 *
 * Note on Division:
 * The problem specifies that integer division truncates toward zero, which matches C# behavior.
 *
 * Time Complexity: O(n)
 * - Every token is processed exactly once.
 *
 * Space Complexity: O(n)
 * - In the worst case, all tokens are numbers and stored on the stack temporarily.
 */
public int EvalRPN(string[] tokens) {
    Stack<int> stack = new Stack<int>();
    for(int i=0; i<tokens.Length; i++){
        int x = 0;
        
        if(tokens[i] == "+")
            x = stack.Pop() + stack.Pop();
        else if(tokens[i] == "-"){
            int num2 = stack.Pop();
            int num1 = stack.Pop();
            x = num1 - num2;
        }
        else if(tokens[i] == "*")
            x = stack.Pop() * stack.Pop();
        else if(tokens[i] == "/"){
            int num2 = stack.Pop();
            int num1 = stack.Pop();
            x = num1 / num2;
        }
        else
            x = int.Parse(tokens[i]);
            
        stack.Push(x);
    }
    return stack.Pop();
}
