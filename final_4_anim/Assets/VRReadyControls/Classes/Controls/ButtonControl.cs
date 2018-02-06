using UnityEngine;
using System.Collections;

public class ButtonControl : BaseControl {

    [SerializeField]
    float distanceToActivate = 0.005f;
    bool isButtonDown = false, isButtonUp = false, wasButtonPushed = false, buttonPushed = false;
    Transform buttonStartingPosition;
    Vector3 buttonPositionDelta;
    Vector3 buttonCurrentPosition;

    Vector3 currentPosition;
    float minDistance = 0.001f;
    float currentDistance = -1;
    float clampedY;
    float clampedX;
    float clampedZ;

    void Start()
    {
        buttonCurrentPosition = gameObjectToCallMethod.transform.position;
        rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        rigidbody.useGravity = false;
    }

    void Update()
    {
        wasButtonPushed = buttonPushed;
        buttonPushed = currentDistance > distanceToActivate;
        if (wasButtonPushed == false && buttonPushed == true)
        {
            //This calles the Delegate method
            Activate(value);
        }
        else
            isButtonDown = false;
        if (wasButtonPushed == true && buttonPushed == false)
            isButtonUp = true;
        else
            isButtonUp = false; 
    }

    #region Button Physics
    void FixedUpdate()
    {
        currentDistance = Vector3.Distance(gameObjectToCallMethod.transform.position, buttonCurrentPosition);
        if (currentDistance > minDistance)
        {
            buttonPositionDelta = buttonCurrentPosition - gameObjectToCallMethod.transform.position;
            gameObjectToCallMethod.GetComponent<Rigidbody>().velocity = buttonPositionDelta * 200 * Time.fixedDeltaTime;
        }

        if (minPosition != null || maxPosition != null)
        {
            currentPosition = gameObjectToCallMethod.transform.localPosition;

            clampedY = Mathf.Clamp(currentPosition.y, minPosition.transform.localPosition.y, maxPosition.transform.localPosition.y);
            clampedX = Mathf.Clamp(currentPosition.x, minPosition.transform.localPosition.x, maxPosition.transform.localPosition.x);
            clampedZ = Mathf.Clamp(currentPosition.z, minPosition.transform.localPosition.z, maxPosition.transform.localPosition.z);

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


