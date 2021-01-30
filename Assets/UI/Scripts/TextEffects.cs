using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class TextEffects : MonoBehaviour
{
    //Fade time in seconds
         public float fadeOutTime;
          Text text;
         public float alpha;
         bool brighten;
    // Start is called before the first frame update
    public bool flashing;
    void Start()
    {

        text = GetComponent<Text>();
        if(!flashing)
            alpha =0.0f;
        else
            alpha=1.0f;
        brighten= false;

        
    }

    // Update is called once per frame
    void Update()
    {
        

        
        if(alpha<1.0f || flashing){
            Color originalColor = text.color;

             for (float t = 0.01f; t < fadeOutTime; t += Time.deltaTime)
             {
                 //text.color = Color.Lerp(originalColor, Color.clear, Mathf.Min(1, t/fadeOutTime));
                 //Color originalColor  = text.color;
                 if(flashing){
                     if(brighten){
                        originalColor.a = alpha+0.0004f;
                        alpha = alpha+0.000004f;
                        if(Math.Abs(alpha-1.0)<0.01){
                            brighten=false;

                     }

                     }
                     
                     else{
                        originalColor.a = alpha-0.0004f;
                        alpha = alpha-0.000004f;
                        if(Math.Abs(alpha-0)<0.01){
                            brighten=true;
                        }

                     }
                     text.color = originalColor;
                 }


                 else{
                 originalColor.a = alpha+0.000003f;
                 alpha = alpha+0.000003f;
                 text.color = originalColor;
                 }
                 
                 
             }
        }
        
    }

    
}

