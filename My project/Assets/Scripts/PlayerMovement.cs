using System;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Movement controller;

    private Vector3 targetPos;
    private Vector3 endPos;

    private int[] directions;

    //private Physics2D collideer;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //collideer = GetComponent<Physics2D>();
        controller = GetComponent<Movement>();
        targetPos = transform.position;
        
    }

    public Vector3 Move()
    { 
        directions = controller.GetDirections();


        targetPos = transform.position;
        endPos = targetPos + new Vector3(directions[0], directions[1], 0);
        endPos.x = Mathf.Round(endPos.x);
        endPos.y = Mathf.Round(endPos.y);

        Debug.Log("endpos x: " + endPos.x + " endpos y: " + endPos.y);
        //transform.position = Vector3.Lerp(targetPos, endPos, 5f * Time.deltaTime);
        transform.position = endPos;
        //if (directions[0] != 0 || directions[1] != 0)
        //{

        //    targetPos = new Vector3(transform.position.x + directions[0], transform.position.y + directions[1], transform.position.z);
        //}
        return endPos;
    }

    public void OnCollisionStay(Collision collision)
    {
        transform.position = endPos;
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        transform.position = endPos;
    }

    // Update is called once per frame
    void Update()
    {


        directions = controller.GetDirections();
        endPos.x = Mathf.Round(endPos.x);
        endPos.y = Mathf.Round(endPos.y);
        //aatransform.position = endPos;
        //transform.position += new Vector3(directions[0], directions[1], 0);

    }
    /*
    private void CheckCollision()
    {
        collideer.OverlapBox();
    }
    */
}
