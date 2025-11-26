using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseSystem : MonoBehaviour
{
    [Header("UI Reference")]
    public GameObject pauseMenuPanel;
    public GameObject gameOverPanel;
    public GameObject winPanel;
    
    private bool isPaused = false;
    
    void Start()
    {
        if (pauseMenuPanel != null)
        {
            pauseMenuPanel.SetActive(false);
        }
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        if (winPanel != null)
        {
            winPanel.SetActive(false);
        }
        
        Time.timeScale = 1f;
        isPaused = false;
    }
    
    public void ShowGameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true); 
            Time.timeScale = 0f;           
        }
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame(); 
            }
            else
            {
                PauseGame(); 
            }
        }
    }

    public void PauseGame()
    {
        pauseMenuPanel.SetActive(true); 
        Time.timeScale = 0f; 
        isPaused = true;
    }
    
    public void ShowVictory()
    {
        if (winPanel != null)
        {
            winPanel.SetActive(true); 
            Time.timeScale = 0f;         
        }
    }

    public void ResumeGame()
    {
        pauseMenuPanel.SetActive(false); 
        Time.timeScale = 1f; 
        isPaused = false;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("Main Menu"); 
    }

    public void GoToSelectHero()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("Select Hero"); 
    }
    
    
}