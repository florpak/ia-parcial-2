using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public abstract void OnEnter(Vector3 target);
    public abstract void OnUpdate();
    public abstract void OnExit();
    public FiniteStateMachine fsm;
    public Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
