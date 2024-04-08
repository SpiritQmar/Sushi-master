using UnityEngine;
public class FishSalmonSpawner : MonoBehaviour
{
    public GameObject fishSalmonPrefab;

    void Start()
    {
        if (GameManager.instance && GameManager.instance.shouldSpawn)
        {
            Instantiate(fishSalmonPrefab, transform.position, Quaternion.identity);
            GameManager.instance.shouldSpawn = false;
        }
    }
}