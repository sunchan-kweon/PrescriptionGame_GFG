using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    //Events that track screen touching start and end 
    public delegate void StartTouchEvent(Vector2 position, float time);
    public event StartTouchEvent OnStartTouch;
    public delegate void EndTouchEvent(Vector2 position, float time);
    public event EndTouchEvent OnEndTouch; 

    //Utilizing touch functions that allow connecting objects while dragging mouse
    private TouchControls touchControls;
    private DragBehavior drag;
    private bool dragStarted;

    private void Awake(){
        touchControls = new TouchControls();
        drag = new DragBehavior();
    }

    private void Update()
    {
        //If dragging with hand enabled, track if mouse detector is colliding with objects and add them to dragged objects
        if (dragStarted)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
            if (hit.collider != null)
            {
                if (drag.isDragging() && hit.collider.gameObject.GetComponent<Berry>().added == false)
                {
                    drag.addDragged(gameObject);
                    hit.collider.gameObject.GetComponent<Berry>().added = true;
                    drag.drawLines();
                }
            }
        }
    }

    //enable touching
    private void OnEnable(){
        touchControls.Enable();
    }

    //disable touching
    private void OnDisable(){
        touchControls.Disable();
    }

    //Calling methods by using Unity Input System
    private void Start(){
        
        touchControls.Touch.TouchPress.started += ctx => StartTouch(ctx);
        touchControls.Touch.TouchPress.canceled += ctx => EndTouch(ctx);
    }

    //Begin dragging when touch started
    private void StartTouch(InputAction.CallbackContext context)
    {
        drag.onDown();
        dragStarted = true;
        Debug.Log("Touch started" + touchControls.Touch.TouchPosition.ReadValue<Vector2>());
        if(OnStartTouch != null) OnStartTouch(touchControls.Touch.TouchPosition.ReadValue<Vector2>(), (float)context.startTime);
    }

    //Stop dragging when touch finished
    private void EndTouch(InputAction.CallbackContext context)
    {
        drag.onUp();
        dragStarted = false;
        Debug.Log("Touch ended" + touchControls.Touch.TouchPosition.ReadValue<Vector2>());
        if(OnEndTouch != null) OnEndTouch(touchControls.Touch.TouchPosition.ReadValue<Vector2>(), (float)context.time);
    }
}