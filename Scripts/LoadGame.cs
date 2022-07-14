using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    public float letterPaused = 0.025f;
    public string[] message;
    public Text textComp;
    public GameObject ControllersIMG;
    public bool checkNext = false;
    private int lineaActual = 0;

    [SerializeField]
    private Text m_Text = null;

    private float timePassed;
    private int tempoCarregamento = 5;
    AsyncOperation asyncOperation;
    
    void Start()
    {
        textComp.text = "";
        StartCoroutine(TypeText(lineaActual));
        asyncOperation = SceneManager.LoadSceneAsync("InGame");
        asyncOperation.allowSceneActivation = false;
    }
    void Update()
    {
        //Pular Cutscene
        if (timePassed < tempoCarregamento)
        {
            timePassed += Time.deltaTime;
            m_Text.text = "Carregando: " + (int)(timePassed / tempoCarregamento * 100) + "%";
        }
        if (timePassed > tempoCarregamento)
            timePassed = tempoCarregamento;

        if (timePassed == tempoCarregamento)
        {
            m_Text.text = "Aperte 'E' para pular";

            if (Input.GetKeyDown(KeyCode.E))
                asyncOperation.allowSceneActivation = true;
        }
        //Texto animado
        if (checkNext)
        {
            ControllersIMG.SetActive(true);
        }
        else
        {
            ControllersIMG.SetActive(false);
        }
        if (lineaActual < message.Length - 1 && checkNext && Input.GetKeyDown(KeyCode.Return))
        {
            lineaActual++;
            checkNext = false;
            textComp.text = "";
            StartCoroutine(TypeText(lineaActual));
        }
    }
    IEnumerator TypeText(int line)
    {
        foreach (char letter in message[line].ToCharArray())
        {
            textComp.text += letter;

            yield return 0;
            yield return new WaitForSeconds(letterPaused);
        }
        checkNext = true;
    }
    public int getLineaActual()
    {
        return lineaActual;
    }
    public int getLastLine()
    {
        return message.Length - 1;
    }
    public bool getCheckNext()
    {
        return checkNext;
    }
}
