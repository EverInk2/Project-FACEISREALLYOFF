using System.ComponentModel;
using UnityEngine;
using UnityEngine.Rendering;

public class PauseMenu : MonoBehaviour
{
    
    
    [SerializeField] Sprite[] menuSprites;
    bool menuOpen = false;
    public GameObject container;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && menuOpen == false)
        {
            container.SetActive(false);
            Time.timeScale = 0f;
            menuOpen = true;
        }

        container.SetActive(menuOpen);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        menuOpen = false;
    }

    

    /// <summary>
    /// moves the game scene back to the main menu
    /// </summary>
    public void MainMenu()
    {
        //load scene when we have it
        //UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
