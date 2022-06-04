using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOIDController : MonoBehaviour
{ 
    
    [SerializeField] private BOIDMovement movement;
    void Start()
    {
        movement.Init();
    }

    // Update is called once per frame
    void Update()
    {
        movement.Move();   
    }
}
