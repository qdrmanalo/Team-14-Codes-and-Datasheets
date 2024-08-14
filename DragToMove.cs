using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragToMove : MonoBehaviour
{
    [SerializeField]
    private float speedModifier = 0.002f;
    private Touch touch;

    void Update()
    {
        if(Input.touchCount > 0)
        {
            ScreenTouched();
        }
    }

    private void ScreenTouched()
    {
        touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Moved)
        {
            MoveObject();
        }
    }

    private void MoveObject()
    {
        transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speedModifier, transform.position.y, transform.position.z + touch.deltaPosition.y * speedModifier);
    }
} 
