using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class chooseLevelScript : MonoBehaviour
{
    public Button startLevel;
    public Button startTutorial;

    public GameObject loading;
    public GameObject menuPannel;

    void Start()
    {
        startLevel.onClick.AddListener(startLevelClick);
        startTutorial.onClick.AddListener(startTutorialClick);
    }

    void startLevelClick()
    {
        SceneManager.LoadScene("Level1");
        loading.SetActive(true);
        startLevel.gameObject.SetActive(true);
        startTutorial.gameObject.SetActive(true);
    }
    void startTutorialClick()
    {
        SceneManager.LoadScene("Tut1");
        loading.SetActive(true);
        startLevel.gameObject.SetActive(true);
        startTutorial.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            this.gameObject.SetActive(false);
            menuPannel.SetActive(true);
            loading.SetActive(false);
        }
    }
}
