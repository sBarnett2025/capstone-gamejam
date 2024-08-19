using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class ColorGradient : MonoBehaviour
{
    [SerializeField] PostProcessVolume cameraColorVolume;
    [SerializeField] ColorGrading cameraColorGrading;
    public float progressLevel = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("ColorController") != null)
        {
            for (int i = 0; i < GameObject.Find("ColorController").GetComponent<ColorControl>().completedBuildings.Count; i++)
            {
                if (GameObject.Find("ColorController").GetComponent<ColorControl>().completedBuildings[i])
                {
                    progressLevel += 2;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        cameraColorVolume.profile.TryGetSettings<ColorGrading>(out ColorGrading cameraColorGrading);
        {
            cameraColorGrading.saturation.value = (progressLevel * 10) - 100;
        }
    }
}
