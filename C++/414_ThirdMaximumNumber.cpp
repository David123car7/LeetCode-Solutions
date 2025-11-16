/*
 * LeetCode Problem: Third Maximum Number (414)
 * URL: https://leetcode.com/problems/third-maximum-number/
 * Difficulty: Easy
 *
 * Description:
 * Given an integer array 'nums', return the third distinct maximum number.
 * If the third distinct maximum does not exist, return the maximum number instead.
 *
 * Key Insight:
 * Instead of sorting the array (O(n log n)), we can track the top three unique
 * maximum values in a single pass using three optional variables:
 *   - firstMax  → largest
 *   - secondMax → second largest
 *   - thirdMax  → third largest
 *
 * For each number:
 *   - Skip it if it matches any of the already stored max values (duplicate).
 *   - Otherwise, compare it in descending order:
 *        If greater than firstMax → shift first→second→third and update firstMax.
 *        Else if greater than secondMax → shift second→third and update secondMax.
 *        Else if greater than thirdMax → update thirdMax.
 *
 * Time Complexity: O(n)
 *   - Only one pass through the array.
 * Space Complexity: O(1)
 *   - Only three optional variables are used regardless of input size.
 *
 * Note:
 * std::optional<int> allows representing "unset" values safely,
 * We cant use INT_MIN because it belongs to the inverval of possible values in the nums input array
 */
int thirdMax(vector<int>& nums) {
    std::optional<int> firstMax;
    std::optional<int> secondMax;
    std::optional<int> thirdMax;

    int size = 0;
    for(int i=0; i<nums.size();i++){
        int num = nums.at(i);
        
        if(num == firstMax || num == secondMax || num == thirdMax)
            continue;

        if(!firstMax.has_value() || num > firstMax){
            thirdMax = secondMax;
            secondMax = firstMax;
            firstMax = num;
        }
        else if(!secondMax.has_value() || num > secondMax){
            thirdMax = secondMax;
            secondMax = num;
        }
        else if(!thirdMax.has_value() || num > thirdMax){
            thirdMax = num;
        }

        size++;
    }

    if(size >= 3) return *thirdMax;
    else return *firstMax;
}
