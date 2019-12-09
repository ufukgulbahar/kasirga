using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindNewTargetState3 : StateMachineBehaviour
{

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player_scn3 player = animator.gameObject.GetComponent<player_scn3>();
        player.SetNextWayPoint();
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
