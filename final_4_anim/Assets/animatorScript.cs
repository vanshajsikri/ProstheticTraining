using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class animatorScript : MonoBehaviour {

    private Animator anim;
    private TextMeshPro textMeshPro;
    public static int currentState = -1;
    private int tabCount = 0;
	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponent<Animator>();
        textMeshPro = gameObject.GetComponent<TextMeshPro>();
    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKey(KeyCode.Tab))
        {
           
            anim.SetInteger("stateChange", 1);
        }
        //else if (Input.GetKey(KeyCode.RightShift))
        //{
        //    anim.SetInteger("stateChange", 2);
        //}
        else
        {
            anim.SetInteger("stateChange", 0);
        }

        if (currentState == 1)
            textMeshPro.SetText("COCONTRACTION");
        if (currentState == 2)
            textMeshPro.SetText("PINCH");
        if (currentState == 3)
            textMeshPro.SetText("PICK");
        if (currentState == 4)
            textMeshPro.SetText("POINT");
        if (HeldObject.modeFlag == 0)
            textMeshPro.SetText("Please choose the proper mode");

    }
}
