using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private FiniteStateMachine fsm;
    [SerializeField]
    protected List<GameObject> wayPoints;
    [SerializeField]protected float velocity;


    // Start is called before the first frame update
    void Start()
    {
        fsm = new FiniteStateMachine(this);
        fsm.AddState(EnemyState.Chase, new Parcial_EnemyChase());
        fsm.AddState(EnemyState.Patrol, new EnemyPatrolState());
        fsm.ChangeState(EnemyState.Patrol, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        fsm.Update();
    }

    public List<GameObject> GetWayPoints()
    {
        return this.wayPoints;
    }

    public void Move(Vector3 dir)
    {
        transform.position += dir.normalized * velocity * Time.deltaTime;
    }
}
