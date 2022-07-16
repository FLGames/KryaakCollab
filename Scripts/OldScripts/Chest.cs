using UnityEngine;
using UnityEngine.SceneManagement;

public class Chest : MonoBehaviour
{
    private int toys = 0;
    private int toysTarget = 5;
    private RectTransform canvasToys;
    private Transform chestToysPos;
    private GameplayController gameplayController;

    void Start()
    {
        canvasToys = GameObject.FindGameObjectWithTag("canvasToys").GetComponent<RectTransform>();
        chestToysPos = GameObject.FindGameObjectWithTag("ChestToysPos").transform;
        gameplayController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameplayController>();
    }
    public void theToyIsInTheChest()
    {
        if (gameplayController.startedGame)
        {
            for(int i = 0; i < canvasToys.childCount; i++)
            {
                Transform reference = chestToysPos.GetChild(i);
                ToyCanvasItem toyScript = canvasToys.GetChild(i).GetComponent<ToyCanvasItem>();
                Instantiate(toyScript.toyObject, reference.position, reference.rotation);
                Destroy(reference.gameObject);
                Destroy(canvasToys.GetChild(i).gameObject);
                GameplayController gControllerScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameplayController>();
                gControllerScript.resetTimer();
                toys++;
                if (toys >= toysTarget)
                    SceneManager.LoadScene("FinalScene");
            }
        }
    }
}
