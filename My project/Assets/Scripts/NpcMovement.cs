using UnityEngine;
using Unity;


public class NpcMovement : MonoBehaviour
{
    private int[] directions;
    private Vector3 targetPos;
    private Movement controller;
    public GameObject patrol;
    public Vector2 patrolPos;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetPos = transform.position;
        GetPos();
        
    }

    public void Move()
    {
        if (patrolPos.x > transform.position.x+1)
        {
            directions = new int[] { 1, 0 };
        }
        else if (patrolPos.x < transform.position.x-1)
        {
            directions = new int[] { -1, 0 };
        }
        else if (patrolPos.y > transform.position.y+1)
        {
            directions = new int[] { 0, 1 };
        }
        else if (patrolPos.y < transform.position.y-1)
        {
            directions = new int[] { 0, -1 };
        }
        else
        {
            directions = new int[] { 0, 0 };
            GetPos();
        }
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

    private void GetPos()
    {
      /*  foreach (GameObject child in patrol)
        {
            Vector3 patrolPos = point.position;
        } */

        Transform[] pos = patrol.GetComponentsInChildren<Transform>();
        Debug.Log(pos.Length);
        int x =Random.Range(1, pos.Length);
        Debug.Log(x);
        patrolPos = pos[x].position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.tag = "player";
    }
}
