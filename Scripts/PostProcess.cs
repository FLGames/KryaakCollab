using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcess : MonoBehaviour
{
    private PostProcessVolume volume;
    private GameplayController gameplayController;

    void Start()
    {
        gameplayController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameplayController>();
        volume = GetComponent<PostProcessVolume>();
    }
    void Update()
    {
        if(gameplayController.startedGame)
        {
            volume.enabled = true;
        }
    }
}
