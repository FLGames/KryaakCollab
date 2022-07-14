using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
public class DesativarAtivar : MonoBehaviour
{

    public GameObject[] objParaAtivar;
    public GameObject[] objParaDesativar;

    void Start()
    {
        GetComponent<BoxCollider>().isTrigger = true;
    }

    void OnTriggerEnter()
    {
        for (int x = 0; x < objParaAtivar.Length; x++)
        {
            objParaAtivar[x].gameObject.SetActive(true);
        }
        for (int x = 0; x < objParaDesativar.Length; x++)
        {
            objParaDesativar[x].gameObject.SetActive(false);
        }
    }

}
