using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetreatState : BaseState
{
    public void EnterState(Enemy enemy)
    {
        Debug.Log("start patrol");
        enemy.Animator.SetTrigger("RetreatState");
    }
    public void UpdateState(Enemy enemy)
    {
        //Debug.Log("patroling");
        if(enemy.Player != null)
        {
            enemy.navMeshAgent.destination = enemy.transform.position - enemy.Player.transform.position;
        }
    }
    public void ExitState(Enemy enemy)
    {
        Debug.Log("stop patrol");
    }
}
