using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;
using UnityEngine.AI;

public class PatroolState : BaseState
{
    [SerializeField] private float distenceTriggerWaypoint=0.25f;
    private int curWP=0;
    private NavMeshAgent navMeshAgent;
    private void Awake()
    {
        
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator,stateInfo,layerIndex);
        navMeshAgent = npc.agent;
        curWP = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        navMeshAgent.SetDestination(npc.wayPoints[curWP].position); 
        //Movement logic
        if (Vector2.Distance((base.npc.transform.position),npc.wayPoints[curWP].position )<distenceTriggerWaypoint)
        {
            curWP++;
            if (curWP>=npc.wayPoints.Length)
            {
                curWP = 0;
            }
            navMeshAgent.SetDestination(npc.wayPoints[curWP].position);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
