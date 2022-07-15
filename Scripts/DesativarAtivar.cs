using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
public class DesativarAtivar : MonoBehaviour
{
    [SerializeField]
    private GameObject[] objParaAtivar, objParaDesativar;

    void Start()
    {
        GetComponent<BoxCollider>().isTrigger = true;
    }

    void OnTriggerEnter()
    {
        foreach (GameObject obj in objParaAtivar)
            obj.gameObject.SetActive(true); 
        foreach (GameObject obj in objParaDesativar)
            obj.gameObject.SetActive(false);
    }
}