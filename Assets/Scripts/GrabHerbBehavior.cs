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
    public int currentSlot;
    private bool collided = false;

    public GameObject combine;
    public Combine combScript;
    private bool combining = false;
    public int currentCombineSlot;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        combine = GameObject.FindWithTag("combine");
        inv = GameObject.FindWithTag("inventory");
        if (inv != null)
        {
            invScript = inv.GetComponent<InventoryScript>();
        }
        if (combine != null)
        {
            combScript = combine.GetComponent<Combine>();
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
        if (isInInv && !beingTouched && !combining)
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
            invScript.redZone.SetActive(true); // this should show up while being held
            invScript.combineZone.GetComponent<Renderer>().enabled = true; // show up
        }

    }

    public void OnRelease()
    {
        Renderer render = herb.GetComponent<Renderer>();
        invScript.redZone.SetActive(false);
        invScript.combineZone.GetComponent<Renderer>().enabled = false; 
        if (!isInInv && !collided)
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
                    currentSlot = 1;
                }
                else if (!invScript.slot2Taken)
                {
                    invScript.slot2Taken = true;
                    toFollow = invScript.slot2;
                    currentSlot = 2;
                }

                spawnerScript.currentplants--;
            }
            else
            {
                spawnerScript.currentplants--;
                StartCoroutine(resetpos(1f));
            }
        }
        else
        {
            beingTouched = false; // released to allow followCam()
            if (isInInv && !combining)
            {
                render.material.color = Color.pink;
            }

        }
    }

    private IEnumerator resetpos(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(herb);
    }

    public void followCam()
    {
        transform.position = toFollow.transform.position;
        transform.rotation = toFollow.transform.rotation;
    }

    void OnTriggerEnter(Collider other)
    {
        // handle delete
        if (isInInv && other.CompareTag("redzone"))
        {
            collided = true;
            Renderer render = herb.GetComponent<Renderer>();
            render.material.color = Color.black;
            invScript.currentitemCount--;
            isInInv = false;
            // free up space
            if (currentSlot == 1)
            {
                invScript.slot1Taken = false;
            }
            else
            {
                invScript.slot2Taken = false;
            }
            StartCoroutine(resetpos(1f));
        }
        // handle combine
        if (isInInv && other.CompareTag("combine"))
        {
            combining = true;
            // handle logic
            Renderer render = herb.GetComponent<Renderer>();

            if (!combScript.item1Taken)
            {
                combScript.item1Taken = true;
                currentCombineSlot = 1;
                combScript.item1 = herb;
                render.material.color = Color.yellow;
            }
            else
            {
                combScript.item2Taken = true;
                currentCombineSlot = 2;
                combScript.item2 = herb;
                render.material.color = Color.teal;
            }


        }
    }

    void OnTriggerExit(Collider other)
    {
        // if the item leaves the combine zone
        if (other.CompareTag("combine"))
        {
            combining = false;
            if (currentCombineSlot == 1)
            {
                combScript.item1Taken = false;
                currentCombineSlot = 0;
                combScript.item1 = null;
            }
            else if (currentCombineSlot == 2)
            {
                combScript.item2Taken = false;
                currentCombineSlot = 0;
                combScript.item2 = null;
            }
        }   
    }

}
