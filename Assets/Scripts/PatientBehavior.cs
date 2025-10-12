using UnityEngine;

public class PatientBehavior : MonoBehaviour
{
    public GameObject patient;
    public int targetVal;
    private int sign;
    public Color[] colors = new Color[10];
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sign = Random.Range(0, 2);
        if (sign > 0)
        {
            targetVal = Random.Range(15, 30);
        }
        else
        {
            targetVal = Random.Range(-30, -14);
        }

        for (int i = 0; i < 5; i++)
        {
            colors[i] = new Color(1.0f - (i * .2f), 0.0f, 0.0f);
            colors[i + 5] = new Color(0.0f, 0.2f + (i * .2f), 0.0f);
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void changeColor(int i) // this will change the color of the patient based on the initValues of cubes fed
    {
        Renderer rend = patient.GetComponent<Renderer>();
        if (i < targetVal + 2 && i > targetVal - 2)
        {
            rend.material.color = colors[9];
        }
        else if (i < targetVal + 4 && i > targetVal - 4)
        {
            rend.material.color = colors[8];
        }
        else if (i < targetVal + 6 && i > targetVal - 6)
        {
            rend.material.color = colors[7];
        }
        else if (i < targetVal + 8 && i > targetVal - 8)
        {
            rend.material.color = colors[6];
        }
        else if (i < targetVal + 10 && i > targetVal - 10)
        {
            rend.material.color = colors[5];
        }
        else if (i < targetVal + 12 && i > targetVal - 12)
        {
            rend.material.color = colors[4];
        }
        else if (i < targetVal + 14 && i > targetVal - 14)
        {
            rend.material.color = colors[3];
        }
        else if (i < targetVal + 16 && i > targetVal - 16)
        {
            rend.material.color = colors[2];
        }
        else if (i < targetVal + 18 && i > targetVal - 18)
        {
            rend.material.color = colors[1];
        }
        else
        {
            rend.material.color = colors[0];
        }
    }
}
