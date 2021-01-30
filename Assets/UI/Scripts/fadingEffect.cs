using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class fadingEffect : MonoBehaviour
{
    public float fadeOutTime=7.0f;
    
         public float alpha;
         bool brighten;
         public Image panel;

         public Text text;
         public GameObject parentPanel;
         private float waitTime = 2.0f;
         public Canvas mycanvas;
    private float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {

        alpha=0.0f;
        brighten= true;
       panel =  parentPanel.GetComponent<Image>();
       

       Color originalColor = panel.color;
       originalColor.a = 0f;
       panel.color = originalColor;

       Color originalColorText = text.color;
       originalColorText.a = 0f;
       text.color = originalColorText;
       

        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // Check if we have reached beyond 2 seconds.
        // Subtracting two is more accurate over time than resetting to zero.
        if (timer > waitTime)
        {
            

            // Remove the recorded 2 seconds.
            timer = timer - waitTime;
            //enabled=false;
            mycanvas.enabled=false;
            
        }
        
            Color originalColor = text.color;

             for (float t = 0.01f; t < waitTime; t += Time.deltaTime)
             {
                 //text.color = Color.Lerp(originalColor, Color.clear, Mathf.Min(1, t/fadeOutTime));
                 //Color originalColor  = text.color;
                


                 if(alpha<1){
                 originalColor.a = alpha+0.000003f;
                 alpha = alpha+0.000003f;
                 text.color = originalColor;
                 }

                 if(alpha>1){
                originalColor.a = alpha+0.000003f;
                 alpha = alpha+0.000003f;
                 text.color = originalColor;
                 }

                 
                 
                 
             }
        
        // if(alpha<3.0f){
        //     Color originalColor = panel.color;
            //  float time_=0.01f;

            //  for (float t = 0.01f; t < fadeOutTime; t += Time.deltaTime)
            //  {
            //       time_=t;

            //     //  if(originalColor.a>-1.0f){
            //     //      originalColor.a = originalColor.a-0.00003f;
            //     //     //alpha = alpha-0.00003f;
            //     //     panel.color = originalColor;
            //     //      }

                 
                 
            //  }
            //  if(time_>=fadeOutTime){
            //      enabled=false;
            //  }
        // }

        // if(alpha<3.0f){
        //     Color originalColor = panel.color;

        //      for (float t = 0.01f; t < fadeOutTime; t += Time.deltaTime)
        //      {
        //          Debug.Log(alpha);

        //          if(brighten){

        //         originalColor.a = alpha+0.0004f;
        //          alpha = alpha+0.0004f;

        //          panel.color = originalColor;
        //          if(alpha>=1.5f){
        //              brighten=false;
        //          }

        //          }
        //          else{
        //              if(alpha>-1.0f){
        //              originalColor.a = alpha-0.00003f;
        //             alpha = alpha-0.00003f;
        //             panel.color = originalColor;
        //              }

        //          }
                 
                 
        //      }
        // }
        
    }
}
