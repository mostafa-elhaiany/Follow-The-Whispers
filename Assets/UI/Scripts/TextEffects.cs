using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class TextEffects : MonoBehaviour
{
    //Fade time in seconds
         public float fadeOutTime=5.0f;
          Text text;
         public float alpha;
         bool brighten;
    // Start is called before the first frame update
    public bool flashing;
    void Start()
    {
        text = GetComponent<Text>();

    //     alpha=0.0f;
    //     brighten= true;
      
    //    Color originalColor = text.color;
    //    originalColor.a = 0f;
    //    text.color = originalColor;

        
        if(!flashing)
            alpha =0.0f;
        else
            alpha=1.0f;
        brighten= false;

        
    }

    // Update is called once per frame
    void Update()
    {

        // if(alpha<3.0f){
        //     Color originalColor = text.color;

        //      for (float t = 0.01f; t < fadeOutTime; t += Time.deltaTime)
        //      {
        //          Debug.Log(alpha);

        //          if(brighten){

        //         originalColor.a = alpha+0.04f;
        //          alpha = alpha+0.04f;

        //          text.color = originalColor;
        //          if(alpha>=1.5f){
        //              brighten=false;
        //          }

        //          }
        //          else{
        //              if(alpha>-1.0f){
        //              originalColor.a = alpha-0.003f;
        //             alpha = alpha-0.003f;
        //             text.color = originalColor;
        //              }

        //          }
                 
                 
        //      }
        // }
        

        
        if(alpha<1.0f || flashing){
            Color originalColor = text.color;

             for (float t = 0.01f; t < fadeOutTime; t += Time.deltaTime)
             {
                 //text.color = Color.Lerp(originalColor, Color.clear, Mathf.Min(1, t/fadeOutTime));
                 //Color originalColor  = text.color;
                 if(flashing){
                     if(brighten){
                        originalColor.a = alpha+0.4f;
                        alpha = alpha+0.4f;
                        if(Math.Abs(alpha-1.0)<0.01){
                            brighten=false;

                     }

                     }
                     
                     else{
                        originalColor.a = alpha-0.4f;
                        alpha = alpha-0.004f;
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

