/*
 * LeetCode Problem: Group Anagrams (49)
 * URL: https://leetcode.com/problems/group-anagrams/
 * Difficulty: Medium
 *
 * Description:
 * Given an array of strings 'strs', group the anagrams together.
 * You can return the answer in any order.
 *
 * The Strategy:
 * 1. Initialize a Dictionary where the Key is the sorted version of the string,
 * and the Value is a List of original strings belonging to that key.
 * 2. Iterate through every string in the input array.
 * 3. For each string:
 * - Create a sorted version (convert to char array -> sort -> convert back).
 * - Check if this sorted key exists in the Dictionary.
 * - If it exists, add the original string to the corresponding list.
 * - If not, create a new list for this key and add the string.
 * 4. Finally, return all the values (the lists of grouped strings) from the Dictionary.
 *
 * Time Complexity: O(N * K log K)
 * - N is the number of strings.
 * - K is the maximum length of a string.
 * - We iterate N times, and inside the loop, we sort a string of length K (K log K).
 *
 * Space Complexity: O(N * K)
 * - We store all strings in the dictionary.
 */
public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
        for(int i=0; i<strs.Length; i++){
            string sortedString = SortString(strs[i]);
            if(dict.ContainsKey(sortedString)){
                dict[sortedString].Add(strs[i]);
            }
            else{
                dict[sortedString] = new List<string>();
                dict[sortedString].Add(strs[i]);
            }
        }

        return new List<IList<string>>(dict.Values);
    }

    public string SortString(string x){
        char[] charArray = x.ToCharArray();
        Array.Sort(charArray);
        return new string(charArray);
    }
}
