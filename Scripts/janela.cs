using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class janela : MonoBehaviour{

    public Texture[] Texturasj;
    private int Indice = 1;

    void Update()
    {
        if (Indice < Texturasj.Length)
        {
            GetComponent<MeshRenderer>().material.mainTexture = Texturasj[Indice];
            Indice++;
        }
        else
        {
            GetComponent<MeshRenderer>().material.mainTexture = Texturasj[0];
            Indice = 1;
        }
    }
}
