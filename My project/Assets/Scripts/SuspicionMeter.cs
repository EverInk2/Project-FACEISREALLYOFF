using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class SuspicionMeter : MonoBehaviour
{
    public UnityEngine.UI.Image SuspicionBar;

    public int suspicion;
     
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SuspicionBar.fillAmount = suspicion / 100;

        while (Input.GetMouseButtonDown(0))
        {
            suspicion += 1;
        }
    }
}
