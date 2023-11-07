using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
  
    [RequireComponent(typeof(CharacterController))]

public class Movement : MonoBehaviour  
{  
    [SerializeField]
    Vector3 velocity;
    CharacterController controller;
    
    private float speed = 1f;
    
    void Start()  
    {  
          controller = GetComponent<CharacterController>();
    }  
  
    void Update()  
    {   
        velocity.x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * 100;  
        velocity.z = Input.GetAxisRaw("Vertical") * Time.deltaTime * 100;  
        Vector3 direction = transform.TransformDirection( velocity ); 
        direction.y = 0;
        direction = direction.normalized * 50 * Time.deltaTime;
        //transform.position = transform.position + direction;
        controller.Move(
            direction);

    }  
}  