using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class inGameScript : MonoBehaviour
{

    public Canvas canvas;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
       

        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z)){
            panel.SetActive(!panel.activeSelf);
        }

        
    }
}
