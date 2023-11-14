using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// Search for GameObjects with a tag that is not used

public class Example : MonoBehaviour
{
    void Update()
    {
        GameObject[] gameObjects;
        gameObjects = GameObject.FindGameObjectsWithTag("Stearinlys");
        if (gameObjects.Length == 0)
        {
           SceneManager.LoadScene("WinScreen");
        }
    }
}