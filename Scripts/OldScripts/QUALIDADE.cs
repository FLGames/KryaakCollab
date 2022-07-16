using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QUALIDADE : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("0"))
            QualitySettings.SetQualityLevel(0);
        if (Input.GetKeyDown("1"))
            QualitySettings.SetQualityLevel(1);
        if (Input.GetKeyDown("2"))
            QualitySettings.SetQualityLevel(2);
        if (Input.GetKeyDown("3"))
            QualitySettings.SetQualityLevel(3);
        if (Input.GetKeyDown("4"))
            QualitySettings.SetQualityLevel(4);
        if (Input.GetKeyDown("5"))
            QualitySettings.SetQualityLevel(5);
    }
}
