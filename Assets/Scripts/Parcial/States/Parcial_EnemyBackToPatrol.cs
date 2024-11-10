using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Parcial_EnemyBackToPatrol : State
{
    public float speed;
    List<Parcial_Node> _path;

    public override void OnEnter(Vector3 target)
    {
        _path = GameManager.Instance.pf.AStar(GetNearestNode(), GetNearestNodeToTarget(target));
    }

    public Parcial_Node GetNearestNode()
    {
        float nearestDistance = Mathf.Infinity;
        Parcial_Node nearestNodeToTarget = null;
        foreach (Parcial_Node node in GameManager.Instance.GetNodes())
        {
            float nodeDistanceToNode = Vector3.Distance(node.transform.position, enemy.transform.position);
            if (nodeDistanceToNode < nearestDistance)
            {
                nearestDistance = nodeDistanceToNode;
                nearestNodeToTarget = node;
            }
        }
        return nearestNodeToTarget;
    }

    public Parcial_Node GetNearestNodeToTarget(Vector3 target)
    {
        float nearestDistance = Mathf.Infinity;
        Parcial_Node nearestNodeToTarget = null;
        foreach (Parcial_Node node in GameManager.Instance.GetNodes())
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
        if (enemy.GetTargetPlayer() != null)
        {
            fsm.ChangeState(EnemyState.Follow, enemy.GetTargetPlayer().transform.position);
        }
        if (_path == null || _path.Count <= 0) fsm.ChangeState(EnemyState.Patrol, new Vector3(0, 0, 0));
        if (_path != null && _path.Count != 0)
        {
            Vector3 dir = _path[0].transform.position - enemy.transform.position;
            dir.y = 0;
            if (enemy.GetWayPoints().Contains(_path[0]) && dir.magnitude <= 0.01)
            {
                
                enemy.SetWayPointNumber(enemy.GetWayPoints().IndexOf(_path[0]));
                fsm.ChangeState(EnemyState.Patrol, new Vector3(0, 0, 0));
            } 
            if (dir.magnitude <= 0.01)
            {
                _path.RemoveAt(0);

            }
            else
            {
                enemy.Move(_path[0].transform.position - enemy.transform.position);
            }

        }
    }

    public void SetPath(List<Parcial_Node> path)
    {
        _path = path;
        _path?.Reverse();
    }
}
