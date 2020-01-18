using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public Vector2 position;
    public Node parent;
    public bool walkable;
    // G(starting) - H(target) - F(G+H)
    public Vector3 costs;

    public Node(Vector2 position, Node parent, bool walkable)
    {
        this.position = position;
        this.parent = parent;
        this.walkable = walkable;
        this.costs = Vector3.zero;
    }
}
