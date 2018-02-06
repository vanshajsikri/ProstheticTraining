using UnityEngine;
using System.Collections;

public class KnobControl : BaseControl {

    float tempRotation;
    float clampedRot;

    Quaternion currentRotation;

    public override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        rigidbody.useGravity = false;
        rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePosition;
        rigidbody.drag = 10;
        rigidbody.angularDrag= 10;
    }

    void Update()
    {
        value = gameObjectToCallMethod.transform.localEulerAngles.y * valueMultiplyer;
        if (value != tempRotation)
        {
            //This calles the Delegate Method
            Activate(value);
            tempRotation = value;
        }
    }

    #region Knob Physics
    void FixedUpdate()
    {
        currentRotation = transform.rotation;
        clampedRot = Mathf.Clamp(currentRotation.y, 0, 360);

        if (!Mathf.Approximately(clampedRot, currentRotation.y))
        {
            currentRotation.y = clampedRot;
            transform.localRotation = currentRotation;
        }
    }
    #endregion
}

