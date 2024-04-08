using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragLimitedArea : MonoBehaviour
{
    private Vector2 initialPosition;
    private bool isDragging = false;

    public Collider2D allowedArea;  
    public void SetAllowedArea(Collider2D area)
    {
        allowedArea = area;
    }

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void OnMouseDown()
    {
        isDragging = true;
    }

    private void OnMouseUp()
    {
        isDragging = false;
         
        if (allowedArea != null && !allowedArea.OverlapPoint(transform.position))
        {
            transform.position = initialPosition;
        }
    }

    private void Update()
    {
        if (isDragging)
        {
            if (allowedArea != null)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 newPosition = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);

                 
                if (transform != null)
                {
                    transform.position = newPosition;
                }
            }
        }
    }
}