# Set Matrix Zeroes

## Problem Statement

Given an `m x n` integer matrix, if an element is `0`, set its entire row and column to `0`.

You must do it in-place.

### Example

Input:

matrix =
[
 [1,1,1],
 [1,0,1],
 [1,1,1]
]

Output:

[
 [1,0,1],
 [0,0,0],
 [1,0,1]
]

---

# Approach 1: Brute Force

## Idea

Whenever we find a `0`, we need to make the entire row and column `0`.

The challenge is that if we immediately start converting elements to `0`, we may accidentally create new zeros and lose track of the original ones.

To avoid this, we first mark the cells that need to become `0` and then update the matrix.

---

## Steps

1. Traverse the matrix.
2. Whenever a `0` is found:
   - Mark all non-zero elements in that row.
   - Mark all non-zero elements in that column.
3. Use a special marker value (for example `-1`) to indicate that the cell should eventually become `0`.
4. After the traversal is complete:
   - Convert all marked cells into `0`.

---

## Dry Run

Matrix:

[
 [1,1,1],
 [1,0,1],
 [1,1,1]
]

Found 0 at position (1,1)

Mark row 1:

[
 [1,1,1],
 [-1,0,-1],
 [1,1,1]
]

Mark column 1:

[
 [1,-1,1],
 [-1,0,-1],
 [1,-1,1]
]

Convert all -1 to 0

Result:

[
 [1,0,1],
 [0,0,0],
 [1,0,1]
]

---

## Time Complexity

O(m × n × (m + n))

Reason:

For every zero found, we may need to scan an entire row and an entire column.

---

## Space Complexity

O(1)

Reason:

No additional arrays are used.

---

# Approach 2: Better Solution

## Idea

Instead of repeatedly scanning rows and columns, maintain two arrays:

- row[]
- col[]

These arrays store which rows and columns should be converted to zero.

---

## Steps

### First Traversal

Whenever matrix[i][j] == 0:

Store:

row[i] = 1
col[j] = 1

### Second Traversal

For each cell:

If:

row[i] == 1

OR

col[j] == 1

then make matrix[i][j] = 0

---

## Dry Run

Matrix:

[
 [1,1,1],
 [1,0,1],
 [1,1,1]
]

row = [0,1,0]

col = [0,1,0]

Second traversal:

Any cell belonging to row 1 or column 1 becomes 0.

Result:

[
 [1,0,1],
 [0,0,0],
 [1,0,1]
]

---

## Time Complexity

O(m × n)

Reason:

We traverse the matrix only twice.

---

## Space Complexity

O(m + n)

Reason:

Extra row[] and col[] arrays are used.

---

# Approach 3: Optimized Solution

## Idea

Can we eliminate the extra row[] and col[] arrays?

Yes.

We can use:

- First row as column markers
- First column as row markers

This way we reuse the matrix itself as storage.

---

## Key Observation

Instead of creating:

row[]
col[]

Store markers directly inside matrix.

Example:

matrix[i][0]

stores whether row i should become zero.

matrix[0][j]

stores whether column j should become zero.

---

## Steps

### Step 1

Traverse the matrix.

Whenever matrix[i][j] == 0:

Set:

matrix[i][0] = 0

matrix[0][j] = 0

---

### Step 2

Traverse the matrix again (excluding first row and first column).

If:

matrix[i][0] == 0

OR

matrix[0][j] == 0

then:

matrix[i][j] = 0

---

### Step 3

Handle first row and first column separately because they are being used as markers.

---

## Why This Works

The first row remembers which columns must become zero.

The first column remembers which rows must become zero.

Thus we avoid creating additional arrays.

---

## Dry Run

Matrix:

[
 [1,1,1],
 [1,0,1],
 [1,1,1]
]

Encounter 0 at (1,1)

Mark:

matrix[1][0] = 0

matrix[0][1] = 0

Matrix becomes:

[
 [1,0,1],
 [0,0,1],
 [1,1,1]
]

Now use markers.

Row 1 becomes zero.
Column 1 becomes zero.

Result:

[
 [1,0,1],
 [0,0,0],
 [1,0,1]
]

---

## Time Complexity

O(m × n)

Reason:

Only two traversals of the matrix.

---

## Space Complexity

O(1)

Reason:

No extra array is used.

The matrix itself is utilized for storing markers.

---

# Key Learning

✅ Matrix problems often require careful handling of updates.

✅ Directly modifying data while traversing can create incorrect results.

✅ Using extra arrays is a common optimization over brute force.

✅ Reusing existing matrix cells as markers is a powerful space optimization technique.

✅ This is a very common interview pattern involving in-place modification.

---

# Interview Takeaway

When solving matrix problems, think in this order:

1. Brute Force
2. Extra Array Optimization
3. In-Place Optimization

This progression shows strong problem-solving skills during interviews.
