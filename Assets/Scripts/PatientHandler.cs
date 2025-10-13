using UnityEngine;
using System.Collections;

public class PatientHandler : MonoBehaviour
{
    public GameObject patient;
    public GameObject patientSpawn;
    GameObject currentPatient;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        patientSpawn.GetComponent<Renderer>().enabled = false;
        currentPatient = Instantiate(patient, patientSpawn.transform.position, Quaternion.identity);
        currentPatient.transform.rotation = patientSpawn.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void createNewPatient()
    {
        StartCoroutine(waitAndSpawn(2f));
    }
    
    IEnumerator waitAndSpawn(float delay)
    {
        yield return new WaitForSeconds(delay);
        currentPatient = Instantiate(patient, patientSpawn.transform.position, Quaternion.identity);
        currentPatient.transform.rotation = patientSpawn.transform.rotation;
    }
}
