using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButtonScript : MonoBehaviour
{
    public void ReturnToMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}