using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : BaseState
{
    public void EnterState(Enemy enemy)
    {
        Debug.Log("start patrol");
        enemy.Animator.SetTrigger("ChaseState");
    }
    public void UpdateState(Enemy enemy)
    {
        //Debug.Log("patroling");
        if (enemy.Player != null) 
        {
            enemy.navMeshAgent.destination = enemy.Player.transform.position;

            if (Vector3.Distance(enemy.transform.position, enemy.Player.transform.position) > enemy.ChaseDistance)
            {
                enemy.SwitchState(enemy.PatrolState);
            }
        }
    }
    public void ExitState(Enemy enemy)
    {
        Debug.Log("stop patrol");
    }
}
