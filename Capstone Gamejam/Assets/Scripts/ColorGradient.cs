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
