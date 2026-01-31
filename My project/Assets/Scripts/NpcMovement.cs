using UnityEngine;

public class NpcMovement : MonoBehaviour
{
    private int[] directions;
    private Vector3 targetPos;
    private Movement controller;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetPos = transform.position;
    }

    public void Move()
    {
        if(directions[0] != 0 || directions[1] != 0)
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
