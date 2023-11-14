using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intensemusic : MonoBehaviour
{
    public AudioSource intensemusicSound;
    private bool intensemusicEnabled = false;

    public void EnableIntenseMusic() {
        intensemusicEnabled = true;
    }

    public void DisableIntenseMusic() {
        intensemusicEnabled = false;
    }
    void Update()
    {
        if (intensemusicEnabled)
         {
            intensemusicSound.enabled = true;
         }
         else
         {
            intensemusicSound.enabled = false;
         }
    }
}