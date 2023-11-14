using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laugh : MonoBehaviour
{
    public AudioSource laughSound;
    private bool laughEnabled = false;

    public void EnableLaugh() {
        laughEnabled = true;
    }

    public void DisableLaugh() {
        laughEnabled = false;
    }
    void Update()
    {
        if (laughEnabled)
         {
            laughSound.enabled = true;
         }
         else
         {
            laughSound.enabled = false;
         }
    }
}


