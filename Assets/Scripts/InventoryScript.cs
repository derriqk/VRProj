using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public GameObject[] inv;

    public int maxItems = 2;
    public int currentitemCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inv = new GameObject[2];
    }

    // Update is called once per frame
    void Update()
    {
       
    }

}
