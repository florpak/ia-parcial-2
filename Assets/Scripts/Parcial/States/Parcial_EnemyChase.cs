using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parcial_EnemyChase : State
{
    public float speed;
    List<Parcial_Node> _path;

    public override void OnEnter(Vector3 target)
    {
        _path = GameManager.Instance.pf.AStar(GetNearestNode(), GetNearestNodeToTarget(target));
    }

    public Parcial_Node GetNearestNode()
    {
        return enemy.GetWayPoints()[enemy.GetWayPointNumber()];
    }

    public Parcial_Node GetNearestNodeToTarget(Vector3 target)
    {
        float nearestDistance = Mathf.Infinity;
        Parcial_Node nearestNodeToTarget = null;
        foreach (Parcial_Node node in enemy.GetWayPoints())
        {
            float nodeDistanceToPlayer = Vector3.Distance(node.transform.position, target);
            if (nodeDistanceToPlayer < nearestDistance)
            {
                nearestDistance = nodeDistanceToPlayer;
                nearestNodeToTarget = node;
            }
        }
        return nearestNodeToTarget;
    }

    public override void OnExit()
    {
    }

    public override void OnUpdate()
    {
        if (_path == null || _path.Count == 0) return;
        if (_path != null || _path.Count != 0)
        {
            Vector3 dir = _path[0].transform.position - enemy.transform.position;
            dir.z = 0;
            if (dir.magnitude <= 0.1)
            {
                _path.RemoveAt(0);
            }
            enemy.transform.position += dir.normalized * speed * Time.deltaTime;

        }
    }

    public void SetPath(List<Parcial_Node> path)
    {
        _path = path;
        _path?.Reverse();
    }
}
