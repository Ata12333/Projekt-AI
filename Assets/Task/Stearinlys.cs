using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOther : MonoBehaviour
{
    public GameObject other;
    public GameObject player;
   
    float GetDistanceToPlayer()
    {
        return
            (player.transform.position - transform.position)
            .magnitude;
    }

    bool InRange()
    {
        if (GetDistanceToPlayer() < 30)
        {
            return true;
        }
        return false;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            if (InRange())
            {
                Destroy (other);
            }
        }
        
    }
}
