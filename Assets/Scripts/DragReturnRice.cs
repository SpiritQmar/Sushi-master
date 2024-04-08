using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiceManager : MonoBehaviour
{
    public GameObject ricePrefab;  
    private GameObject currentRice;

    void Start()
    {
        SpawnRice();
    }

    void Update()
    {
        if (currentRice == null)
        {
            SpawnRice();
        }
    }

    void SpawnRice()
    {
        currentRice = Instantiate(ricePrefab, transform.position, Quaternion.identity);
    }
}
