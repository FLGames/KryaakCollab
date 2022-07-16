using System.Collections;
using UnityEngine;

public class Porta : MonoBehaviour
{
    [HideInInspector]
    public bool estado = false;
    [SerializeField]
    private bool comecaAberta = false;
    [HideInInspector]
    public bool trancada = true;
    [SerializeField]
    private int ID = 0;
    private Animator anim;

    private AudioSource audioSource;

    [SerializeField]
    private AudioClip[] abrindoClips = null, trancadoClips = null, destrancadoClips = null;

    void Start()
    {
        audioSource = GetComponentInChildren<AudioSource>();
        anim = transform.GetComponentInParent<Animator>();
        estado = comecaAberta;
        if (ID == 0)
            trancada = false;
        if (trancada)
            estado = false;
        anim.SetBool("Aberto", estado);
    }
    public int tentarAbrir(ArrayList minhasChaves)
    {
        if (trancada)
        {
            if (minhasChaves.Contains(ID))
            {
                //Som porta destrancando porta
                trancada = false;
                audioSource.PlayOneShot(destrancadoClips[(int)Random.Range(0, destrancadoClips.Length - 0.01f)]);
                return ID;
            }
            else
            {
                //Som porta trancada
                audioSource.PlayOneShot(trancadoClips[(int)Random.Range(0, trancadoClips.Length - 0.01f)]);
                return 0;
            }
        }
        else
        {
            //Som Porta Abrindo
            estado = !estado;
            anim.SetBool("Aberto", estado);
            audioSource.PlayOneShot(abrindoClips[(int)Random.Range(0, abrindoClips.Length - 0.01f)]);
            return -1;
        }
    }
    public int tentarAbrir()
    {
        if (trancada)
        {
                //Som porta trancada
                audioSource.PlayOneShot(trancadoClips[(int)Random.Range(0, trancadoClips.Length - 0.01f)]);
                return 0;
        }
        else
        {
            //Som Porta Abrindo
            estado = !estado;
            anim.SetBool("Aberto", estado);
            audioSource.PlayOneShot(abrindoClips[(int)Random.Range(0, abrindoClips.Length - 0.01f)]);
            return -1;
        }
    }
}