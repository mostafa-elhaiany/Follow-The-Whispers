using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class tutorialTextScript : MonoBehaviour
{
    //float timer = 5;
    public GameObject[] objects;
    public GameObject[] texts;
    public int indx = 0;
    int prev = -1;
    GameManager manager;

    public GameObject donePannel;

    private void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if(indx>=objects.Length)
        {
            Destroy(this.gameObject);
        }
        else if(indx!=prev)
        {
            if(prev!=-1)
                texts[prev].SetActive(false);
            prev = indx;
            objects[indx].SetActive(true);
            texts[indx].SetActive(true);
            if (indx == 1 && indx != prev)
            {
                FindObjectOfType<ObjectiveManager>().findKeys();
            }
        }
        handleIndx();
        
    }

    void handleIndx()
    {

        if (manager.getBatteryPower() >=0.9f && indx ==0)
        {
            indx++;
        }
        else if(manager.getActiveCollectedKeys()==3 && indx ==1)
        {
            indx++;
        }
        else if(GameObject.FindGameObjectWithTag("Sister").GetComponent<sisterLogic>().isRescued && indx ==2)
        {
            indx++;
        }
        else if(Input.GetKeyDown(KeyCode.LeftControl) && indx==3)
        {
            indx++;
        }
        if (manager.getCollectedKeys() == 14 && indx == 4)
        {
            indx++;
        }
    }
    private void OnDestroy()
    {
        donePannel.SetActive(true);
    }
}
