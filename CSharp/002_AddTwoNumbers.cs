/*
 * LeetCode Problem: Add Two Numbers (2)
 * URL: https://leetcode.com/problems/add-two-numbers/
 * Difficulty: Medium
 *
 * Description:
 * You are given two non-empty linked lists representing two non-negative integers.
 * The digits are stored in reverse order, and each node contains a single digit.
 * Add the two numbers and return the sum as a linked list.
 * The linked list result must also be stored in reverse order.
 *
 * Solution Approach:
 * - Traverse both linked lists simultaneously.
 * - At each step:
 *   1. Extract the current digit from each list (or 0 if the list ended).
 *   2. Add the two digits plus any carry from the previous step.
 *   3. Store the last digit of the sum in a new node.
 *   4. Update the carry for the next iteration.
 * - Continue until both lists end and the carry is zero.
 * - This approach avoids number overflow by never converting the lists into integers.
 *
 * Author: David Carvalho
 * Date: 2025-02-14
 */

 /**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
 
public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        ListNode newList = new ListNode(0, null);
        ListNode newListAux = newList;

        int carry = 0;
        while(l1 != null || l2 != null || carry != 0){
            int num1 = 0;
            int num2 = 0;
            if(l1 != null){
                num1 = l1.val;
                l1 = l1.next;
            }
            else{
                num2 = 0;
            }

            if(l2 != null){
                num2 = l2.val;
                l2 = l2.next;
            }
            else{
                num2 = 0;
            }

            int sum = num1 + num2 + carry;
            int sumFinal = sum % 10;

            if(sum >= 10)
                carry = 1;
            else
                carry = 0;
            
            newListAux.val = sumFinal;

            if(l1 != null || l2 != null || carry != 0){
                newListAux.next = new ListNode(0,null);
                newListAux = newListAux.next;
            }
        }


        return newList;
    }
}