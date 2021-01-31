using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gameWin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Sister"))
        {
            if(SceneManager.GetActiveScene().Equals("Level1"))
                SceneManager.LoadScene("Level2");
            else
                SceneManager.LoadScene("Credits");
        }
    }
}
