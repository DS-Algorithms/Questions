# Lattice Paths
 
#### Question
   
    Count the number of unique paths to travel from the top left to the bottom right of a lattice of squares. 
    
    NOTE: 
    - You are traveling along the **EDGES** of the lattice
    - When moving through the lattice, you can only move either down or to the right.
   
    Input:     An integer N (which is the width of the lattice)
               An integer M (which is the height of the lattice)
   
    Output:    An interger (which represents the number of unique paths)
   
    Resources:
      1: https://projecteuler.net/problem=15
      2: https://en.wikipedia.org/wiki/Lattice_path      

# Example 1:

```
Input:  2 3
Output: 10

 Explanation:

        (2 x 3 lattice of squares)
        __ __ __
        |__|__|__|
        |__|__|__|
 
        Diagram:
        
        1__1__1__1
        |  |  |  |
        1__2__3__4
        |  |  |  |
        1__3__6__10

 10 (number of unique paths from top left corner to bottom
                right)
 ```
 
# Example 2:

```
Input:  10, 10
Output: 184756
```
# Example 3:

```
Input:  17, 14
Output: 265182525
```

# Constraints:

 
# Solution
Recursive: 
Tabulation: 