using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public RawImage menu;
    public Button resume;
    public Button restart;
    public Button mainMenu;

    void Start()
    {
        menu.gameObject.SetActive(false);
        resume.onClick.AddListener(resumeOnClick);
        restart.onClick.AddListener(restartOnClick);
        mainMenu.onClick.AddListener(menuOnClick);
    }

    void resumeOnClick()
    {
        GameManager.isPaused = false;
    }

    void restartOnClick()
    {
        SceneManager.LoadScene("the game");
    }

    void menuOnClick()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.isPaused = !GameManager.isPaused;
        }

        menu.gameObject.SetActive(GameManager.isPaused);
    }
}
