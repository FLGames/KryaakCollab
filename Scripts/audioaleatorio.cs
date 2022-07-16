using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HFPS.Systems;

public class audioaleatorio : MonoBehaviour
{
    [SerializeField] private AudioClip[] audios1, audios2, audios3, audios4, audios5;
    private AudioClip[] audios;
    [SerializeField] private AudioClip vaultTip, calendarTip, scareAudio;
    private AudioSource source;
    [SerializeField] private InteractiveLight switchLight;
    private void Start()
    { 
        source = GetComponent<AudioSource>();
        StartCoroutine("timer");
        StartCoroutine("audioPlayer");
    }

    IEnumerator timer()
    {
        audios = audios1;
        yield return new WaitForSeconds(120);//2min
        audios = audios2;
        yield return new WaitForSeconds(60);//3min
        source.PlayOneShot(vaultTip);
        yield return new WaitForSeconds(60);//4min
        audios = audios3;
        StartCoroutine("lightOff");
        yield return new WaitForSeconds(60);//5min
        source.PlayOneShot(calendarTip);
        yield return new WaitForSeconds(60);//6min
        audios = audios4;
        yield return new WaitForSeconds(120);//8min
        audios = audios5;
        yield return new WaitForSeconds(120);//10min
        source.PlayOneShot(scareAudio);
        StopAllCoroutines();
    }

    IEnumerator audioPlayer()
    {
        yield return new WaitForSeconds(Random.Range(30, 120));
        source.PlayOneShot(audios[Random.Range(0, audios.Length)]);
        StartCoroutine("audioPlayer");
    }

    IEnumerator lightOff()
    {
        yield return new WaitForSeconds(Random.Range(60, 360));
        if(switchLight.isPoweredOn)
            switchLight.UseObject();
        StartCoroutine("lightOff");
    }
}
