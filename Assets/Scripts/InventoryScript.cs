using UnityEngine;
using System.Collections.Generic;

public class InventoryScript : MonoBehaviour
{
    public int maxItems = 2;
    public int currentitemCount = 0;

    public GameObject slot1;
    public GameObject slot2;
    public GameObject redZone; // used for deleting via collision
    public GameObject combineZone;
    public GameObject combineSlot;

    public bool slot1Taken = false;
    public bool slot2Taken = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        slot1 = GameObject.FindWithTag("slot1");
        slot2 = GameObject.FindWithTag("slot2");
        redZone = GameObject.FindWithTag("redzone");
        combineZone = GameObject.FindWithTag("combine");
        combineSlot = GameObject.FindWithTag("combineslot");
        // hide them
        if (slot1 != null)
        {
            slot1.GetComponent<Renderer>().enabled = false;
        }
        if (slot2 != null)
        {
            slot2.GetComponent<Renderer>().enabled = false;
        }
        if (redZone != null)
        {
            redZone.SetActive(false); // inactive at first
        }
        if (combineZone != null)
        {
            combineZone.GetComponent<Renderer>().enabled = false; // inactive at first
        }
        if (combineSlot != null)
        {
            combineSlot.GetComponent<Renderer>().enabled = false; // inactive 
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("location" + slot1.transform.position);
        // Debug.Log("location" + slot2.transform.position);
    }
}
