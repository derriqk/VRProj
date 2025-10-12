using UnityEngine;
using System.Collections;

public class Combine : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject item1;
    public GameObject item2;

    public GameObject herb;

    public bool item1Taken = false;
    public bool item2Taken = false;

    public GameObject combineSlot;
    public GameObject inv;
    public InventoryScript invScript;
    public GameObject shelfHandler;
    public ShelfHandlerScript shelfScript;


    void Start()
    {
        combineSlot = GameObject.FindWithTag("combineslot");
        inv = GameObject.FindWithTag("inventory");
        if (inv != null)
        {
            invScript = inv.GetComponent<InventoryScript>();
        }
        shelfHandler = GameObject.FindWithTag("shelfhandler");
        if (shelfHandler != null)
        {
            shelfScript = shelfHandler.GetComponent<ShelfHandlerScript>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (item1Taken && item2Taken) // this means it is full, and combining should be done
        {
            item1Taken = false;
            item2Taken = false;
            StartCoroutine(combining(1));
        }
    }
    
    private IEnumerator combining(float delay)
  {
    yield return new WaitForSeconds(delay);
    shelfScript.combineInstantiate(item1, item2);
    invScript.currentitemCount = 0;
    invScript.slot1Taken = false;
    invScript.slot2Taken = false;
    Destroy(item1);
    Destroy(item2);
  }
}
