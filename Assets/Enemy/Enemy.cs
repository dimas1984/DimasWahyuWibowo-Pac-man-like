using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] public List<Transform> Waypoints = new List<Transform>();
    [SerializeField] public float ChaseDistance;
    [SerializeField] public Player Player;
    
    private BaseState _currentstate;
 
    [HideInInspector]
    public PatrolState PatrolState= new PatrolState();
    [HideInInspector]
    public ChaseState ChaseState = new ChaseState();
    [HideInInspector]
    public RetreatState RetreatState = new RetreatState();
    [HideInInspector] 
    public NavMeshAgent navMeshAgent;

    public void SwitchState(BaseState state)
    {
        _currentstate.ExitState(this);
        _currentstate = state;
        _currentstate.EnterState(this);
    }

    private void Awake()
    {
        _currentstate = PatrolState;
        _currentstate.EnterState(this);
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        if(Player  != null)
        {
            Player.OnPowerStart += StartRetreating;
            Player.OnPowerStop += StopRetreating;
        }
    }

    private void Update()
    {
        if (_currentstate != null)
        {
            _currentstate.UpdateState(this);
        }
    }

    private void StartRetreating() 
    {
        SwitchState(RetreatState);
    }


    private void StopRetreating()
    {
        SwitchState(PatrolState);
    }
}