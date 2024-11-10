using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Parcial_Node : MonoBehaviour
{
    int _x;
    int _y;
    [SerializeField]List<Parcial_Node> _neighbors;
    public float cost = 1;
    public bool isBlocked = false;
    [SerializeField] TextMeshProUGUI _textCost; 


    public List<Parcial_Node> GetNeighbors()
    {
        return _neighbors;
    }
    public void Initialize(int x, int y, Vector3 pos, Grid grid)
    {
        this._x = x;
        this._y = y;
        transform.position = pos;
        gameObject.name = "Node: " + _x + "," + _y;
        SetCost(1);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        foreach(Parcial_Node node in GetNeighbors())
        {
            Gizmos.DrawLine(transform.position, node.transform.position);
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameManager.Instance.SetStartingNode(this);
        }

        if (Input.GetMouseButtonDown(1))
        {
            GameManager.Instance.SetGoalNode(this);
        }
        if (Input.GetMouseButtonDown(2) || Input.GetKeyDown(KeyCode.F))
        {
            isBlocked = true;

            GameManager.Instance.PaintGameObject(gameObject, isBlocked? Color.grey : Color.white);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            SetCost(cost + 1);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            SetCost(cost - 1);
        }
    }

    public void SetCost(float newCost)
    {
        cost = Mathf.Clamp(newCost,1,99);
        _textCost.text = cost.ToString();
        _textCost.enabled = cost == 1?false : true;
    }
}
