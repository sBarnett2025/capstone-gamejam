using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelReference : MonoBehaviour
{
    [SerializeField] string levelIGoTo;
    public void goToLevel()
    {
        SceneManager.LoadScene(levelIGoTo);
    }
}