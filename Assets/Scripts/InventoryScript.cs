using UnityEngine;
using System.Collections.Generic;

public class InventoryScript : MonoBehaviour
{
    public int maxItems = 2;
    public int currentitemCount = 0;

    public GameObject slot1;
    public GameObject slot2;

    public bool slot1Taken = false;
    public bool slot2Taken = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // hide them
        slot1.GetComponent<Renderer>().enabled = false;
        slot2.GetComponent<Renderer>().enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("location" + slot1.transform.position);
        // Debug.Log("location" + slot2.transform.position);
    }
}
