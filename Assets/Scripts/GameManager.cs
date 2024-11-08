using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Node _startingNode;
    private Node _goalNode;
    public Pathfinding pf;
    public Player player;

    public static GameManager Instance;

    public void SetStartingNode(Node node)
    {
        if (_startingNode != null) PaintGameObject(_startingNode.gameObject, Color.white);
        _startingNode = node;
        PaintGameObject(_startingNode.gameObject, Color.green);
        player.SetPos(_startingNode.transform.position);
    }

    public void SetGoalNode(Node node)
    {
        if(_goalNode!=null) PaintGameObject(_goalNode.gameObject, Color.white);
        _goalNode = node;
        PaintGameObject(_goalNode.gameObject, Color.red);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //player.SetPath(pf.Dijkstra(_startingNode, _goalNode));

            //player.SetPath(pf.BFS(_startingNode, _goalNode));
            //StartCoroutine(pf.PaintDijkstra(_startingNode, _goalNode));
            //StartCoroutine(pf.PaintBFS(_startingNode, _goalNode));
            StartCoroutine(pf.PaintAStar(_startingNode, _goalNode));
            //pf.AStar(_startingNode, _goalNode);
        }
    }

    public void PaintGameObject(GameObject obj, Color color)
    {
        obj.GetComponent<Renderer>().material.color = color;
    }
}
