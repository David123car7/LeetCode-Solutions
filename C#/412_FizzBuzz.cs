/*
 * LeetCode Problem: Fizz Buzz (412)
 * URL: https://leetcode.com/problems/fizz-buzz/
 * Difficulty: Easy
 *
 * Description:
 * Given an integer n, return a list of strings representing the numbers from 1 to n.
 * But for multiples of 3 return "Fizz", for multiples of 5 return "Buzz",
 * and for multiples of both 3 and 5 return "FizzBuzz".
 *
 * Solution Approach:
 * - Create an array of strings of size n (arrays implement IList<string>).
 * - For each number i from 1 to n:
 *     1. Build the result string:
 *        - Append "Fizz" if divisible by 3.
 *        - Append "Buzz" if divisible by 5.
 *     2. If nothing was appended, convert i to a string.
 *     3. Store the result in the array.
 * - Return the array, which satisfies the IList<string> return type.
 *
 * Author: David Carvalho
 * Date: 11/15/25
 */

public IList<string> FizzBuzz(int n) {
    string[] array = new string[n];
    for(int i=1; i<=n; i++){
        string answer = "";
        if(i % 3 == 0){
            answer += "Fizz";            
        }
        if(i % 5 == 0){
            answer += "Buzz";
        }
        else if(answer == ""){
            answer = i.ToString();
        }
        array[i-1] = answer;
    }

    return array;
}