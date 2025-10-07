using UnityEngine;
using Oculus.Interaction;
using System.Collections;

public class GrabHerbBehavior : MonoBehaviour
{
    public GameObject herb;
    public Grabbable grabScript;

    public PlantSpawner spawnerScript;

    private bool touched = false; // initially not touched

    public GameObject inv;
    public InventoryScript invScript;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
            render.material.color = Color.pink; // to visually debug the backend
            // this means while testing, at most you should only see 2 pink cubes since i havent made the delete from inv yet

            invScript.inv[invScript.currentitemCount] = Instantiate(herb);
            invScript.currentitemCount++;
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
