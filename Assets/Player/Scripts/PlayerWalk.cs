using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
  
public class Movement : MonoBehaviour  
{  
    Vector3 velocity;
    // Start is called before the first frame update  
    void Start()  
    {  
          
    }  
  
    // Update is called once per frame  
    void Update()  
    {  
        //velocity.y = Input.GetAxis("Jump") * Time.deltaTime * 20;  
        velocity.x = Input.GetAxis("Horizontal") * Time.deltaTime * 100;  
        velocity.z = Input.GetAxis("Vertical") * Time.deltaTime * 100;  
        //transform.position = transform.position + velocity;
        Vector3 direction = transform.TransformDirection( velocity ); 
        direction.y = 0;
        direction = direction.normalized * 100 * Time.deltaTime;
        transform.position = transform.position + direction; 
        Debug.Log(direction);
    }  
}  