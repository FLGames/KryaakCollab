using UnityEngine;

public class Brinquedo : MonoBehaviour
{
    [SerializeField]
    private Sprite toySprite = null;
    [SerializeField]
    private GameObject prefabToy = null;
    [SerializeField]
    private GameObject toyCanvasItem = null;

    public void catchToy()
    {
        ToyCanvasItem toyScript = Instantiate(toyCanvasItem).GetComponent<ToyCanvasItem>();
        toyScript.toyObject = prefabToy;
        toyScript.toyImage = toySprite;
        Destroy(gameObject);
    }
}
