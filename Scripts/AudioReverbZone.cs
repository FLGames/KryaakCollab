
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
public class AudioReverbZone : MonoBehaviour
{
    [SerializeField]
    private GameObject[] reverb;
    void Start()
    {
        GetComponent<BoxCollider>().isTrigger = true;

    }


    void OnTriggerExit()
    {
        
        foreach (GameObject obj in reverb)
        obj.gameObject.SetActive(false);
        
    }
    void OnTriggerEnter()
    {
        foreach (GameObject obj in reverb)
            obj.gameObject.SetActive(true);
    }
}