using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class LightController : MonoBehaviour
{
    private Light[] lights = null;
    [SerializeField]
    private Light[] onLights = null;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<BoxCollider>().isTrigger = true;
        lights = GameObject.FindObjectsOfType<Light>();
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach(Light light in lights)
            light.enabled = false;

        foreach (Light light in onLights)
            light.enabled = true;
    }
}
