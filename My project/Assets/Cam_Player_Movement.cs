using System;
using Unity.Mathematics;
using UnityEngine;


public class Cam_Player_Movement : MonoBehaviour
{
    private Movement controller;

    private Vector3 targetPos;

    private int[] directions;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<Movement>();
        targetPos = transform.position;
    }

    public void Move(int[] directions)
    {
        //directions = controller.GetDirections();
        if (directions[0] != 0 || directions[1] != 0)
        {
            targetPos = new Vector3(transform.position.x + directions[0], transform.position.y + directions[1], transform.position.z);
        }
    }


    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPos, 5f * Time.deltaTime);
    }
}
