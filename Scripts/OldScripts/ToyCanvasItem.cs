using UnityEngine;
using UnityEngine.UI;

public class ToyCanvasItem : MonoBehaviour
{
    public Sprite toyImage;
    public GameObject toyObject;
    private RectTransform canvasToys;

    void Start()
    {
        canvasToys = GameObject.FindGameObjectWithTag("canvasToys").GetComponent<RectTransform>();
        GetComponent<Image>().sprite = toyImage;
        gameObject.transform.SetParent(canvasToys);
    }
}
