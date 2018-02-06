using UnityEngine;
using System.Collections;

/// <summary>
/// This is the parent class of all 3 controls edit this script to add your own methods when interacting with controls
/// Extend the Enum, Switch and add a method that calls a method on 'ControlObjects.cs' inorder to add functions. 
/// </summary>
public class BaseControl : MonoBehaviour {
    protected delegate void Delegate(float value);
    protected Delegate delegateMethod;

    [Header("Set with the gameobject you wish to preform physics on")]
    [SerializeField]
    protected GameObject gameObjectToCallMethod;
    [Space(5)]

    [SerializeField]
    protected Controls methodToCall;
    //Array of ControlObjects you wish to interact with
    [SerializeField]
    protected ControlObject[] gameObjectToInteractWith;

    //Create two empty game objects that act as the clamp transforms for the leaver handle and set them as this max and min
    [SerializeField]
    protected Transform minPosition, maxPosition;

    [SerializeField]
    protected AudioClip audioClip;
    private AudioSource audioSource;

    protected Rigidbody rigidbody; 

    //Change to a custom value if you need to
    protected float value = 0;
    [SerializeField]
    protected float valueMultiplyer = 10;

    public virtual void Awake()
    {
        if(audioClip != null)
        {
            if (audioSource == null)
                audioSource = this.gameObject.AddComponent<AudioSource>();
            else
                audioSource = this.gameObject.GetComponent<AudioSource>();
        }

        SetDelegate(methodToCall);

        if (methodToCall == Controls.NotSet)
            Debug.LogWarning(string.Format("{0} control enum has not been set, please remember to set it's enum to the proper delegate you wish to call", this.gameObject.name));

        if (gameObjectToCallMethod.GetComponent<Rigidbody>() == null)
            rigidbody = gameObjectToCallMethod.AddComponent<Rigidbody>();
        else
            rigidbody = gameObjectToCallMethod.GetComponent<Rigidbody>();

        rigidbody.useGravity = false;
    }

    protected void Activate(float value = 0)
    {
        //This is called from each of the control classes, add anything here you wish to do when a player
        //calls the Delegate
        delegateMethod(value);
        PlayAudio();
    }

    void PlayAudio()
    {
        if (audioClip != null)
            audioSource.PlayOneShot(audioClip);
    }



    //--------------------------------------------------------------------//
    // 3. Add Case in switch statement to set the Delegate
    //--------------------------------------------------------------------//
    #region Delegate
    void SetDelegate(Controls control)
    {
        switch(control)
        {
            case Controls.ToggleBool:
                delegateMethod = ToggleBool;
                break;
            case Controls.ToggleGameObjectState:
                delegateMethod = ToggleGameObjectState;
                break;
            case Controls.ToggleLight:
                delegateMethod = ToggleLight;
                break;
            case Controls.PassColor:
                delegateMethod = PassColor;
                break;
            case Controls.PassVolume:
                delegateMethod = PassVolume;
                break;
            case Controls.PassScale:
                delegateMethod = PassScale;
                break;
            case Controls.PassValue:
                delegateMethod = PassValue;
                break;
            default:
                print("You broke the switch by passing a wrong value");
                break;
        }
    }
    #endregion

//--------------------------------------------------------------------//
// 1. Place all extended methods below to call 'ControlObjects.cs' methods
//--------------------------------------------------------------------//
    #region Functions
    void ToggleGameObjectState(float value = 0)
    {
        foreach (ControlObject controlObject in gameObjectToInteractWith)
            controlObject.ToggleObject(value);
    }

    void ToggleLight(float value = 0)
    {
        foreach (ControlObject controlObject in gameObjectToInteractWith)
            controlObject.ToggleLight(value);
    }

    void ToggleBool(float value = 0)
    {
        foreach (ControlObject controlObject in gameObjectToInteractWith)
            controlObject.ToggleBool(value);
    }

    void PassColor(float value = 0)
    {
        foreach(ControlObject controlObject in gameObjectToInteractWith)
            controlObject.PassColor(value);
    }

    void PassVolume(float value = 0)
    {
        foreach (ControlObject controlObject in gameObjectToInteractWith)
            controlObject.PassVolume(value);
    }

    void PassScale(float value = 0)
    {
        foreach (ControlObject controlObject in gameObjectToInteractWith)
            controlObject.PassScale(value);
    }

    void PassValue(float value = 0)
    {
        foreach (ControlObject controlObject in gameObjectToInteractWith)
            controlObject.PassValue(value);
    }
    #endregion
}

//--------------------------------------------------------------------//
// 2. Add enum to dropdown to select in inspector
//--------------------------------------------------------------------//
#region Enum 
public enum Controls
{
    NotSet,
    ToggleGameObjectState,
    ToggleLight,
    ToggleBool,
    PassColor,
    PassVolume,
    PassScale,
    PassValue,
}
#endregion