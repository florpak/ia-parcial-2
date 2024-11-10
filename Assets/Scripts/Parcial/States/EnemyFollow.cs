using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : State
{
    public override void OnEnter(Vector3 target)
    {
        //throw new System.NotImplementedException();
    }

    public override void OnExit()
    {
        //throw new System.NotImplementedException();
    }

    public override void OnUpdate()
    {
        if (enemy.GetTargetPlayer() != null)
        {
            if(Vector3.Distance(enemy.GetTargetPlayer().transform.position, enemy.transform.position) > 0.1)
            {
                enemy.Move(enemy.GetTargetPlayer().transform.position - enemy.transform.position);
            }
            
        }
        else
        {
            fsm.ChangeState(EnemyState.Chase, enemy.GetWayPoints()[enemy.GetWayPointNumber()].transform.position);
        }
    }
}