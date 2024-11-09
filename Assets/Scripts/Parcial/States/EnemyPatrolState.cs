using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolState : State
{
    public override void OnEnter(Vector3 target)
    {
        //throw new System.NotImplementedException();
    }

    public override void OnExit()
    {
        throw new System.NotImplementedException();
    }

    public override void OnUpdate()
    {
        foreach (GameObject waypoint in enemy.GetWayPoints())
        {
            while (Vector3.Distance(enemy.transform.position, waypoint.transform.position) > 0.1f)
            {
                enemy.Move(enemy.transform.position - waypoint.transform.position);
            }
        }
    }

}
