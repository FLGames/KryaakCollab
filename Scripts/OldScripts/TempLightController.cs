using UnityEngine;

public class TempLightController : MonoBehaviour
{
    private GameObject[] lights;
    
    private float intensity = 1;

    void Start()
    {
        lights = GameObject.FindGameObjectsWithTag("Luz");
        foreach (GameObject light in lights)
        {
            light.GetComponentInChildren<Light>().shadowStrength = 0.9f;
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
            alternateLight(0.1f, 0.5f);

        if (Input.GetKeyDown(KeyCode.M))
            cancelAlternateLight();

        if (Input.GetKeyDown(KeyCode.B))
            setLight(intensity);
    }
    public void setLight(float intensityLight)
    {
        intensity = intensityLight;
        foreach(GameObject light in lights)
        {
            light.GetComponentInChildren<Light>().intensity = intensityLight;
        }
    }
    public void alternateLight(float time, float intensityLight)
    {
        foreach (GameObject light in lights)
        {
            light.GetComponentInChildren<Light>().intensity = intensityLight;
        }
        InvokeRepeating("invertLight", 0, time);
    }
    public void cancelAlternateLight()
    {
        CancelInvoke("invertLight");
        setLight(intensity);
        foreach (GameObject light in lights)
        {
            light.GetComponentInChildren<Light>().enabled = true;
        }
    }
    private void invertLight()
    {
        foreach (GameObject light in lights)
        {
            light.GetComponentInChildren<Light>().enabled = !light.GetComponentInChildren<Light>().enabled;
        }
    }
}
