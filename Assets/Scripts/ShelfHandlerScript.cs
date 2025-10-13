using UnityEngine;

public class ShelfHandlerScript : MonoBehaviour
{
    public GameObject[] shelf = new GameObject[10];
    public int[] initValues = new int[10];
    public Color[] colors = new Color[10];

    public GameObject killslot;

    // inv
    public GameObject combineSlot;
    public GameObject inv;
    public InventoryScript invScript;

    public GameObject plantProto;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // init colors and values
         for (int i = 0; i < 5; i++)
        {
            colors[i] = new Color(0.8f - i * 0.1f, 0.0f + i * 0.02f, 1.0f);
            colors[i+5] = new Color(1.0f, 0.84f - i * 0.08f, 0.2f + i * 0.05f);
        }
        for (int i = 0; i < 5; i ++)
        {
            initValues[i] = i - 5;
            initValues[i + 5] = i + 1;
        }
        // make all slots invisible
        for (int i = 0; i < 10; i++)
        {
            shelf[i].GetComponent<Renderer>().enabled = false;
        }

        // populate and make true since it is there
        for (int i = 0; i < 10; i++)
        {
            Vector3 spawnpos = shelf[i].transform.position;
            GameObject herb = Instantiate(plantProto, spawnpos, Quaternion.identity);
            herb.GetComponent<GrabHerbBehavior>().shelfSlot = i;
            herb.GetComponent<GrabHerbBehavior>().initValue = initValues[i];
            herb.GetComponent<GrabHerbBehavior>().shelfitem = true;
            herb.GetComponent<Renderer>().material.color = colors[i];
        }
        // kill slot
        killslot.GetComponent<Renderer>().enabled = false;
        Vector3 tempspawn = killslot.transform.position;
        GameObject temp = Instantiate(plantProto, tempspawn, Quaternion.identity);
        temp.GetComponent<GrabHerbBehavior>().shelfSlot = 15;
        temp.GetComponent<GrabHerbBehavior>().initValue = 100;
        temp.GetComponent<GrabHerbBehavior>().toKill = true;
        temp.GetComponent<GrabHerbBehavior>().shelfitem = true;
        temp.GetComponent<Renderer>().material.color = Color.black;

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void replaceShelfSlot(int i) // replaces a given i-th shelf slot called by GrabHerbBehavior
    {
        if (i == 15)
        {
            Vector3 spawnpos = killslot.transform.position;
            GameObject herb = Instantiate(plantProto, spawnpos, Quaternion.identity);
            herb.GetComponent<GrabHerbBehavior>().shelfSlot = 15;
            herb.GetComponent<GrabHerbBehavior>().initValue = 100;
            herb.GetComponent<GrabHerbBehavior>().toKill = true;
            herb.GetComponent<GrabHerbBehavior>().shelfitem = true;
            herb.GetComponent<Renderer>().material.color = Color.black;
        } else
        {
            Vector3 spawnpos = shelf[i].transform.position;
            GameObject herb = Instantiate(plantProto, spawnpos, Quaternion.identity);
            herb.GetComponent<GrabHerbBehavior>().shelfSlot = i;
            herb.GetComponent<GrabHerbBehavior>().initValue = initValues[i];
            herb.GetComponent<Renderer>().material.color = colors[i];
            herb.GetComponent<GrabHerbBehavior>().shelfitem = true;
        }
        
    }

    public void combineInstantiate(GameObject item1, GameObject item2)
    {
        Vector3 spawnpos = combineSlot.transform.position;
        GameObject herb = Instantiate(plantProto, spawnpos, Quaternion.identity);
        herb.GetComponent<GrabHerbBehavior>().shelfSlot = -1;
        herb.GetComponent<GrabHerbBehavior>().wasCombined = true;
        if (item1.GetComponent<GrabHerbBehavior>().toKill || item2.GetComponent<GrabHerbBehavior>().toKill)
        {
            herb.GetComponent<Renderer>().material.color = Color.black;
        } else
        {
            herb.GetComponent<Renderer>().material.color = Color.blue;
        }
        herb.GetComponent<GrabHerbBehavior>().initValue = item1.GetComponent<GrabHerbBehavior>().initValue + item2.GetComponent<GrabHerbBehavior>().initValue;
    }
}
