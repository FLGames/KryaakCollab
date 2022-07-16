using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    private Camera playerCam = null;
    ArrayList minhasChaves = new ArrayList();
    [SerializeField]
    private Text chavesText = null;

    private GameplayController gController = null;
    private Animator animMira = null;

    private RaycastHit hit;

    void Start()
    {
        animMira = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Animator>();
        gController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameplayController>();
        miraEscura();
        chavesText.text = "x" + minhasChaves.Count;
    }
    void Update()
    {
        Ray ray = playerCam.ScreenPointToRay(new Vector3(Screen.width/2,Screen.height/2));
        if (Physics.Raycast(ray.origin, ray.direction, out hit, 2f))
        {
            Debug.DrawRay(ray.origin, ray.direction * 2f, Color.yellow);
            if (hit.collider.CompareTag("Chave"))
                sawKey();
            else if (hit.collider.CompareTag("Porta"))
                sawDoor();
            else if (hit.collider.CompareTag("Brinquedo"))
                sawToy();
            else if (hit.collider.CompareTag("Chest") && gController.startedGame)
                sawChest();
            else if (hit.collider.CompareTag("Carta"))
                sawCarta();
            else
                miraEscura();
        }
        else miraEscura();
    }
    private void sawCarta()
    {
        miraClara();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            gController.leuCarta();
            Destroy(hit.collider.gameObject);
        }
    }
    private void sawKey()
    {
        miraClara();
        if (Input.GetKeyDown(KeyCode.Mouse0))
            pegarChave(hit.collider.gameObject);
    }
    private void sawDoor()
    {
        miraClara();
        if (Input.GetKeyDown(KeyCode.Mouse0))
            abrirPorta(hit.collider.gameObject);
    }
    private void sawToy()
    {
        miraClara();
        if (Input.GetKeyDown(KeyCode.Mouse0))
            pegarBrinquedo(hit.collider.gameObject);
    }
    private void sawChest()
    {
        miraClara();
        if (Input.GetKeyDown(KeyCode.Mouse0))
            colocarBrinquedo(hit.collider.gameObject);
    }
    private void abrirPorta(GameObject porta)
    {
        Porta scriptPorta = porta.GetComponent<Porta>();
        int abriu = scriptPorta.tentarAbrir(minhasChaves);
        if (abriu > 0)
        {
            //Destranca a porta
            minhasChaves.Remove(abriu);
            chavesText.text = "x" + minhasChaves.Count;
        }
    }
    private void pegarChave(GameObject chave)
    {
        Chave scriptChave = chave.GetComponent<Chave>();
        minhasChaves.Add(scriptChave.ID);
        Destroy(chave);
        chavesText.text = "x" + minhasChaves.Count;
    }
    private void pegarBrinquedo(GameObject brinquedo)
    {
        Brinquedo brinquedoScript = brinquedo.GetComponent<Brinquedo>();
        brinquedoScript.catchToy();
    }
    private void colocarBrinquedo(GameObject chest)
    {
        Chest chestScript = chest.GetComponent<Chest>();
        chestScript.theToyIsInTheChest();
    }
    private void miraClara()
    {
        animMira.Play("miraClara");
    }
    private void miraEscura()
    {
        animMira.Play("miraEscura");
    }
}
