# Two Sum

## Problem Statement

Given an array of integers `nums` and an integer `target`, return the indices of the two numbers such that they add up to the target.

Example:

Input:
nums = [2,7,11,15]
target = 9

Output:
[0,1]

---

# Approach 1: Brute Force

## Idea

The simplest way is to compare every element with every other element.

We use two loops:

1. First loop picks one number.
2. Second loop checks all remaining numbers.
3. If the sum of both numbers equals the target, return their indices.

## Steps

1. Start with index 0.
2. Compare it with all elements after it.
3. Check if:

   nums[i] + nums[j] == target

4. If yes, return the indices.
5. Otherwise continue checking.

## Dry Run

nums = [2,7,11,15]
target = 9

i = 0 → nums[i] = 2

j = 1 → nums[j] = 7

2 + 7 = 9 ✅

Return [0,1]

## Time Complexity

O(n²)

Reason:
For every element we are checking all other elements.

## Space Complexity

O(1)

Reason:
No extra data structure is used.

---

# Approach 2: Optimized Solution (Dictionary)

## Why Brute Force Is Slow

In the brute-force approach we repeatedly scan the array.

Instead of searching again and again, we can store previously visited numbers in a Dictionary.

A Dictionary provides nearly O(1) lookup time.

---

## Idea

For every number:

1. Find the complement.

   complement = target - currentNumber

2. Check whether the complement already exists in the Dictionary.

3. If it exists:
   - We found the answer.
   - Return indices.

4. Otherwise:
   - Store current number and its index in the Dictionary.

---

## Dry Run

nums = [2,7,11,15]
target = 9

Dictionary = {}

Step 1:

Current Number = 2

Complement = 9 - 2 = 7

7 not found

Store:
{
  2 : 0
}

Step 2:

Current Number = 7

Complement = 9 - 7 = 2

2 found in Dictionary ✅

Return [0,1]

---

## Why Dictionary Works

Instead of searching the array again,
we directly check whether the required complement exists.

Example:

Target = 9

Current Number = 7

Required Number = 2

Rather than searching the whole array,
we ask the Dictionary:

"Do you already have 2?"

Dictionary answers in nearly O(1) time.

---

## Time Complexity

O(n)

Reason:
We traverse the array only once.

Dictionary lookup is O(1).

---

## Space Complexity

O(n)

Reason:
In the worst case all array elements are stored in the Dictionary.

---

# Key Learning

✅ Brute Force is easier to understand but slower.

✅ Dictionary helps avoid nested loops.

✅ Whenever a problem asks:
- Find Pair
- Find Target Sum
- Lookup Existing Value

Think about using a HashMap/Dictionary.

✅ This is one of the most common interview patterns.