using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Parcial_Node _startingNode;
    private Parcial_Node _goalNode;
    public Parcial_Pathfinding pf;
    public Parcial_EnemyChase enemy;

    public static GameManager Instance;

    public void SetStartingNode(Parcial_Node node)
    {
        if (_startingNode != null) PaintGameObject(_startingNode.gameObject, Color.white);
        _startingNode = node;
        PaintGameObject(_startingNode.gameObject, Color.green);
    }

    public void SetGoalNode(Parcial_Node node)
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
            enemy.SetPath(pf.AStar(_startingNode, _goalNode));
        }
    }

    public void PaintGameObject(GameObject obj, Color color)
    {
        obj.GetComponent<Renderer>().material.color = color;
    }
}
