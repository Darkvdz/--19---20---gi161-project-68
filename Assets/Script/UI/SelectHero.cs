using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectHero : MonoBehaviour
{
    public void PickHero(int heroID)
    {
        PlayerPrefs.SetInt("SelectedHero", heroID);
        
        SceneManager.LoadScene("SampleScene"); 
    }
    
    public void BackToMain()
    {
        SceneManager.LoadScene("Main Menu"); 
    }
}