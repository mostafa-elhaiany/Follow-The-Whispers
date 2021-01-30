using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class inGameScript : MonoBehaviour
{

    public Canvas canvas;
    public GameObject panel;
    // Start is called before the first frame update
    public RawImage[] keysImages;
    public string keyName;
    void Start()
    {
        for(int i=0; i<keysImages.Length;i++){
            //set all keys to false
           keysImages[i].enabled=false;

        }
       

        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z)){
            panel.SetActive(!panel.activeSelf);
        }
        //if(Input.GetKeyDown(KeyCode.KeypadEnter)){
            keyFound();
        //}


        
    }
    public void keyFound(){

        for(int i=0; i<keysImages.Length;i++){
            //get the image u need
            //Debug.Log(keysImages[i].GetComponent<RawImage>().texture.name);
            if(keyName.Contains(keysImages[i].GetComponent<RawImage>().texture.name) ){
                keysImages[i].enabled=true;
            }

        }


    }
}
