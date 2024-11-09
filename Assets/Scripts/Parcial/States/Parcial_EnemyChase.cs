using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parcial_EnemyChase : State
{
    public float speed;
    List<Parcial_Node> _path;

    public override void OnEnter(Vector3 target)
    {
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
