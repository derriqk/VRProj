using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    public GameObject cam;

    public Vector3 spawnPoint;
    float minY = -5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnPoint = new Vector3(1378, 21.5f, 1194);
    }

    // Update is called once per frame
    void Update()
    {
        if (cam.transform.position.y < minY)
        {
            transform.position = spawnPoint + Vector3.up * .2f;
        }
    }

    // called when both collide
}
