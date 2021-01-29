using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyGenerator : MonoBehaviour
{
    public GameObject[] positions;

    public GameObject[] activeKeys;

    public GameObject[] otherKeys;

    void Start()
    {
        positions = GameObject.FindGameObjectsWithTag("KeyGenerator");

        if (activeKeys.Length + otherKeys.Length > positions.Length)
        {
            Debug.LogError("number of key positions less than number of available keys please add more generators");
        }

        Shuffle(positions);

        foreach (GameObject activeKey in activeKeys)
        {
            Transform pos = positions[0].transform;
            Remove(0);
            Instantiate(activeKey, pos.position, pos.rotation);
            Destroy(pos.gameObject);
        }

        Shuffle(positions);
        foreach (GameObject key in otherKeys)
        {
            Transform pos = positions[0].transform;
            Remove(0);
            Instantiate(key, pos.position, pos.rotation);
            Destroy(pos.gameObject);
        }


        foreach(GameObject pos in positions)
        {
            Destroy(pos);
        }


    }

    void Remove(int index)
    {
        GameObject[] newPositions = new GameObject[positions.Length - 1];
        int pos = 0;
        for (int i = 0; i < positions.Length; i++)
        {
            if(i!=index)
            {
                newPositions[pos] = positions[i];
                pos++;
            }
        }
        positions = newPositions;
    }

    void Shuffle(GameObject[] array)
    {
        int p = array.Length;
        for (int n = p - 1; n > 0; n--)
        {
            int r = Random.Range(1, n);
            GameObject t = array[r];
            array[r] = array[n];
            array[n] = t;
        }

    }
}
