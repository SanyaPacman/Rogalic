using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState : StateMachineBehaviour
{
    protected AI npc;
    //protected GameObject opponent;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        npc = animator.gameObject.GetComponent<AI>();
        //opponent = npc.GetComponent<TamkAI>().GetPlayer();
    }
}
