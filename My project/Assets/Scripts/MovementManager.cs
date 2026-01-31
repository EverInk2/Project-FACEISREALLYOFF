using System.Runtime.CompilerServices;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //private direction list to del wil player and npc movment
    private int[] directions;

    //timers to control movement intervols
    public float movetimer = 0.5f;
    private float currentTime = 0f;
    public GameObject player;
    public GameObject npc;

    bool xcollisionstrong = false;
    bool ycollisionstrong = false;

    //
    public float moveSpeed = 5f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        directions = new int[2];
        
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collided");
    }

    /*private Collision2D OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("still colliding");
        //ContactPoint2D[] fContacts = new ContactPoint2D[1];
        //int Array1Length = collision.GetContacts(fContacts);
        //print("GetContacts Size 1: " + fContacts[0].point + "Array Length: " + Array1Length);

        if(collision.transform.tag == "obstacle")
        {
            Debug.Log("colliding with obstacle");
            Debug.Log("pointsColliding: " + collision);
        }

        return 
    }*/


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colliding");
        if (collision.transform.tag == "obstacle")
        {
            Debug.Log("colliding with obstacle");
            foreach (ContactPoint2D contactPoint in collision.contacts)
            {
                Vector2 hitpoint = contactPoint.point;
                Debug.Log(hitpoint);
                if (Mathf.Abs(hitpoint.x) > Mathf.Abs(hitpoint.y))
                {
                    Debug.Log("collision normal has strong horizontal componenet" + Mathf.Sign(hitpoint.x));
                    xcollisionstrong = true;
                    
                }
                else
                {
                    xcollisionstrong = false;
                }

                if (Mathf.Abs(hitpoint.x) < Mathf.Abs(hitpoint.y))
                {
                    Debug.Log("collision normal has strong vertical componenet");
                    ycollisionstrong = true;
                }
                else
                {
                    ycollisionstrong = false;
                }

            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("stopped collding");
        foreach (ContactPoint2D contactPoint in collision.contacts)
        {
            Vector2 hitpoint = contactPoint.point;
            Debug.Log(hitpoint);
            if (Mathf.Abs(hitpoint.x) > Mathf.Abs(hitpoint.y))
            {
                Debug.Log("collision normal has strong horizontal componenet");
                xcollisionstrong = true;
                
            }
            else
            {
                xcollisionstrong = false;
            }

            if (Mathf.Abs(hitpoint.x) < Mathf.Abs(hitpoint.y))
            {
                Debug.Log("collision normal has strong vertical componenet");
                ycollisionstrong = true;
            }
            else
            {
                ycollisionstrong = false;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") > 0 && currentTime >= movetimer)
        {
            directions[0] = 1;
            currentTime = 0f;
            player.GetComponent<PlayerMovement>().Move();  
        }
        else if(Input.GetAxis("Vertical") > 0 && currentTime >= movetimer)
        {
            directions[1] = 1;
            currentTime = 0f;
            player.GetComponent<PlayerMovement>().Move();  
        }
        else if(Input.GetAxis("Horizontal") < 0 && currentTime >= movetimer)
        {
            directions[0] = -1;
            currentTime = 0f;
            player.GetComponent<PlayerMovement>().Move();  
        }
        else if(Input.GetAxis("Vertical") < 0 && currentTime >= movetimer)
        {
            directions[1] = -1;
            currentTime = 0f;
            player.GetComponent<PlayerMovement>().Move();  
        }
        else
        {
            directions[0] = 0;
            directions[1] = 0;
            currentTime += Time.deltaTime;
        }
        
    }

    /// <summary>
    /// returns the values for the directional movement
    /// </summary>
    /// <returns></returns>
    public int[] GetDirections()
    {
        return directions;
    }
}
