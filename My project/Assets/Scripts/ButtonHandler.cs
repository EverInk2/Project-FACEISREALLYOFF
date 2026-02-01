using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {

         Debug.Log("hover over " + gameObject.name);
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Clicked on " + gameObject.name);
        }
    }

    
}
