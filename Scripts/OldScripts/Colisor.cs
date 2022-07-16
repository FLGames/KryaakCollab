using UnityEngine;

public class Colisor : MonoBehaviour
{
    private GameplayController gController = null;
    [SerializeField]
    private int ID = 0;

    private void Start()
    {
        gController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameplayController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        gController.setSpawnID(ID);
    }
}
