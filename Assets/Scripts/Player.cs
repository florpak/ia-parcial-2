using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    List<Node> _path;

    public void SetPath(List<Node> path)
    {
        _path = path;
        _path?.Reverse();
    }

    public void SetPos(Vector3 pos)
    {
        pos.z = -1;
        transform.position = pos;
    }

    private void Update()
    {
        if (_path == null || _path.Count == 0) return;
        if(_path != null || _path.Count != 0)
        {
            Vector3 dir = _path[0].transform.position - transform.position;
            dir.z = 0;
            if(dir.magnitude<= 0.1)
            {
                _path.RemoveAt(0);
            }
            transform.position += dir.normalized * speed * Time.deltaTime;

        }
    }
}
