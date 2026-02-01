using System.ComponentModel;
using UnityEngine;
using UnityEngine.Rendering;

public class PauseMenu : MonoBehaviour
{
    public enum MenuOptions
    {
        Resume,
        MainMenu,
        Quit
    }
    
    [SerializeField] Sprite[] menuSprites;
    bool menuOpen = false;
    public GameObject container;
    public MenuOptions currentOption = MenuOptions.Resume;

    public float menubuffer = 1f;
    public float currentbuffer = 0f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Cancel") > 0 && menuOpen == false && currentbuffer >= menubuffer)
        {
            container.SetActive(false);
            Time.timeScale = 0f;
            menuOpen = true;
            currentbuffer = 0f;
        }
        // else if(Input.GetAxis("Cancel") > 0 && menuOpen == true && currentbuffer >= menubuffer)
        // {
        //     container.SetActive(true);
        //     Time.timeScale = 1f;
        //     menuOpen = false;
        //     currentbuffer = 0f;
        // }

        if(menuOpen)
        {
            if(Input.GetAxis("Vertical") > 0 && (int) currentOption > 0)
            {
                currentOption--;
                 
            }
            else if(Input.GetAxis("Vertical") < 0 && (int) currentOption < System.Enum.GetNames(typeof(MenuOptions)).Length - 1)
            {
                currentOption++;
            }

        }



        container.SetActive(menuOpen);
        currentbuffer += Time.unscaledDeltaTime;
    }

    

    /// <summary>
    /// moves the game scene back to the main menu
    /// </summary>
    public void mainMenu()
    {
        //load scene when we have it
        //UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
