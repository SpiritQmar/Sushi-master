using UnityEngine;
using UnityEngine.UI;

public class SalmonButton : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        GameManager.instance.SpawnPrefab();
        GameManager.instance.ChangeScene("MainScene");
    }
}