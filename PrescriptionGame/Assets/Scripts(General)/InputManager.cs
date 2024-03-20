using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private TouchControls touchControls;

    private void Awake()
    {
        touchControls = new TouchControls();
    }
    
    private void OnEnable(){

        touchControls.Enable();
    }

    private void OnDisable(){
        touchControls.Disable();
    }

    private void Start(){
        
    }
}
