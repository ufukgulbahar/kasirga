using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindNewTargetState : StateMachineBehaviour
{

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player player = animator.gameObject.GetComponent<player>();
        player.SetNextWayPoint();
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
