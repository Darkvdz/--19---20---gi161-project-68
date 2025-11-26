using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Select Hero"); 
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("QUIT GAME"); 
    }
}