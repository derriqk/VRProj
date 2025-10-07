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

    public bool isInInv = false;
    public bool beingTouched = false;

    public GameObject toFollow;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inv = GameObject.FindWithTag("inventory");
        if (inv != null)
        {
            invScript = inv.GetComponent<InventoryScript>();
        }

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



        // behavior for while it is in inventory
        if (isInInv && !beingTouched)
        {
            followCam();
        }
    }

    public void OnGrab()
    {
        Renderer render = herb.GetComponent<Renderer>();

        if (!isInInv)
        {
            render.material.color = Color.red;
        }
        else
        {
            beingTouched = true;
            render.material.color = Color.purple;
        }

    }

    public void OnRelease()
    {
        Renderer render = herb.GetComponent<Renderer>();
        if (!isInInv)
        {
            render.material.color = Color.green;

            if (inv != null && invScript.currentitemCount < 2)
            {
                render.material.color = Color.pink; // to visually debug the backend
                // this means while testing, at most you should only see 2 pink cubes since i havent made the delete from inv yet
                isInInv = true;
                invScript.currentitemCount++;

                // invariant: if currentitemcount < 2,  slot must be available
                if (!invScript.slot1Taken)
                {
                    invScript.slot1Taken = true;
                    toFollow = invScript.slot1;
                }
                else if (!invScript.slot2Taken)
                {
                    invScript.slot2Taken = true;
                    toFollow = invScript.slot2;
                }

                spawnerScript.currentplants--;
            }
            else
            {
                StartCoroutine(resetpos(1f));
            }
        }
        else
        {
            beingTouched = false; // released so allow followCam()
            render.material.color = Color.pink;
        }
    }

    private IEnumerator resetpos(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(herb);
        spawnerScript.currentplants--;
    }

    public void followCam()
    {
        transform.position = toFollow.transform.position;
        transform.rotation = toFollow.transform.rotation;
    }

}
