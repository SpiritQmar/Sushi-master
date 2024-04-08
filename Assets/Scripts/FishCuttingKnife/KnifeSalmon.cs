using UnityEngine;

public class DragAndReturn : MonoBehaviour
{
    private Vector3 initialPosition;
    private bool isDragging = false;
    public GameObject fishPiecePrefabSalmon; // Ссылка на префаб куска рыбы
    public GameObject fishPiecePrefabEel;
    public GameObject fishPiecePrefabShrimp;
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
        transform.position = initialPosition;
    }

    private void Update()
    {
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, initialPosition.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isDragging && other.CompareTag("SalmonFish"))
        {
            Destroy(other.gameObject); // Уничтожаем рыбу
            CreateSalmonFishPiece(); // Создаем кусок рыбы
        }
        if (isDragging && other.CompareTag("EelFish"))
        {
            Destroy(other.gameObject); // Уничтожаем рыбу
            CreateEelFishPiece(); // Создаем кусок рыбы
        }
        if (isDragging && other.CompareTag("ShrimpFish"))
        {
            Destroy(other.gameObject); // Уничтожаем рыбу
            CreateShrimpFishPiece(); // Создаем кусок рыбы
        }
    }
    private void CreateSalmonFishPiece()
    {
        if (fishPiecePrefabSalmon != null)
        {
            GameObject fishPiece = Instantiate(fishPiecePrefabSalmon, transform.position, Quaternion.identity);

        }
    }
    private void CreateEelFishPiece()
    {
        if (fishPiecePrefabEel != null)
        {
            GameObject fishPiece = Instantiate(fishPiecePrefabEel, transform.position, Quaternion.identity);

        }
    }
    private void CreateShrimpFishPiece()
    {
        if (fishPiecePrefabShrimp != null)
        {
            GameObject fishPiece = Instantiate(fishPiecePrefabShrimp, transform.position, Quaternion.identity);
        
        }
    }
}