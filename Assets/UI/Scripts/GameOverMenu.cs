using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverMenu : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    public Button mainMenu;
    
    Button quit;
    public string MainMenuSceneName ="MainMenu";
    
    void Start()
    {

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        mainMenu = GameObject.Find("MainMenu").GetComponent<Button>();
        
        quit = GameObject.Find("Quit").GetComponent<Button>();

        mainMenu.onClick.AddListener(ShowMainMenu);
        
        quit.onClick.AddListener(Quit);
        //MainMenuSceneName
        //Debug.Log(GameObject.Find("Start").name);
        
    }

    public void ShowMainMenu(){
        Debug.Log("CLICKED");
        //TODO: UNCOMMENT
        //SceneManager.LoadScene(MainMenuSceneName);
		
	}
    public void Quit(){
        Debug.Log("Bye");
        Application.Quit();
		
	}
}
