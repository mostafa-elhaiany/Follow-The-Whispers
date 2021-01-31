using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlightPower : MonoBehaviour
{
    GameManager manager;
    AudioManager audioManager;
    public float timeToDeplete;
    float timer;
    public float depleteAmmount;
    new Light light;
    float maxIntensity;
    Transform capsule;
    Vector3 maxScale;
    GameObject[] ghosts;
    bool talk = true;
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        audioManager = FindObjectOfType<AudioManager>();
        timer = timeToDeplete;
        light = this.GetComponent<Light>();
        maxIntensity = light.intensity;
        capsule = transform.GetChild(0);
        maxScale = capsule.localScale;
        ghosts = GameObject.FindGameObjectsWithTag("Ghost");
    }

    void Update()
    {
        handleDeplete();
        if(manager.getBatteryPower()>=0)
            handlePower();
        handleTalk();
        handleGhosts();
    }

    void handleGhosts()
    {
        bool active = manager.getBatteryPower() <= 0.4;
        foreach(GameObject ghost in ghosts)
        {
            ghost.SetActive(active);
        }
    }


    void handleTalk()
    {
        if (manager.getBatteryPower() <= 0.4 && talk)
        {
            audioManager.play("batteries");
            talk = false;
            StartCoroutine("enableTalk");
        }
    }
    IEnumerator enableTalk()
    {
        yield return new WaitForSeconds(10);
        talk = true;
    }

    void handleDeplete()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = timeToDeplete;
            manager.depletePower(depleteAmmount);
            
        }
    }

    void handlePower()
    {
        float power = manager.getBatteryPower();
        light.intensity = maxIntensity * power;
        capsule.localScale = maxScale * power;

    }

}
