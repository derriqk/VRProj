using UnityEngine;

public class PlantSpawner : MonoBehaviour
{
    public GameObject plantproto;
    public GameObject spawnlocation; // will spawn plants on this
    float spawnrate = 0f; // will check for spawning
    int maxplants = 5; // max plants allowed   
    public int currentplants = 0; // current plants in the scene



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        spawnrate += Time.deltaTime;
        if (spawnrate > 3f && currentplants < maxplants)
        {
            Vector3 localPos = new Vector3(Random.Range(-0.5f, 0.5f), 0f, Random.Range(-0.5f, 0.5f));

            Vector3 spawnpos = spawnlocation.transform.TransformPoint(localPos);
            GameObject herb = Instantiate(plantproto, spawnpos, Quaternion.identity);
            //herb.GetComponent<GrabHerbBehavior>().spawnerScript = this;
            spawnrate = 0f;

            currentplants++;
        }
    }
}
