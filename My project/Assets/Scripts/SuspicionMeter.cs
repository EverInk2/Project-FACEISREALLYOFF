using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System.Collections;


public class SuspicionMeter : MonoBehaviour
{
    public UnityEngine.UI.Image SuspicionBar;

    public int suspicion;
    public float timeSpent;
    public float suspicionInterval = 30f;
     
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SuspicionBar.fillAmount = 0;
        timeSpent = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeSpent += Time.deltaTime;
        while (timeSpent >= suspicionInterval)
        {
            IncreaseSuspicion(5);
            timeSpent -= suspicionInterval;
        }
    }

    public void IncreaseSuspicion(int amount)
    {
        SuspicionBar.fillAmount += (float)amount / 100;
        suspicion += amount;
    } 
}
