using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Monstro : MonoBehaviour
{
    private Transform TargetOne;

    // Navmesh
    private NavMeshAgent Point;
    private Animator anim;

    private int comportamento;
    private float speedFocus;
    private float runSpeedFocus;
    private float speed;

    private GameObject Targets;
    private int targetID = 0;

    private float raioVisao = 5f;
    private float framesVis = 11f;
    private float distVis = 10f;

    private bool sawPlayer = false;

    private RaycastHit hit;
    private GameObject player;
    private GameplayController gController;

    private float lifeTime;
    private float timePassed;

    [SerializeField]
    private AudioClip[] audioC1 = null, audioC2 = null, audioC3 = null, audioSP = null;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        lifeTime = Random.Range(20, 30);
        gController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameplayController>();
        if (gController.remainingTime > 180)
            comportamento1();
        else if (gController.remainingTime > 80)
            comportamento2();
        else
            comportamento3();

        anim = GetComponentInChildren<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        Point = GetComponent<NavMeshAgent>();
        Targets = GameObject.FindGameObjectWithTag("Targets");
        TargetOne = Targets.transform.GetChild(targetID);
        Point.SetDestination(TargetOne.position);
        InvokeRepeating("randomDistance", 0, 0.5f);
    }
    void Update()
    {
        attSpeed();
        animate();
        if (sawPlayer)
            Point.SetDestination(player.transform.position);
        else
            procuraPlayer();

        timePassed += Time.deltaTime;
        if (timePassed > lifeTime && comportamento < 3)
        {
            gController.newSpawnMonster();
            Destroy(gameObject);
        }
    }
    private void procuraPlayer()
    {
        for (float i = -raioVisao; i < raioVisao; i += raioVisao / framesVis)
        {
            Debug.DrawRay(transform.position, (transform.forward * distVis) + (transform.right * i), Color.red);
            if (Physics.Raycast(transform.position, (transform.forward * distVis) + (transform.right * i), out hit, distVis))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    if (!sawPlayer)
                    {
                        sawPlayer = true;
                        int temp = (int)Random.Range(0, audioSP.Length - 0.01f);
                        audioSource.PlayOneShot(audioSP[temp]);
                        //gController.tocaAudioSinistro();
                        timePassed = 0;
                        lifeTime = 10;
                    }
                }
                if (hit.collider.CompareTag("Porta"))
                {
                    Debug.LogWarning("Vii PORTA!");
                    Porta porta = hit.collider.gameObject.GetComponent<Porta>();
                    if (!porta.trancada && !porta.estado)
                        porta.tentarAbrir();
                }
            }
        }
    }
    public void changeTarget()
    {
        int newID = (int)Random.Range(0, Targets.transform.childCount - 0.01f);

        while (targetID == newID)
            newID = (int)Random.Range(0, Targets.transform.childCount - 0.01f);

        targetID = newID;
        TargetOne = Targets.transform.GetChild(newID);
        Point.SetDestination(TargetOne.position);
    }
    private void randomDistance()
    {
        if (Point.velocity.magnitude < 0.4f)
        {
            changeTarget();
        }
    }
    private void attSpeed()
    {
        if(sawPlayer)
        {
            if (runSpeedFocus > speed)
                speed += Time.deltaTime * 2;
            if (runSpeedFocus < speed)
                speed -= Time.deltaTime * 2;
        }
        else
        {
            if (speedFocus > speed)
            speed += Time.deltaTime * 2;
            if (speedFocus < speed)
            speed -= Time.deltaTime * 2;
        }
        Point.speed = speed;
    }
    private void animate()
    {
        anim.SetFloat("Speed", speed);
        anim.SetInteger("Comportamento", comportamento);
    }
    public void comportamento1()
    {
        int temp = (int)Random.Range(0, audioC1.Length - 0.01f);
        audioSource.PlayOneShot(audioC1[temp]);
        comportamento = 1;
        speedFocus = 1f;
        runSpeedFocus = 4;
    }
    public void comportamento2()
    {
        int temp = (int)Random.Range(0, audioC2.Length - 0.01f);
        audioSource.PlayOneShot(audioC2[temp]);
        comportamento = 2;
        speedFocus = 2;
        runSpeedFocus = 5;
    }
    public void comportamento3()
    {
        int temp = (int)Random.Range(0, audioC3.Length - 0.01f);
        audioSource.PlayOneShot(audioC3[temp]);
        comportamento = 3;
        speedFocus = 2;
        runSpeedFocus = 6;
    }
    public void comportamentoFinal()
    {
        int temp = (int)Random.Range(0, audioC3.Length - 0.01f);
        audioSource.PlayOneShot(audioC3[temp]);
        NavMeshObstacle[] nmObs = FindObjectsOfType<NavMeshObstacle>();
        foreach (NavMeshObstacle n in nmObs)
            Destroy(n);
        comportamento = 4;
        runSpeedFocus = 8;
        sawPlayer = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if (comportamento < 4)
            {
                gController.newSpawnMonster();
                Destroy(gameObject);
            }
            else
                matouPlayer();
        }
    }

    private void matouPlayer()
    {
        Application.Quit();
        //SceneManager.LoadScene("GameOverS");
    }
}
