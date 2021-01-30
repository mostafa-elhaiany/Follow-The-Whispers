using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlightPower : MonoBehaviour
{
    GameManager manager;
    public float timeToDeplete;
    float timer;
    public float depleteAmmount;
    Light light;
    float maxIntensity;
    Transform capsule;
    Vector3 maxScale;
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        timer = timeToDeplete;
        light = this.GetComponent<Light>();
        maxIntensity = light.intensity;
        capsule = transform.GetChild(0);
        maxScale = capsule.localScale;
    }

    void Update()
    {
        handleDeplete();
        if(manager.getBatteryPower()>=0)
            handlePower();
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
