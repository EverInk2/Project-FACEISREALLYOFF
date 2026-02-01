using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;


public class Cam_Player_Movement : MonoBehaviour
{
    private Movement controller;
    public GameObject thegrid;
    private Vector3 targetPos;
    public int gridX;
    int gridY;
    GameObject[,] gridSlot;
    private bool moving;
    private GameObject tile;
    

    private int[] directions;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thegrid = GameObject.FindGameObjectWithTag("GridControl");
        controller = GetComponent<Movement>();
        targetPos = transform.position;
        gridY = (int)transform.position.y;
        gridX = (int)transform.position.x;
        moving = true;
        tile = thegrid.GetComponent<CostumeGrid>().grid[gridX, gridY];
        
    }

    public void Move(int[] directions)
    {
      
            
            //directions = controller.GetDirections();
            if (directions[0] != 0 || directions[1] != 0)
            {
                if (OpenSpace(directions))
                {

                   
                    targetPos = new Vector3(transform.position.x + directions[0], transform.position.y + directions[1], transform.position.z);
                    moving=true;
                    
                }
                else
                {
                 
                    targetPos = new Vector3(gridX,gridY, transform.position.z);
               
                }
            }

            gridX += directions[0];
            gridY += directions[1];
            tile = thegrid.GetComponent<CostumeGrid>().grid[gridX, gridY];

    }


    // Update is called once per frame
    void Update()
    {
        if (moving)
        transform.position = Vector3.Lerp(transform.position, targetPos, 5f * Time.deltaTime);
    }

    private bool OpenSpace(int[] directions)
    {


        GameObject gridSpot = thegrid.GetComponent<CostumeGrid>().grid[(int)tile.GetComponent<TileScript>().xAxis + directions[0], (int)tile.GetComponent<TileScript>().yAxis + directions[1]];
       
        if ((gridSpot.GetComponent<TileScript>().contains.tag.Equals( "Enemy"))||gridSpot.GetComponent<TileScript>().contains.tag.Equals("obstacle"))
        {
            moving = false;
            targetPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            return false;
            
        }
        return true;
        
    }
}
