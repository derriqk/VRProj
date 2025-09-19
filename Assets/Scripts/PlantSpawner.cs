using UnityEngine;

public class PlantSpawner : MonoBehaviour
{
    public GameObject plantproto;
    public GameObject spawnlocation; // will spawn plants on this
    Bounds spawnarea; // area to spawn in
    float spawnrate = 0f; // will check for spawning

    int maxplants = 5; // max plants allowed   
    int currentplants = 0; // current plants in the scene

    float[] x = new float[2];
    float[] y = new float[2];
    float[] z = new float[2];



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnlocation.GetComponent<Renderer>().enabled = false;
        spawnarea = spawnlocation.GetComponent<Collider>().bounds;

        // storing the min and max bounds to use randomness
        x[0] = spawnarea.min.x;
        x[1] = spawnarea.max.x;
        y[0] = spawnarea.min.y;
        y[1] = spawnarea.max.y;
        z[0] = spawnarea.min.z;
        z[1] = spawnarea.max.z;
    }

    // Update is called once per frame
    void Update()
    {
        spawnrate += Time.deltaTime;
        if (spawnrate > 3f && currentplants < maxplants)
        {
            Vector3 spawnpos = new Vector3(Random.Range(x[0], x[1]), Random.Range(y[0], y[1]), Random.Range(z[0], z[1]));
            GameObject plant = Instantiate(plantproto, spawnpos, Quaternion.identity);
            spawnrate = 0f;

            currentplants++;
        }
    }
}
