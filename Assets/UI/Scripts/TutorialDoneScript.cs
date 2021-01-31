using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialDoneScript : MonoBehaviour
{
    public Button restart;
    public Button menu;


    // Start is called before the first frame update
    void Start()
    {
        GameManager.isPaused = true;
        restart.onClick.AddListener(restartOnClick);
        menu.onClick.AddListener(returnToMenu);
    }

    void restartOnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void returnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
