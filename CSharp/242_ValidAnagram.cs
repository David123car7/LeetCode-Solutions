/*
 * LeetCode Problem: Valid Anagram (242)
 * URL: https://leetcode.com/problems/valid-anagram/
 * Difficulty: Easy
 *
 * Description:
 * Given two strings 's' and 't', return true if 't' is an anagram of 's', and false otherwise.
 * An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase,
 * typically using all the original letters exactly once.
 *
 * Goal:
 * Determine if both strings contain the exact same characters with the exact same frequencies.
 */

/*
* Key Insight:
* Since the problem is constrained to lowercase English letters, we don't need the overhead
* of a Dictionary/Hash Table. We can use a fixed-size integer array of length 26.
* This provides O(1) access time without hashing and guarantees constant space usage.
*
* The Strategy:
* 1. Length Check: If 's' and 't' have different lengths, return false immediately.
* 2. Initialization: Create an integer array 'counts' of size 26 (indices 0-25).
* 3. Simultaneous Processing (Net Zero):
* - Iterate through the strings using a single loop.
* - For char in 's': Calculate index (char - 'a') and increment (+1).
* - For char in 't': Calculate index (char - 'a') and decrement (-1).
* 4. Validation:
* - Iterate through the 'counts' array (not the strings).
* - If any value is not 0, it means there was an imbalance. Return false.
* 5. Return true if the loop completes with all zeros.
*
* Example: b - a = 98 - 97 = 1
*
* Time Complexity: O(n)
* - We iterate through the strings once (N) and the fixed array once (26).
*
* Space Complexity: O(1)
* - The array size is fixed at 26 integers, regardless of input string size.
*/
public bool IsAnagram(string s, string t) {
    if(s.Length != t.Length)
        return false;

    int[] array = new int[26];
    for(int i=0; i<array.Length; i++){
        array[i] = 0;
    }

    for(int i=0; i<s.Length; i++){
        int index = s[i] - 'a';
        int index2 = t[i] - 'a';

        array[index] += 1;
        array[index2] -= 1;
    }

    for(int i=0; i<array.Length; i++){
        if(array[i] != 0)
            return false;
    }

    return true;
}

/*
* The Strategy:
* 1. Length Check: If lengths differ, they cannot be anagrams. Return false.
* 2. Accumulate: Iterate through 's' and populate the Dictionary with character counts (+1).
* 3. Reduce: Iterate through 't'.
* - If a character in 't' does not exist in the dictionary, return false immediately.
* - Otherwise, decrement the count (-1) for that character.
* 4. Verify: Iterate through the characters of 's' one last time.
* - Check if the remaining count for each character is exactly 0.
* - If any value is non-zero, return false.
*
* Time Complexity: O(n)
* - We iterate through the strings linearly..
*
* Space Complexity: O(1) *
* - Uses a single Dictionary. Upper bound is 26 entries for English lowercase letters.
* (* O(n) in the worst case for full Unicode support).
*/
public bool IsAnagram(string s, string t) {
    if(s.Length != t.Length)
        return false;

    Dictionary<char, int> dict1 = new Dictionary<char, int>();

    for(int i=0; i<s.Length; i++){
        if(!dict1.ContainsKey(s[i]))
            dict1.Add(s[i], 1);
        else
            dict1[s[i]] += 1;
    }

    for(int i=0; i<t.Length; i++){
        if(!dict1.ContainsKey(t[i]))
            return false;
        else
            dict1[t[i]] -= 1;
    }

    for(int i=0; i<t.Length; i++){
        if(dict1[s[i]] != 0)
            return false;
    }

    return true;
}




/*
 *
 * The Strategy:
 * 1. Immediate Check: If the lengths of 's' and 't' are different, they cannot be anagrams.
 * 2. Frequency Maps: Create two Dictionaries to store the character counts for each string.
 * 3. Population:
 * - Iterate through 's' to populate the first dictionary.
 * - Iterate through 't' to populate the second dictionary.
 * 4. Verification:
 * - Iterate through the indices of the strings one last time.
 * - For every character at current index 'i' in 's', check if it exists in the second
 * dictionary and if the frequency counts match.
 * 5. Return false if any mismatch is found; otherwise, return true.
 *
 * Time Complexity: O(n)
 * - We iterate through the strings three times (two for population, one for verification).
 *
 * Space Complexity: O(1) *
 * - Although we use two Dictionaries, if the input is restricted to the lowercase English alphabet,
 * the size of the dictionaries will never exceed 26 entries, regardless of input size.
 * (* If the input covers all Unicode characters, space is O(n)).
 */
public bool IsAnagram(string s, string t) {
    if(s.Length != t.Length)
        return false;

    Dictionary<char, int> dict1 = new Dictionary<char, int>();
    Dictionary<char, int> dict2 = new Dictionary<char, int>();

    for(int i=0; i<s.Length; i++){
        if(!dict1.ContainsKey(s[i]))
            dict1.Add(s[i], 1);
        else
            dict1[s[i]] += 1;
    }

    for(int i=0; i<t.Length; i++){
        if(!dict2.ContainsKey(t[i]))
            dict2.Add(t[i], 1);
        else
            dict2[t[i]] += 1;
    }

    for(int i=0; i<t.Length; i++){
        if(!dict1.ContainsKey(s[i]) || !dict2.ContainsKey(s[i]))
            return false;

        if(dict1[s[i]] != dict2[s[i]])
            return false;
    }

    return true;
}



