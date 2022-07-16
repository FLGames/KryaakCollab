using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    [SerializeField]
    private Transform[] spawns = null;
    [SerializeField]
    private GameObject[] toys = null;
    private int meuRnd = 0;
    
    public float remainingTime = 300;
    [SerializeField]
    private Text textTime = null;

    [SerializeField]
    private GameObject canvasCarta = null;

    private Animator anim;
    public bool startedGame = false;

    private float spawnTime = 1;
    private float timePassed;
    private bool spawned = true;

    private int spawnID;
    private GameObject spawnsMonstro = null;
    [SerializeField]
    private GameObject prefabMonstro = null;
    private GameObject monstroInstance = null;
    private Monstro monstroScript = null;
    [SerializeField]
    private AudioClip sonsFundo = null;
    [SerializeField]
    private AudioClip[]sonsAleatorios = null;
    private AudioSource ObjectAudioSource;

    void Start()
    {
        spawnsMonstro = GameObject.FindGameObjectWithTag("SpawnsMonstro");
        textTime.enabled = false;
        anim = GetComponent<Animator>();
        ObjectAudioSource = GameObject.FindGameObjectWithTag("SomFundo01").GetComponent<AudioSource>();
    }
    public void StartGame()
    {        
        startedGame = true;
        meuRnd = (int)(1f / Time.deltaTime);
        meuRnd += Random.Range(0, spawns.Length);
        meuRnd %= spawns.Length;
        spawnToys();
        textTime.enabled = true;
        newSpawnMonster();
        anim.Play("ResetTime");
        GetComponent<TempLightController>().setLight(0.7f);
        GameObject.FindGameObjectWithTag("SomFundo01").GetComponent<AudioSource>().Play();        
    }
    void Update()
    {
        timePassed += Time.deltaTime;

        if(timePassed > spawnTime && !spawned)
        {
            spawned = true;
            spawnMonster();
        }
        textTime.text = ((int)remainingTime / 60).ToString() + ":" + ((int)remainingTime % 60).ToString("00");
    }
    private void spawnMonster()
    {
        Transform temp = spawnsMonstro.transform.GetChild(spawnID);
        monstroInstance = Instantiate(prefabMonstro, temp.position, temp.rotation);
        monstroScript = monstroInstance.GetComponent<Monstro>();
    }
    public void setSpawnID(int sID)
    {
        spawnID = sID;
    }
    public void newSpawnMonster()
    {
        timePassed = 0;
        spawnTime = Random.Range(10, 30);
        spawned = false;
    }
    private void spawnToys()
    {
        for(int i = 0; i < toys.Length; i++)
        {
            int tempRnd = (meuRnd + i) % spawns.Length;
            Instantiate(toys[i], spawns[tempRnd].position, spawns[tempRnd].rotation);
        }
    }
    public void resetTimer()
    {
        anim.Play("ResetTime");
    }
    public void comportamento1()
    {
        if (monstroScript)
            monstroScript.comportamento1();
    }
    public void comportamento2()
    {
        if (monstroScript)
            monstroScript.comportamento2();
    }
    public void comportamento3()
    {
        if (monstroScript)
            monstroScript.comportamento3();
    }
    public void comportamentoFinal()
    {
        if (monstroScript)
        {
            monstroScript.comportamentoFinal();
            tocaAudioFinal();
        }
    }
    public void tocaAudioSinistro()
    {
        if(startedGame)
        {
            int temp = (int)Random.Range(0, sonsAleatorios.Length - 0.01f);
            ObjectAudioSource.PlayOneShot(sonsAleatorios[temp]);
            Debug.Log("Toca audio");
        }
    }
    public void tocaAudioFinal()
    {
        ObjectAudioSource.clip = sonsFundo;
        ObjectAudioSource.Play();
    }
    public void comecaPiscar()
    {
        GetComponent<TempLightController>().alternateLight(0.1f, 0.5f);
    }
    public void paraPiscar()
    {
        GetComponent<TempLightController>().cancelAlternateLight();
    }
    public void timeAnim()
    {
        anim.Play("TimeAnim");
    }
    public void leuCarta()
    {
        Instantiate(canvasCarta);
        
    }
}
