using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System.Collections;


public class SuspicionMeter : MonoBehaviour
{
    internal UnityEngine.UI.Image SuspicionBar;

    internal int suspicion;
    internal float timeSpent;
    internal float suspicionInterval = 30f;
     
    //publicly accessible property
    public int Suspicion
    {
        get { return suspicion; } set { suspicion = value; }
    }
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

    internal void IncreaseSuspicion(int amount)
    {
        SuspicionBar.fillAmount += (float)amount / 100;
        suspicion += amount;
    } 
}
