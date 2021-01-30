using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyGenerator : MonoBehaviour
{
    public GameObject[] positions;
    public GameObject[] roomPositions;

    public GameObject[] activeKeys;
    public GameObject roomKey;

    public GameObject[] otherKeys;

    void Start()
    {
        positions = GameObject.FindGameObjectsWithTag("KeyGenerator");
        roomPositions = GameObject.FindGameObjectsWithTag("RoomKeyGenerator");

        if ( activeKeys.Length + otherKeys.Length > positions.Length)
        {
            Debug.LogError("number of key positions less than number of available keys please add more generators");
        }

        Shuffle(positions);
        Shuffle(roomPositions);
        Transform pos;
        int indx = Random.Range(0, roomPositions.Length);
        pos = roomPositions[indx].transform;
        Remove2(indx);
        Instantiate(roomKey, pos);

        foreach (GameObject activeKey in activeKeys)
        {
            pos = positions[0].transform;
            Remove1(0);
            Instantiate(activeKey, pos);
        }

        Shuffle(positions);
        foreach (GameObject key in otherKeys)
        {
            pos = positions[0].transform;
            Remove1(0);
            Instantiate(key, pos);
        }


        foreach(GameObject obj in positions)
        {
            Destroy(obj);
        }
        foreach (GameObject obj in roomPositions)
        {
            Destroy(obj);
        }

    }

    void Remove1(int index)
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


    void Remove2(int index)
    {
        GameObject[] newPositions = new GameObject[roomPositions.Length - 1];
        int pos = 0;
        for (int i = 0; i < roomPositions.Length; i++)
        {
            if (i != index)
            {
                newPositions[pos] = roomPositions[i];
                pos++;
            }
        }
        roomPositions = newPositions;
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
