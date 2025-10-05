using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    public GameObject cam;

    public Vector3 spawnPoint;
    float minY = -5f;
    float maxZ = 1414f;
    float minZ = 991f;

    float maxX = 1577f;
    float minX = 1170f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnPoint = new Vector3(1378, 21.5f, 1194);
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
