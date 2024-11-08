using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    public List<Node> BFS(Node start, Node goal)
    {

        if (start == null || goal == null) return null;
        Queue<Node> frontier = new Queue<Node>();
        frontier.Enqueue(start);

        Dictionary<Node, Node> cameFrom = new Dictionary<Node, Node>();
        cameFrom.Add(start, null);

        while (frontier.Count > 0)
        {
            Node current = frontier.Dequeue();
            GameManager.Instance.PaintGameObject(current.gameObject, Color.blue);

            if (current == goal)
            {
                Debug.Log("Llegué a la meta");

                List<Node> path = new List<Node>();

                Node nodeToAdd = current;

                while (nodeToAdd != null)
                {
                    GameManager.Instance.PaintGameObject(nodeToAdd.gameObject, Color.yellow);
                    path.Add(nodeToAdd);
                    nodeToAdd = cameFrom[nodeToAdd];
                }
                return path;
            }

            foreach (Node next in current.GetNeighbors())
            {
                if (!cameFrom.ContainsKey(next) && !next.isBlocked)
                {
                    //GameManager.Instance.PaintGameObject(next.gameObject, Color.cyan);
                    frontier.Enqueue(next);
                    cameFrom.Add(next, current);
                }
            }
        }

        Debug.Log("No hay camino posible");
        return null;
    }

    public IEnumerator PaintBFS(Node start, Node goal)
    {
        if (start == null || goal == null) yield return null;
        Queue<Node> frontier = new Queue<Node>();
        frontier.Enqueue(start);

        Dictionary<Node, Node> cameFrom = new Dictionary<Node, Node>();
        cameFrom.Add(start, null);

        while (frontier.Count > 0)
        {
            Node current = frontier.Dequeue();
            GameManager.Instance.PaintGameObject(current.gameObject, Color.blue);
            yield return new WaitForSeconds(0.1f);
            
            if (current == goal)
            {
                Debug.Log("Llegué a la meta");

                List<Node> path = new List<Node>();

                Node nodeToAdd = current;
                
                while(nodeToAdd != null)
                {
                    GameManager.Instance.PaintGameObject(nodeToAdd.gameObject, Color.yellow);
                    yield return new WaitForSeconds(0.1f);
                    path.Add(nodeToAdd);
                    nodeToAdd = cameFrom[nodeToAdd];
                }
               
                break;
            }

            foreach(Node next in current.GetNeighbors())
            {
                if (!cameFrom.ContainsKey(next) && !next.isBlocked)
                {
                    //GameManager.Instance.PaintGameObject(next.gameObject, Color.cyan);
                    frontier.Enqueue(next);
                    cameFrom.Add(next, current);
                }
            }
        }

        Debug.Log("No hay camino posible");
        yield return null;
    }

    public List<Node> Dijkstra(Node start, Node goal)
    {
        if (start == null || goal == null) return null;
        PriorityQueue frontier = new PriorityQueue();
        frontier.Put(start, 0);
        Dictionary<Node, Node> cameFrom = new Dictionary<Node, Node>();
        cameFrom.Add(start, null);

        Dictionary<Node, float> costSoFar = new Dictionary<Node, float>();
        costSoFar.Add(start, 0);

        while (frontier.Count > 0)
        {
            Node current = frontier.Get();
            GameManager.Instance.PaintGameObject(current.gameObject, Color.blue);
            if (current == goal)
            {

                Debug.Log("Llegué a la meta");

                List<Node> path = new List<Node>();

                Node nodeToAdd = current;

                while (nodeToAdd != null)
                {
                    GameManager.Instance.PaintGameObject(nodeToAdd.gameObject, Color.yellow);
                    path.Add(nodeToAdd);
                    nodeToAdd = cameFrom[nodeToAdd];
                }

                return path;
            }

            foreach (var next in current.GetNeighbors())
            {
                float nextCost = costSoFar[current] + next.cost;
                if (!cameFrom.ContainsKey(next) && !next.isBlocked)
                {
                    frontier.Put(next, nextCost);
                    cameFrom.Add(next, current);
                    costSoFar.Add(next, nextCost);

                }
            }
        }
        return null;
    }
    public IEnumerator PaintDijkstra(Node start, Node goal)
    {
        if (start == null || goal == null) yield return null;
        PriorityQueue frontier = new PriorityQueue();
        frontier.Put(start, 0);
        Dictionary<Node, Node> cameFrom = new Dictionary<Node, Node>();
        cameFrom.Add(start, null);

        Dictionary<Node, float> costSoFar = new Dictionary<Node, float>();
        costSoFar.Add(start, 0);

        while (frontier.Count > 0)
        {
            Node current = frontier.Get();
            GameManager.Instance.PaintGameObject(current.gameObject, Color.blue);
            yield return new WaitForSeconds(0.2f);
            if (current == goal)
            {

                Debug.Log("Llegué a la meta");

                List<Node> path = new List<Node>();

                Node nodeToAdd = current;

                while (nodeToAdd != null)
                {
                    GameManager.Instance.PaintGameObject(nodeToAdd.gameObject, Color.yellow);
                    yield return new WaitForSeconds(0.1f);
                    path.Add(nodeToAdd);
                    nodeToAdd = cameFrom[nodeToAdd];
                }

                break;
            }

            foreach (var next in current.GetNeighbors())
            {
                float nextCost = costSoFar[current] + next.cost;
                if (!cameFrom.ContainsKey(next) && !next.isBlocked)
                {
                    frontier.Put(next, nextCost);
                    cameFrom.Add(next, current);
                    costSoFar.Add(next, nextCost);

                }
            }
        }
        yield return null;
    }


    float HeuristicDistance(Vector3 a, Vector3 b)
    {
        Vector3 distance = b - a;
        return distance.magnitude;
    }

    float HeuristicManhattan(Vector3 a, Vector3 b)
    {
        return Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y);
    }


    public IEnumerator PaintGreedyBFS(Node start, Node goal)
    {
        if (start == null || goal == null) yield return null;
        PriorityQueue frontier = new PriorityQueue();
        frontier.Put(start, 0);

        Dictionary<Node, Node> cameFrom = new Dictionary<Node, Node>();
        cameFrom.Add(start, null);

        while (frontier.Count > 0)
        {
            Node current = frontier.Get();
            GameManager.Instance.PaintGameObject(current.gameObject, Color.blue);
            yield return new WaitForSeconds(0.1f);

            if (current == goal)
            {
                Debug.Log("Llegué a la meta");

                List<Node> path = new List<Node>();

                Node nodeToAdd = current;

                while (nodeToAdd != null)
                {
                    GameManager.Instance.PaintGameObject(nodeToAdd.gameObject, Color.yellow);
                    yield return new WaitForSeconds(0.1f);
                    path.Add(nodeToAdd);
                    nodeToAdd = cameFrom[nodeToAdd];
                }

                break;
            }

            foreach (Node next in current.GetNeighbors())
            {
                if (!cameFrom.ContainsKey(next) && !next.isBlocked)
                {
                    float newCost = HeuristicDistance(goal.transform.position, next.transform.position);
                    frontier.Put(next, newCost);
                    cameFrom.Add(next, current);
                }
            }
        }

        Debug.Log("No hay camino posible");
        yield return null;
    }

    public List<Node> GreedyBFS(Node start, Node goal)
    {

        if (start == null || goal == null) return null;
        PriorityQueue frontier = new PriorityQueue();
        frontier.Put(start, 0);

        Dictionary<Node, Node> cameFrom = new Dictionary<Node, Node>();
        cameFrom.Add(start, null);

        while (frontier.Count > 0)
        {
            Node current = frontier.Get();
            GameManager.Instance.PaintGameObject(current.gameObject, Color.blue);

            if (current == goal)
            {
                Debug.Log("Llegué a la meta");

                List<Node> path = new List<Node>();

                Node nodeToAdd = current;

                while (nodeToAdd != null)
                {
                    GameManager.Instance.PaintGameObject(nodeToAdd.gameObject, Color.yellow);
                    path.Add(nodeToAdd);
                    nodeToAdd = cameFrom[nodeToAdd];
                }
                return path;
            }

            foreach (Node next in current.GetNeighbors())
            {
                if (!cameFrom.ContainsKey(next) && !next.isBlocked)
                {
                    float newCost = HeuristicDistance(goal.transform.position, next.transform.position);
                    frontier.Put(next, newCost);
                    cameFrom.Add(next, current);
                }
            }
        }

        Debug.Log("No hay camino posible");
        return null;
    }

    public IEnumerator PaintAStar(Node start, Node goal)
    {
        if (start == null || goal == null) yield return null;
        PriorityQueue frontier = new PriorityQueue();
        frontier.Put(start, 0);

        Dictionary<Node, Node> cameFrom = new Dictionary<Node, Node>();
        cameFrom.Add(start, null);

        Dictionary<Node, float> costSoFar = new Dictionary<Node, float>();
        costSoFar.Add(start, 0);

        while (frontier.Count > 0)
        {
            Node current = frontier.Get();
            GameManager.Instance.PaintGameObject(current.gameObject, Color.blue);
            yield return new WaitForSeconds(0.2f);
            if (current == goal)
            {

                Debug.Log("Llegué a la meta");

                List<Node> path = new List<Node>();

                Node nodeToAdd = current;

                while (nodeToAdd != null)
                {
                    GameManager.Instance.PaintGameObject(nodeToAdd.gameObject, Color.yellow);
                    yield return new WaitForSeconds(0.1f);
                    path.Add(nodeToAdd);
                    nodeToAdd = cameFrom[nodeToAdd];
                }

                break;
            }

            foreach (var next in current.GetNeighbors())
            {
                if (next.isBlocked) continue;
                float distance = HeuristicDistance(next.transform.position, goal.transform.position);
                float newCost = costSoFar[current] + next.cost;
                float priority = distance + newCost;

                if(!cameFrom.ContainsKey(next))
                {
                    frontier.Put(next, priority);
                    cameFrom.Add(next, current);
                    costSoFar.Add(next, newCost);
                }
                else
                {
                    if (newCost < costSoFar[next]) {
                        frontier.Put(next, priority);
                        cameFrom[next] = current;
                        costSoFar[next] = newCost;
                    }
                }
            }
        }
        yield return null;
    }

    public List<Node> AStar(Node start, Node goal)
    {
        if (start == null || goal == null) return null;
        PriorityQueue frontier = new PriorityQueue();
        frontier.Put(start, 0);

        Dictionary<Node, Node> cameFrom = new Dictionary<Node, Node>();
        cameFrom.Add(start, null);

        Dictionary<Node, float> costSoFar = new Dictionary<Node, float>();
        costSoFar.Add(start, 0);

        while (frontier.Count > 0)
        {
            Node current = frontier.Get();
            GameManager.Instance.PaintGameObject(current.gameObject, Color.blue);
            if (current == goal)
            {

                Debug.Log("Llegué a la meta");

                List<Node> path = new List<Node>();

                Node nodeToAdd = current;

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
