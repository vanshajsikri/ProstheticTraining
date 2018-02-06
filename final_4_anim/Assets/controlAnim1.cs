using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class controlAnim1 : StateMachineBehaviour
{

    private int flag = 0;
    private int flagtabPressed = 0;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animatorScript.currentState = 1;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        //if (anim_playback_count==1)
        //{
        //    animator.StopPlayback();
        //    anim_playback_count = 0;
        //}
        //animator.StartRecording(0);

        if (stateInfo.normalizedTime > 0.0f && flag == 0)
        {
            animator.SetFloat("direction", 0.0f);
            //animator.speed = 0.0f;
        }

        if (Input.GetKey(KeyCode.LeftShift) && flag == 0)
        {
            animator.SetFloat("direction", 0.1f);
            //animator.speed = 0.1f;
        }

        if (Input.GetKey(KeyCode.RightShift) && flag == 0)
        {
            //animator.StopRecording();
            //animator.StartPlayback();
            //animator.playbackTime = animator.recorderStartTime;
            animator.SetFloat("direction", -0.1f);
            //animator.speed = 0.1f;
            
            //    anim_playback_count = 1;
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //animator.SetFloat("direction", 10.0f);
            //animator.speed = 10.0f;
            animator.SetFloat("direction", -0.1f);
            flagtabPressed = 1;
        }

        if (flagtabPressed == 1 && stateInfo.normalizedTime == 0)
        {
            animator.SetInteger("stateChange", 1);
        }


    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
