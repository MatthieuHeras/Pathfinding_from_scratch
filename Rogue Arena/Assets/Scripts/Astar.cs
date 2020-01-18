using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Tilemaps;

public static class Astar
{
    public static List<Vector2> FindPath(Vector3 startPosition, Vector3 targetPosition, ref NodeGrid ground)
    {
        List<Vector2> path = new List<Vector2>();
        Node current = null;
        Node start = ground.GetNode(new Vector2Int(Mathf.RoundToInt(startPosition.x), Mathf.RoundToInt(startPosition.y)));
        Node target = ground.GetNode(new Vector2Int(Mathf.RoundToInt(targetPosition.x - .1f), Mathf.RoundToInt(targetPosition.y)));
        // If the target is not reachable, return empty path
        if (!start.walkable || !target.walkable)
            return path;

        List<Node> open = new List<Node>();
        List<Node> closed = new List<Node>();

        open.Add(start);

        start.costs = WhatCosts(start, start, target);
        // First loop
        while (current != target && open.Count > 0)
        {
            // Get the lowest F cost
            current = open[0];
            foreach (Node node in open)
                if (node.costs.z < current.costs.z) // F cost
                    current = node;

            open.Remove(current);
            closed.Add(current);

            // Foreach Neighbours
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    Node neighbour = ground.GetNode(current.position + new Vector2((float)i / ground.getAccuracy() , (float)j / ground.getAccuracy()));
                    if (neighbour.walkable && !IsInList(neighbour, closed)) // Skip the unwalkable and closed nodes (includes the current one)
                    {
                        if (!IsInList(neighbour, open) || WhatCosts(current, neighbour, target).z < neighbour.costs.z)
                        {
                            neighbour.costs = WhatCosts(current, neighbour, target);
                            neighbour.parent = current;
                            if (!IsInList(neighbour, open))
                                open.Add(neighbour);
                        }
                    }
                }
            }
        }
        // Draw back the path
        while (current != null)
        {
            path.Add(current.position);
            current = current.parent;
        }
        path.Reverse();

        return path;
    }

    public static Vector3 WhatCosts(Node start, Node current, Node target)
    {
        // G = Real distance from start
        // H = Hypothetical distance to target
        float G = start.costs.x + Mathf.Sqrt(Mathf.Pow(current.position.x - start.position.x, 2) + Mathf.Pow(current.position.y - start.position.y, 2));
        float H = Mathf.Sqrt(Mathf.Pow(current.position.x - target.position.x, 2) + Mathf.Pow(current.position.y - target.position.y, 2));
        float F = G + H;
        return new Vector3(G, H, F);
    }

    private static bool IsInList(Node node, List<Node> list)
    {
        bool answer = false;
        foreach (Node n in list)
            if (n == node)
                answer = true;
        return answer;
    }
}
