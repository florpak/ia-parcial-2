using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    int _x;
    int _y;
    Grid _grid;
    List<Node> _neighbors = new List<Node>();
    public List<Node> GetNeighbors()
    {
        if(_neighbors.Count > 0)
        {
            return _neighbors;
        }    
        _neighbors = new List<Node>();
        Node neighbor;
        neighbor = _grid.GetNode(_x + 1, _y);
        if (neighbor != null) _neighbors.Add(neighbor);
        neighbor = _grid.GetNode(_x - 1, _y);
        if (neighbor != null) _neighbors.Add(neighbor);
        neighbor = _grid.GetNode(_x, _y + 1);
        if (neighbor != null) _neighbors.Add(neighbor);
        neighbor = _grid.GetNode(_x, _y - 1);
        if (neighbor != null) _neighbors.Add(neighbor);

        return _neighbors;
    }
    public void Initialize(int x, int y, Vector3 pos, Grid grid)
    {
        this._x = x;
        this._y = y;
        transform.position = pos;
        this._grid = grid;
        gameObject.name = "Node: " + _x + "," + _y;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        foreach(Node node in GetNeighbors())
        {
            Gizmos.DrawLine(transform.position, node.transform.position);
        }
    }
}
