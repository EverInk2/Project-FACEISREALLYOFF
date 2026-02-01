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
    public List<int[]> path;
    public GameObject pathfinder;
    private int stepIndex = 0; 



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetPos = transform.position;
        lastPos = transform.position;
        tileOpen = true;
        GetPos();
        path = gameObject.GetComponentInChildren<PathFindingScript>().FindPath(transform.position, patrolPos);

    }

    public void Move()
    {
      
        if (stepIndex < path.Count)
        {

            targetPos = new Vector3(transform.position.x + (path[stepIndex])[0], transform.position.y + (path[stepIndex])[1], transform.position.z);
            stepIndex++;
            if (!tileOpen)
            {
                if (((path[stepIndex])[0] !=0 || (path[stepIndex])[1] != 0))
                {
                    targetPos = lastPos;

                    stepIndex--;
                    
                    tileOpen = true;
                }
            }
        }
        else
        {
            GetPos();
            path = gameObject.GetComponentInChildren<PathFindingScript>().FindPath(transform.position, patrolPos);
            stepIndex = 0;
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
