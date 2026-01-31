using NUnit.Framework;
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
    public GameObject npc_Manager; 
    private NpcMovement[] npcs;

    bool xstoppos = false;
    bool ystoppos = false;
    bool xstopneg = false;
    bool ystopneg = false;

    //
    public float moveSpeed = 5f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        directions = new int[2];
        npcs = npc_Manager.GetComponentsInChildren<NpcMovement>();

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
        
        Debug.Log("colliding with obstacle");
        foreach (ContactPoint2D contactPoint in collision.contacts)
        {
            Vector2 hitpoint = contactPoint.point;
            if(hitpoint.x < 0)
            {
                hitpoint.x = Mathf.Ceil(hitpoint.x);
            }
            else if(hitpoint.x > 0)
            {
                hitpoint.x = Mathf.Floor(hitpoint.x);
            }
            if (hitpoint.y < 0)
            {
                hitpoint.y = Mathf.Ceil(hitpoint.y);
            }
            else if (hitpoint.y > 0)
            {
                hitpoint.y = Mathf.Floor(hitpoint.y);
            }
            Debug.Log(hitpoint.x);
            Debug.Log(player.transform.position.x);
            if (Mathf.Abs(hitpoint.x) > Mathf.Abs(hitpoint.y))
            {

                Debug.Log("collision normal has strong horizontal componenet");
                if (hitpoint.x > player.transform.position.x)
                {
                    xstoppos = true;
                    
                    Debug.Log("xsp t");
                }
                else
                {
                    xstoppos = false;
                }
                if (hitpoint.x < player.transform.position.x)
                {

                    xstopneg = true;
                    Debug.Log("xsp f");
                }
                else
                {
                    xstopneg = false;
                }
            }


            if (Mathf.Abs(hitpoint.x) < Mathf.Abs(hitpoint.y))
            {
                Debug.Log("collision normal has strong vertical componenet");
                if (hitpoint.y > player.transform.position.y)
                {
                    ystoppos = true;
                    Debug.Log("ysp t");
                }
                else
                {
                    ystoppos = false;
                }


                if (hitpoint.y < player.transform.position.y)
                {
                    ystopneg = true;
                    Debug.Log("ysn t");
                }
                else
                {
                    ystopneg = false;
                }


            }

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
        Debug.Log("stopped collding");
        

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") > 0 && currentTime >= movetimer)
        {
            if(!xstoppos)
            {
                directions[0] = 1;
            }
            else
            {
                directions[0] = 0;
            }
            currentTime = 0f;
            player.GetComponent<PlayerMovement>().Move();
            for (int i = 0; i < npc_Manager.transform.childCount; i++)
            {
                npcs[i].GetComponent<NpcMovement>().Move();
            }

        }
        else if(Input.GetAxis("Vertical") > 0 && currentTime >= movetimer)
        {
            if (!ystoppos)
            {
                directions[1] = 1;
            }
            else
            {
                directions[1] = 0;
            }
            currentTime = 0f;
            player.GetComponent<PlayerMovement>().Move();
            for (int i = 0; i < npc_Manager.transform.childCount ; i++)
            {
                npcs[i].GetComponent<NpcMovement>().Move();
            }
        }
        else if(Input.GetAxis("Horizontal") < 0 && currentTime >= movetimer)
        {
            if (!xstopneg)
            {
                directions[0] = -1;
            }
            else
            {
                directions[0] = 0;
            }
            currentTime = 0f;
            player.GetComponent<PlayerMovement>().Move();
            for (int i = 0; i < npc_Manager.transform.childCount; i++)
            {
                npcs[i].GetComponent<NpcMovement>().Move();
            }
        }
        else if(Input.GetAxis("Vertical") < 0 && currentTime >= movetimer)
        {
            if (!ystopneg)
            {
                directions[1] = -1;
            }
            else
            {
                directions[1] = 0;
            }
            currentTime = 0f;
            player.GetComponent<PlayerMovement>().Move();
            for (int i = 0; i < npc_Manager.transform.childCount; i++)
            {
                npcs[i].GetComponent<NpcMovement>().Move();
            }
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
