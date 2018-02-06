using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HeldObject : MonoBehaviour
{
    [HideInInspector]
    public Controller parent;
    public static int modeFlag = -1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "VRHand" || other.tag == "VRController")
        {
            if(animatorScript.currentState != 1)
            {
                modeFlag = 0;
            }
            else
            {
                modeFlag = 1;
            }
        }
    }
}