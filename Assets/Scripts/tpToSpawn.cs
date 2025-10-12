using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    public GameObject cam;

    public Vector3 spawnPoint;
    public GameObject cubeSpawn;
    float minY = -5f;
    float maxZ = 28f;
    float minZ = 8f;

    float maxX = 40f;
    float minX = 20f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnPoint = cubeSpawn.transform.position;
        cubeSpawn.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (cam.transform.position.y < minY ||
            cam.transform.position.z > maxZ || cam.transform.position.z < minZ ||
            cam.transform.position.x > maxX || cam.transform.position.x < minX
        )
        {
            transform.position = spawnPoint + Vector3.up * .2f;
        }
    }

    // called when both collide
}
