using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parcial_PriorityQueue
{
    Dictionary<Parcial_Node, float> _allNodes = new Dictionary<Parcial_Node, float>();

    public int Count
    { 
        get { return _allNodes.Count; }
    }

    public void Put(Parcial_Node node, float cost)
    {
        if (_allNodes.ContainsKey(node)) _allNodes[node] = cost;
        else _allNodes.Add(node, cost);
    }
    public Parcial_Node Get()
    {
        Parcial_Node node = null;
        float lowestCost = Mathf.Infinity;
        foreach (var item in _allNodes)
        {
            if(item.Value< lowestCost)
            {
                lowestCost = item.Value;
                node = item.Key;
            }
        }
        _allNodes.Remove(node);
        return node;
    }
}
