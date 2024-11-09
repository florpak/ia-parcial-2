using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parcial_Pathfinding : MonoBehaviour
{
    float HeuristicDistance(Vector3 a, Vector3 b)
    {
        Vector3 distance = b - a;
        return distance.magnitude;
    }

    public List<Parcial_Node> AStar(Parcial_Node start, Parcial_Node goal)
    {
        if (start == null || goal == null) return null;
        Parcial_PriorityQueue frontier = new Parcial_PriorityQueue();
        frontier.Put(start, 0);

        Dictionary<Parcial_Node, Parcial_Node> cameFrom = new Dictionary<Parcial_Node, Parcial_Node>();
        cameFrom.Add(start, null);

        Dictionary<Parcial_Node, float> costSoFar = new Dictionary<Parcial_Node, float>();
        costSoFar.Add(start, 0);

        while (frontier.Count > 0)
        {
            Parcial_Node current = frontier.Get();
            GameManager.Instance.PaintGameObject(current.gameObject, Color.blue);
            if (current == goal)
            {

                Debug.Log("Llegué a la meta");

                List<Parcial_Node> path = new List<Parcial_Node>();

                Parcial_Node nodeToAdd = current;

                while (nodeToAdd != null)
                {
                    path.Add(nodeToAdd);
                    nodeToAdd = cameFrom[nodeToAdd];
                }

                return path;
            }

            foreach (var next in current.GetNeighbors())
            {
                if (next.isBlocked) continue;
                float distance = HeuristicDistance(next.transform.position, goal.transform.position);
                float newCost = costSoFar[current] + next.cost;
                float priority = distance + newCost;

                if (!cameFrom.ContainsKey(next))
                {
                    frontier.Put(next, priority);
                    cameFrom.Add(next, current);
                    costSoFar.Add(next, newCost);
                }
                else
                {
                    if (newCost < costSoFar[next])
                    {
                        frontier.Put(next, priority);
                        cameFrom[next] = current;
                        costSoFar[next] = newCost;
                    }
                }
            }
        }
        return null;
    }
}
