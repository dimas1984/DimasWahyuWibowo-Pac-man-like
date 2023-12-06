using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState :  BaseState
{
    private bool _isMoving;
    private Vector3 _destination;
    public void EnterState(Enemy enemy)
    {
        //Debug.Log("start patrol");
        _isMoving = false;
    }
    public void UpdateState(Enemy enemy)
    {
     if (Vector3.Distance(enemy.transform.position, enemy.Player.transform.position) < enemy.ChaseDistance)
        {
            enemy.SwitchState(enemy.ChaseState);
        }
      

        //Debug.Log("patroling");
        if (!_isMoving)
        {
            _isMoving = true;
            int index = UnityEngine.Random.Range(0, enemy.Waypoints.Count);
            _destination = enemy.Waypoints[index].position;
            enemy.navMeshAgent.destination = _destination;
            //Debug.Log("patroling");

        }
        else
        {
            if (Vector3.Distance(_destination, enemy.transform.position) <= 1) 
            { 
                _isMoving=false;
                //Debug.Log("patrolingku");

            }
        }
        
    }
    public void ExitState(Enemy enemy)
    {
        Debug.Log("stop patrol");
    }
}
