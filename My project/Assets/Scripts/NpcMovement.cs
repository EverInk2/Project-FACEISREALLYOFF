using UnityEngine;
using Unity;
using System.Runtime.CompilerServices;
using System.IO;
using NUnit.Framework;
using System.Collections.Generic;



public class NpcMovement : MonoBehaviour
{
    private int[] directions;
    private Vector2 lastPos;
    private Vector3 targetPos;
    private Movement controller;
    public GameObject patrol;
    public Vector2 patrolPos;
    private bool tileOpen;
    private List<int[]> path;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetPos = transform.position;
        lastPos = transform.position;
        tileOpen = true;
        GetPos();
        List<int[]> path = new List<int[]>();
    }

    public void Move()
    {
        if (tileOpen) 
        { 
            if (Mathf.Abs(patrolPos.x - transform.position.x) >= Mathf.Abs(patrolPos.y - transform.position.y))
            {
                if (patrolPos.x > transform.position.x + 0.5)
                {
                    directions = new int[] { 1, 0 };
                }
                else if (patrolPos.x < transform.position.x - 0.5)
                {
                    directions = new int[] { -1, 0 };
                }
                else
                {
                    directions = new int[] { 0, 0 };
                    GetPos();
                }
            }
            else
            {
                if (patrolPos.y > transform.position.y + 0.5)
                {
                    directions = new int[] { 0, 1 };
                }
                else if (patrolPos.y < transform.position.y - 0.5)
                {
                    directions = new int[] { 0, -1 };
                }
                else
                {
                    directions = new int[] { 0, 0 };
                    GetPos();
                }
            }

        } else
        {
            
                if (patrolPos.x > transform.position.x + 0.5 )
                {
                    directions = new int[] { 1, 0 };
                }
                else if (patrolPos.x < transform.position.x - 0.5)
                {
                    directions = new int[] { -1, 0 };
                }
                else if (patrolPos.y > transform.position.y + 0.5)
                {
                    directions = new int[] { 0, 1 };
                }
                else if (patrolPos.y < transform.position.y - 0.5)
                {
                    directions = new int[] { 0, -1 };
                }
                else
                {
                    directions = new int[] { 0, 0 };
                    GetPos();
                }
                
            
        }


        if (tileOpen)
        {
            if ((directions[0] != 0 || directions[1] != 0))
            {

                targetPos = new Vector3(transform.position.x + directions[0], transform.position.y + directions[1], transform.position.z);
            }
        }
        else
        {


        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPos, 5f * Time.deltaTime);
        lastPos = transform.position;

    }

    private void GetPos()
    {
      /*  foreach (GameObject child in patrol)
        {
            Vector3 patrolPos = point.position;
        } */

        Transform[] pos = patrol.GetComponentsInChildren<Transform>();
        int x =Random.Range(1, pos.Length);
        Debug.Log(x);
        patrolPos = pos[x].position;
    }

    private void MakePath()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Collided");
            tileOpen = false;
            targetPos = lastPos;
        }

    }

    void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Collided");
            tileOpen = false;
        }

    }

    

}
