using UnityEngine;

public class Combine : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject item1;
    public GameObject item2;

    public bool item1Taken = false;
    public bool item2Taken = false;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (item1Taken && item2Taken) // this means it is full, and combining should be done
        {
            // logic
        }


    }
    
    
}
