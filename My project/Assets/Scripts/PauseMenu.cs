using UnityEngine;
using UnityEngine.Rendering;

public class PauseMenu : MonoBehaviour
{
    bool menuOpen = false;
    public GameObject container;

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
