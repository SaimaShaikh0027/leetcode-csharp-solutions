# Pascal's Triangle

## Problem Statement

Given an integer `numRows`, return the first `numRows` of Pascal's Triangle.

In Pascal's Triangle:

- The first and last element of every row is always `1`.
- Every other element is the sum of the two elements directly above it from the previous row.

### Example

Input:

```text
numRows = 5
```

Output:

```text
[
     [1],
    [1,1],
   [1,2,1],
  [1,3,3,1],
 [1,4,6,4,1]
]
```

---

# Understanding Pascal's Triangle

Each row starts and ends with `1`.

Every middle element is calculated using:

```text
PreviousRow[j-1] + PreviousRow[j]
```

Example:

```text
Row 2: [1,1]

Row 3:

1
1 + 1 = 2
1

=> [1,2,1]
```

---

# Approach

## Idea

Build the triangle row by row.

For every row:

- First element = 1
- Last element = 1
- Middle elements = sum of two elements from the previous row

Store every row in the final result list.

---

## Step-by-Step Algorithm

### Step 1

Create an empty list called `result`.

```csharp
IList<IList<int>> result = new List<IList<int>>();
```

---

### Step 2

Traverse from row `0` to `numRows - 1`.

```csharp
for(int i = 0; i < numRows; i++)
```

---

### Step 3

Create a new row.

```csharp
List<int> rows = new List<int>();
```

---

### Step 4

Traverse columns inside the current row.

```csharp
for(int j = 0; j <= i; j++)
```

Each row contains `i + 1` elements.

---

### Step 5

Handle first and last elements.

```csharp
if(j == 0 || j == i)
{
    rows.Add(1);
}
```

Reason:

The first and last element of every row is always `1`.

---

### Step 6

Calculate middle elements.

```csharp
int value = result[i - 1][j - 1] + result[i - 1][j];
rows.Add(value);
```

Take two values from the previous row and add them.

---

### Step 7

After completing the row, add it to the result.

```csharp
result.Add(rows);
```

---

### Step 8

Return the final triangle.

```csharp
return result;
```

---

# Dry Run

## Row 0

```text
[1]
```

Result:

```text
[
 [1]
]
```

---

## Row 1

```text
[1,1]
```

Result:

```text
[
 [1],
 [1,1]
]
```

---

## Row 2

First element = 1

Middle element:

```text
1 + 1 = 2
```

Last element = 1

Row:

```text
[1,2,1]
```

Result:

```text
[
 [1],
 [1,1],
 [1,2,1]
]
```

---

## Row 3

First element = 1

Middle elements:

```text
1 + 2 = 3

2 + 1 = 3
```

Last element = 1

Row:

```text
[1,3,3,1]
```

---

## Final Result

```text
[
 [1],
 [1,1],
 [1,2,1],
 [1,3,3,1],
 [1,4,6,4,1]
]
```

---

# Why This Approach Works

Each row depends on the previous row.

By storing all previously generated rows inside `result`, we can easily access:

```csharp
result[i - 1][j - 1]
```

and

```csharp
result[i - 1][j]
```

to calculate the current value.

This follows the mathematical property of Pascal's Triangle.

---

# Time Complexity

## O(n²)

Reason:

For `numRows = n`

- Row 1 has 1 element
- Row 2 has 2 elements
- Row 3 has 3 elements

Total operations:

```text
1 + 2 + 3 + ... + n
```

which equals:

```text
O(n²)
```

---

# Space Complexity

## O(n²)

Reason:

We store the entire Pascal's Triangle.

For `n` rows:

```text
1 + 2 + 3 + ... + n
```

elements are stored.

Therefore:

```text
O(n²)
```

---

# Key Learning

✅ Pascal's Triangle is a pattern-based problem.

✅ Every row depends on the previous row.

✅ The first and last elements are always `1`.

✅ Middle elements are obtained using:

```text
PreviousRow[j-1] + PreviousRow[j]
```

✅ This problem teaches how to build results incrementally using previously computed values.

---

# Interview Takeaway

When solving pattern generation problems:

1. Identify the repeating pattern.
2. Determine base cases.
3. Use previously generated results to build the next result.
4. Think about how rows and columns are related.

Pascal's Triangle is a classic example of Dynamic Programming style thinking where a current value depends on previously computed values.