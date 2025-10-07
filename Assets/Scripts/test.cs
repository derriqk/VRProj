using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject camera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = camera.transform.position + camera.transform.forward * 1f + camera.transform.right * -0.9f + camera.transform.up * -.2f;
        transform.rotation = camera.transform.rotation;
    }
    
}
