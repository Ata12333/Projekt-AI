using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartbeat : MonoBehaviour
{
    public AudioSource heartbeatSound;
    private bool heartbeatEnabled = false;

    public void EnableHeartbeat() {
        heartbeatEnabled = true;
    }

    public void DisableHeartbeat() {
        heartbeatEnabled = false;
    }
    void Update()
    {
        if (heartbeatEnabled)
         {
            heartbeatSound.enabled = true;
         }
         else
         {
            heartbeatSound.enabled = false;
         }
    }
}

