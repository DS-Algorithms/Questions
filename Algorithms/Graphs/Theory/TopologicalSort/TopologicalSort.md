# Topological Ordering

(TopologicalOrdering.png)
`Image courtesy: William Fiset`
 
- A topological ordering is an ordering of the nodes in a directed graph where for each directed edge from node A to node B, node A appears before node B in the ordering.
- The topological sort algorithm can find a topological ordering in **O(V+E)** time!
- NOTE: Topological orderings are NOT unique.
- The only type of graph which has a valid topological ordering is a **Directed Acyclic Graph** (DAG)
    - These are graphs with directed edges and no cycles.
- By definition, all rooted trees have a topological ordering since they do not contain any cycles.


## # Topological Sort Algorithm

- Pick an unvisited node
- Beginning with the selected node, do a Depth First Search (DFS) exploring only unvisited nodes.
- On the recursive callback of the DFS, add the current node to the topological ordering in reverse order.