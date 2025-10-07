using UnityEngine;
using Oculus.Interaction;
using System.Collections;

public class GrabHerbBehavior : MonoBehaviour
{
    public GameObject herb;
    public Grabbable grabScript;

    public PlantSpawner spawnerScript;

    private bool touched = false; // initially not touched

    private Vector3 ogLocation;
    public GameObject inv;
    public InventoryScript invScript;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ogLocation = herb.transform.position;
        invScript = inv.GetComponent<InventoryScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (grabScript.GrabPoints.Count > 0 && !touched) // this means it is being held at the moment
        {
            OnGrab();
        }

        if (grabScript.GrabPoints.Count == 0 && touched)
        {
            OnRelease();
        }

        touched = grabScript.GrabPoints.Count > 0;
    }

    public void OnGrab()
    {
        Renderer render = herb.GetComponent<Renderer>();

        render.material.color = Color.red;
    }

    public void OnRelease()
    {
        Renderer render = herb.GetComponent<Renderer>();

        render.material.color = Color.green;

        if (invScript.currentitemCount < 2)
        {
            GameObject herbcopy = herb;
            invScript.inv[invScript.currentitemCount] = herb;
        }

        StartCoroutine(resetpos(1f));
    }

    private IEnumerator resetpos(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(herb);
        spawnerScript.currentplants--;
    }

}
