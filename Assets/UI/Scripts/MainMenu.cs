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
    public GameObject loading;
    public GameObject howToPlayPannel;
    public GameObject CreditsPannel;

    public string gameSceneName;
    
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        howToPlayPannel.SetActive(false);
        CreditsPannel.SetActive(false);


        start = GameObject.Find("Start").GetComponent<Button>();
        howToPlay = GameObject.Find("HowTo").GetComponent<Button>();
        credits = GameObject.Find("Credits").GetComponent<Button>();
        quit = GameObject.Find("Quit").GetComponent<Button>();

        start.onClick.AddListener(StartGame);
        credits.onClick.AddListener(ShowCredits);
        howToPlay.onClick.AddListener(ShowHowToPlay);
        quit.onClick.AddListener(Quit);
        gameSceneName = "Level1"; //ToDo add choose level scene


        loading.SetActive(false);
        start.gameObject.SetActive(true);
        howToPlay.gameObject.SetActive(true);
        credits.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            howToPlayPannel.SetActive(false);
            CreditsPannel.SetActive(false);
        }
    }

    public void StartGame(){
        //Debug.Log("CLICKED");
        //TODO: UNCOMMENT
        loading.SetActive(true);
        start.gameObject.SetActive(false);
        howToPlay.gameObject.SetActive(false);
        credits.gameObject.SetActive(false);
        quit.gameObject.SetActive(false);

        SceneManager.LoadScene(gameSceneName);
		
	}
    public void ShowCredits(){
        CreditsPannel.SetActive(true);
    }
    
    public void ShowHowToPlay(){
        howToPlayPannel.SetActive(true);
    }

    public void Quit(){
        Application.Quit();
		
	}

   
}
