using UnityEngine;
using System.Collections;

public class PatientBehavior : MonoBehaviour
{
    public GameObject patient;
    public int targetVal;

    public int sum;
    private int sign;
    public Color[] colors = new Color[6];

    public Color ogColor;

    // audio related things
    public GameObject soundHolder;
    public SoundHandlerScript soundScript;

    public GameObject patientHandler;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        soundHolder = GameObject.FindWithTag("soundhandler");
        if (soundHolder != null)
        {
            soundScript = soundHolder.GetComponent<SoundHandlerScript>();
        }
        patientHandler = GameObject.FindWithTag("patienthandler");
        sum = 0;
        sign = Random.Range(0, 2);
        if (sign > 0)
        {
            targetVal = Random.Range(15, 31);
        }
        else
        {
            targetVal = Random.Range(-30, -14);
        }

        colors[0] = new Color(1f, 0f, 0f);
        colors[1] = new Color(1f, 0.5f, 0f);
        colors[2] = new Color(1f, 1f, 0f); 
        colors[3] = new Color(0.5f, 0.6f, 0.3f);
        colors[4] = new Color(0f, 0.3f, 0f);
        colors[5] = new Color(0f, 1f, 0f);

        ogColor = patient.GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void resetPatient()
    {
        sum = 0;
        Renderer rend = patient.GetComponent<Renderer>();
        rend.material.color = ogColor;
    }

    public void changeColor(int i) // this will change the color of the patient based on the initValues of cubes fed
    {
        sum += i;
        Renderer rend = patient.GetComponent<Renderer>();
        bool correct = false;
        if (sum < targetVal + 3 && sum > targetVal - 3)
        {
            rend.material.color = colors[5];
            // redo patient

            if (patientHandler != null)
            {
                correct = true;
                patientHandler.GetComponent<PatientHandler>().createNewPatient();
                StartCoroutine(waitAndDestroy(1f));
            }
        }
        else if (sum < targetVal + 6 && sum > targetVal - 6)
        {
            rend.material.color = colors[4];
        }
        else if (sum < targetVal + 9 && sum > targetVal - 9)
        {
            rend.material.color = colors[3];
        }
        else if (sum < targetVal + 12 && sum > targetVal - 12)
        {
            rend.material.color = colors[2];
        }
        else if (sum < targetVal + 15 && sum > targetVal - 15)
        {
            rend.material.color = colors[1];
        }
        else
        {
            rend.material.color = colors[0];
        }

        if (correct)
        {
            soundScript.PlayCorrectSound();
        }
        else
        {
            soundScript.PlayWrongSound();
        }
        
        if (sum > targetVal + 50 || sum < targetVal - 50)
        {
            // too far so patient will die
            rend.material.color = Color.black;

            if (patientHandler != null)
            {
                patientHandler.GetComponent<PatientHandler>().createNewPatient();
                StartCoroutine(waitAndDestroy(1f));
            }
        }
    }
    
    IEnumerator waitAndDestroy(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(patient);
    }
}
