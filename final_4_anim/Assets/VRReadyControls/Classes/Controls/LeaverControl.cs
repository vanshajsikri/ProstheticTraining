using UnityEngine;
using System.Collections;

/// <summary>
/// Place this on any gameobject, suggested on the parent of the object you want to preform logic on. 
/// </summary>
public class LeaverControl : BaseControl
{
    //Set false if you do not wish to run the expensive calculations every frame, add logic like a box collider to toggle the value
    [SerializeField]
    bool calculateClamp = true;

    Vector3 currentPosition;
    float clampedY;
    float clampedX;
    float clampedZ;

    float tempCurrentValue;


    public override void Awake()
    {
        base.Awake();
    }

    public void Start()
    {
        if (gameObjectToCallMethod == null)
            Debug.LogError(string.Format("You have not assigned the gameObject to interact with on {0}, please set it with the gameobject you wish to preform the physics on", this.gameObject.name));
        if(maxPosition == null || minPosition == null)
            Debug.LogError(string.Format("You have not assigned the transform gameObjects to interact with on {0}, please set it with the min and max empty transform to get the clamp values", this.gameObject.name));

        rigidbody.useGravity = false;
        rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    }

    #region Leaver Physics
    void FixedUpdate()
    {
        if(calculateClamp)
        {
            currentPosition = gameObjectToCallMethod.transform.localPosition;
            clampedY = Mathf.Clamp(currentPosition.y, minPosition.transform.localPosition.y, maxPosition.transform.localPosition.y);
            clampedX = Mathf.Clamp(currentPosition.x, minPosition.transform.localPosition.x, maxPosition.transform.localPosition.x);
            clampedZ = Mathf.Clamp(currentPosition.z, minPosition.transform.localPosition.z, maxPosition.transform.localPosition.z);

            value = (Vector3.Distance(currentPosition, minPosition.localPosition) * valueMultiplyer);

            //Logic to only send the value once if it stays the same
            if (value != tempCurrentValue)
            {
                //This calles the Delegate Method
                Activate(value);
                tempCurrentValue = value;
            }

            //Clamps the leaver position
            if (!Mathf.Approximately(clampedY, currentPosition.y))
            {
                currentPosition.y = clampedY;
                gameObjectToCallMethod.transform.localPosition = currentPosition;
            }

            if (!Mathf.Approximately(clampedX, currentPosition.x))
            {
                currentPosition.x = clampedX;
                gameObjectToCallMethod.transform.localPosition = currentPosition;
            }

            if (!Mathf.Approximately(clampedZ, currentPosition.z))
            {
                currentPosition.z = clampedZ;
                gameObjectToCallMethod.transform.localPosition = currentPosition;
            }
        }
    }
    #endregion
}
