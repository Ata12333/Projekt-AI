using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
  
public class Movement : MonoBehaviour  
{  
    Vector3 velocity;
    
    void Start()  
    {  
          
    }  
  
    void Update()  
    {   
        velocity.x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * 100;  
        velocity.z = Input.GetAxisRaw("Vertical") * Time.deltaTime * 100;  
        Vector3 direction = transform.TransformDirection( velocity ); 
        direction.y = 0;
        direction = direction.normalized * 50 * Time.deltaTime;
        transform.position = transform.position + direction; 
    }  
}  