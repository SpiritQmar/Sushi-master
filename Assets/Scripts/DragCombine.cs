using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCombine : MonoBehaviour
{
    private Vector2 mousePosition;
    private float offsetX, offsetY;
    public static bool mouseButtonReleased;

    private void OnMouseDown()
    {
        mouseButtonReleased = false;
        offsetX = transform.position.x - Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        offsetY = transform.position.y - Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
    }

    private void OnMouseDrag()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePosition.x + offsetX, mousePosition.y + offsetY);
    }

    private void OnMouseUp()
    {
        mouseButtonReleased = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        string thisGameObjectName = gameObject.tag;  
        string collisionGameObjectName = collision.gameObject.tag;  

        if (mouseButtonReleased && ((thisGameObjectName == "Rice" && collisionGameObjectName == "SalmonFishPiece") || (thisGameObjectName == "SalmonFishPiece" && collisionGameObjectName == "Rice")))
        {
            CreateSushiObject(collision, "Sushi_Object", "RiceRespawnPoint");
        }
        else if (mouseButtonReleased && ((thisGameObjectName == "Rice" && collisionGameObjectName == "EelFishPiece") || (thisGameObjectName == "EelFishPiece" && collisionGameObjectName == "Rice")))
        {
            CreateSushiObject(collision, "EelSushi_Object", "RiceRespawnPoint");
        }
    }

    private void CreateSushiObject(Collider2D collision, string sushiObjectName, string respawnPointName)
    {
        GameObject riceRespawnPoint = GameObject.Find(respawnPointName);
        Instantiate(Resources.Load(sushiObjectName), transform.position, Quaternion.identity);
        mouseButtonReleased = false;        
        Destroy(collision.gameObject);
        Destroy(gameObject);
            
         
        Instantiate(Resources.Load("Rice_Object"), riceRespawnPoint.transform.position, Quaternion.identity);
    }
}
