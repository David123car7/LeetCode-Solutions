/*
 * LeetCode Problem: Palindrome Number (9)
 * URL: https://leetcode.com/problems/palindrome-number/
 * Difficulty: Easy
 *
 * Description:
 * Determine whether an integer 'x' is a palindrome. An integer is a palindrome
 * when it reads the same forward and backward. Negative numbers are not
 * palindromes because of the '-' sign.
 *
 * Approach (Classic Divisor Method):
 * 1. Handle negative numbers immediately (cannot be palindromes).
 * 2. Build a divisor 'div' equal to the highest power of 10 inside the number.
 * 3. Use a working copy 'num' of the original number.
 *    Repeatedly compare:
 *         - first digit: num / div
 *         - last digit : num % 10
 *    If they differ → not a palindrome.
 *
 * 4. Remove the first and last digits:
 *         num = (num % div) / 10;
 *
 * 5. Shrink the divisor by two places (two digits removed):
 *         div = div / 100;
 *
 * 6. Continue until all digit pairs have been checked.
 *
 */
public bool IsPalindrome(int x) {
    if(x < 0)
        return false;

    int div = 1;
    while (x / div >= 10) //Is the number still at least 2 digits long?
        div = div * 10;

    int num = x;
    while(num != 0){
        int firstNumber = num / div;
        int lastNumber = num % 10;

        if(firstNumber != lastNumber)
            return false;
        
        num = (num % div) / 10;
        div = div / 100;
    }

    return true;
}