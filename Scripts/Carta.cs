using UnityEngine;

public class Carta : MonoBehaviour
{
    private GameplayController gController;

    // Update is called once per frame
    private void Start()
    {
        gController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameplayController>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {   
            gController.StartGame();
            Destroy(gameObject);
        }
    }
}
