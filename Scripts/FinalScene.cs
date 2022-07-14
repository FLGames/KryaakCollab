using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Data.SqlTypes;

public class FinalScene : MonoBehaviour
{
    public float letterPaused = 0.025f;
    public string[] message;
    public Text textComp;
    public bool checkNext = false;
    private int lineaActual = 0;

    void Start()
    {
        textComp.text = "";
        StartCoroutine(TypeText(lineaActual));
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            Application.Quit();
            //SceneManager.LoadScene("Menu");

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
