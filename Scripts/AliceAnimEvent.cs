using UnityEngine;

public class AliceAnimEvent : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip[] aPasso = null, aCorrida = null;
    
    void Start()
    {
        audioSource = GetComponentInParent<AudioSource>();        
    }

    public void tocaPasso()
    {
        int temp = (int)Random.Range(0, aPasso.Length - 0.01f);
        audioSource.PlayOneShot(aPasso[temp]);
    }
    public void tocaCorrida()
    {
        int temp = (int)Random.Range(0, aCorrida.Length - 0.01f);
        audioSource.PlayOneShot(aCorrida[temp]);
    }
}
