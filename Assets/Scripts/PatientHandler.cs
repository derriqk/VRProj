using UnityEngine;

public class PatientHandler : MonoBehaviour
{
    public GameObject patient;
    public GameObject patientSpawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        patientSpawn.GetComponent<Renderer>().enabled = false;
        GameObject obj = Instantiate(patient, patientSpawn.transform.position, Quaternion.identity);
        obj.transform.rotation = patientSpawn.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
