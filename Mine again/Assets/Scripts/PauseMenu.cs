using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{

    public static bool isPaused;

    public GameObject pausemenuUI;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

   public void Resume()
    {
        pausemenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    void Pause()
    {
        pausemenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void LoadMenu()
    {
       // Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitMenu()
    {
        Debug.Log("QUIT!!");
        Application.Quit();
    }

}//calass






