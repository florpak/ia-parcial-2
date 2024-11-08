using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    GameObject[,] _grid;
    [SerializeField] int _width;
    [SerializeField] int _height;
    [SerializeField] GameObject _nodePrefab;
    [SerializeField] float _offset;
    // Start is called before the first frame update
    void Start()
    {
        _grid = new GameObject[_width, _height];
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                GameObject newNode = Instantiate(_nodePrefab, transform);
                newNode.GetComponent<Node>().Initialize(x, y, new Vector3(x + x * _offset, y + y * _offset, 0), this);
                _grid[x, y] = newNode;
            }
        }
    }

    public Node GetNode(int x, int y)
    {
        if (x < 0 || x >= _width || y < 0 || y >= _height) return null;
        return _grid[x, y].GetComponent<Node>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
