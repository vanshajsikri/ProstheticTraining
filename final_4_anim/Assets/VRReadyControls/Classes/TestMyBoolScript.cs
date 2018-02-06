using UnityEngine;
using System.Collections;

public class TestMyBoolScript : MonoBehaviour {
    ControlObject controlObject; 

	// Use this for initialization
	void Start () {
        controlObject = this.gameObject.GetComponent<ControlObject>();
	}
	
	// Update is called once per frame
	void Update () {
        if (controlObject.myBool)
            this.gameObject.GetComponent<Renderer>().material.color = Color.red;
        else
            this.gameObject.GetComponent<Renderer>().material.color = Color.green;
    }
}
