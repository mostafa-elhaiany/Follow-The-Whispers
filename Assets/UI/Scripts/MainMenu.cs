using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public Button start;
    Button howToPlay;
    Button credits;
    Button quit;
    public string gameSceneName;
    public string creditsSceneName;
    public string howToPlaySceneName;
    
    void Start()
    {
        start = GameObject.Find("Start").GetComponent<Button>();
        howToPlay = GameObject.Find("HowTo").GetComponent<Button>();
        credits = GameObject.Find("Credits").GetComponent<Button>();
        quit = GameObject.Find("Quit").GetComponent<Button>();

        start.onClick.AddListener(StartGame);
        credits.onClick.AddListener(ShowCredits);
        howToPlay.onClick.AddListener(ShowHowToPlay);
        quit.onClick.AddListener(Quit);
        //Debug.Log(GameObject.Find("Start").name);
        gameSceneName = "the game";
        creditsSceneName = "Credits";
        howToPlaySceneName = "HowToPlay";

        
    }

    public void StartGame(){
        //Debug.Log("CLICKED");
        //TODO: UNCOMMENT
        SceneManager.LoadScene(gameSceneName);
		
	}
    public void ShowCredits(){
        //Debug.Log("CLICKED");
        SceneManager.LoadScene(creditsSceneName);
		
	}
    
    public void ShowHowToPlay(){
        //Debug.Log("CLICKED");
        SceneManager.LoadScene(howToPlaySceneName);
		
	}
    
    public void Quit(){
        Application.Quit();
		
	}

   
}
