using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelReference : MonoBehaviour
{
    [SerializeField] string levelIGoTo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goToLevel()
    {
        SceneManager.LoadScene(levelIGoTo);
    }
}