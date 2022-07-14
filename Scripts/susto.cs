using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class susto : MonoBehaviour
{

    public AudioSource audioSource;

    void OnTriggerEnter(Collider other)
    {
      
        audioSource.Play();
        Destroy(gameObject, 14);
    }
}

