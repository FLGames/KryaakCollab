using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public string Loading;
    public GameObject creditsPanel;
    public void StartGame()
    {   
        StartCoroutine(Open());
    }
    private IEnumerator Open()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(Loading);
    }
    public void QuitGame()
    {
        StartCoroutine(Close());

    }
    private IEnumerator Close()
    {
        yield return new WaitForSeconds(0.5f);
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
    public void ShowCredits()
    {
        creditsPanel.SetActive(true);
    }
    public void BackToMenu()
    {
        creditsPanel.SetActive(false);
    }
}

