using UnityEngine;
using UnityEngine.UI;

public class RaiseSuspicion : MonoBehaviour
{
    //Variable block

    //fields
    private Image SuspicionMeter; // links directly to our SuspicionMeter UI

    private float increaseAmount = 0.1f;
    private float decreaseSuspicion;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SuspicionMeter.fillAmount = 0.025f;
    }

    // Update is called once per frame
    void Update()
    {
        //test to see if fill works
        while (Input.GetMouseButtonDown(0) == true)
        {
            IncreaseSuspicion(1);
        }
    }

    void IncreaseSuspicion(int amount)
    {
        for (int i = 0; i > amount; i++)
        {
            SuspicionMeter.fillAmount += increaseAmount;

        }
    }
}
