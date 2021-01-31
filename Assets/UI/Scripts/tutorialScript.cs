using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class tutorialScript : MonoBehaviour
{
    public GameObject[] tutorials;
    int indx = 0;
    public GameObject text; 
    private void Start()
    {
        Time.timeScale = 0;
    }


    void Update()
    {
        tutorials[indx].SetActive(true);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            tutorials[indx++].SetActive(false);
        }
        if(indx>= tutorials.Length)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        Time.timeScale = 1;
        text.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
