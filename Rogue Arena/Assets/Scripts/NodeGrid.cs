using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class NodeGrid : MonoBehaviour
{
    public Tilemap tilemap;
    public Node[,] grid = new Node[0, 0];
    public int accuracy = 4;

    private Vector2Int gridSize;
    private Vector2 bottomLeftCorner;

    public void Start()
    {
        gridSize = new Vector2Int(tilemap.size.x * accuracy, tilemap.size.y * accuracy);
        bottomLeftCorner = new Vector2Int(-tilemap.size.x / 2, -tilemap.size.y / 2);
        grid = new Node[gridSize.x, gridSize.y];
        
        for (int i = 0; i < gridSize.x; i++)
        {
            for (int j = 0; j < gridSize.y; j++)
            {
                if (tilemap.GetTile(Vector3Int.RoundToInt(new Vector3((float)i / accuracy + bottomLeftCorner.x, (float)j / accuracy + bottomLeftCorner.y, 0))) == null)
                {
                    grid[i, j] = new Node(new Vector2((float)i / accuracy + bottomLeftCorner.x, (float)j / accuracy + bottomLeftCorner.y), null, false);
                }
                else
                    grid[i, j] = new Node(new Vector2((float)i / accuracy + bottomLeftCorner.x, (float)j / accuracy + bottomLeftCorner.y), null, true);
            }
        }
    }

    public Node GetNode(Vector2 position)
    {
        position -= bottomLeftCorner;
        if (position.x >= (float)gridSize.x || position.y >= (float)gridSize.y || position.x < 0 || position.y < 0)
        {
            return new Node(position, null, false);
        }
        return grid[Mathf.RoundToInt(position.x * accuracy), Mathf.RoundToInt(position.y * accuracy)];
    }

    public int getAccuracy(){
        return accuracy;
    }

    public void OnDrawGizmos()
    {
        foreach (Node n in grid)
        {
            Gizmos.color = (n.walkable) ? new Color(0,50,0) : new Color(50,0,0);
            Gizmos.DrawWireCube(new Vector3((1f / (2 * accuracy)) + n.position.x, (1f / (2 * accuracy)) + n.position.y, 0), new Vector3(.8f / accuracy, .8f / accuracy, .01f));
        }
    }
}
