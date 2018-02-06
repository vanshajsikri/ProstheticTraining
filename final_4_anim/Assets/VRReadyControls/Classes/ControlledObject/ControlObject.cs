using UnityEngine;
using System.Collections;

/// <summary>
/// This script goes on the objects that you want to interact with "Pass methods to"
/// Extend to add more functionality
/// Please email me at keeling.wesley@gmail.com if you need any further help
/// </summary>
public class ControlObject : MonoBehaviour {

    new Renderer renderer ;
    public void PassColor(float value)
    {
        if (renderer == null)
            renderer = this.gameObject.GetComponent<Renderer>();
        renderer.material.color = new Color(value, value, value);
    }

    public void ToggleObject(float value)
    {
        this.gameObject.SetActive(!this.gameObject.activeSelf);
    }

    new Light light;
    public void ToggleLight(float value)
    {
        if (light == null)
            light = this.gameObject.GetComponent<Light>();
        light.enabled = !light.isActiveAndEnabled;
    }

    public bool myBool = false;
    public void ToggleBool(float value)
    {
        myBool = !myBool;
    }

    TextMesh textMesh;
    public void PassValue(float value)
    {
        if (textMesh == null)
            textMesh = this.gameObject.GetComponent<TextMesh>();
        textMesh.text = value.ToString();
    }

    AudioSource audioSource;
    public void PassVolume(float value)
    {
        if(audioSource == null)
            audioSource = this.gameObject.GetComponent<AudioSource>();
        audioSource.volume = value;
    }

    public void PassScale(float value)
    {
        this.gameObject.transform.localScale = Vector3.one * value;
    }
}
