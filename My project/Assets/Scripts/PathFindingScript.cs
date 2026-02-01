using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PathFindingScript : MonoBehaviour
{
    private List<int[]> path;
    private int[] directions;
    private Vector2 lastPos;
    private Vector2 moving;
    private bool blocked;
    public GameObject walls;
    private Collider2D[] wallColliders;
    private RaycastHit2D[] results = new RaycastHit2D[3];
    int castCheck=0;
    ContactFilter2D contactFilter = new ContactFilter2D();
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        path = new List<int[]>();
        directions = new int[] { 0, 0 };
        blocked = false;
        transform.position = new Vector3(0, 0, 0);
        wallColliders = walls.GetComponentsInChildren<Collider2D>();
        
        //contactFilter.NoFilter();
        contactFilter = new ContactFilter2D();
        contactFilter.useTriggers = true;
        Debug.Log(contactFilter.isFiltering);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<int[]> FindPath(Vector2 startPos, Vector2 targetPos)
    {
        path = new List<int[]>();
        this.gameObject.transform.position = startPos;
        while (Mathf.Abs(targetPos.x - this.gameObject.transform.position.x) > 0.8 || Mathf.Abs(targetPos.y - this.gameObject.transform.position.y) > 0.8)
        {
            //Debug.Log ("got in the while loop");
            if (Mathf.Abs(targetPos.x - this.gameObject.transform.position.x) >= Mathf.Abs(targetPos.y - this.gameObject.transform.position.y))
            {
                //Debug.Log ("Going x direction");
                if (targetPos.x > this.gameObject.transform.position.x + 0.5)
                {
                    //Debug.Log("right");
                    directions[0] = 1;
                    directions[1] = 0;
                    path.Add(new int[] { 1, 0 });
                    
                }
                else if (targetPos.x < this.gameObject.transform.position.x - 0.5)
                {
                    //Debug.Log("left");
                    directions[0] = -1;
                    directions[1] = 0;
                    path.Add(new int[] { -1, 0 });
                    
                }
                else
                {
                    directions = new int[] { 0, 0 };
                    //Debug.Log("Good Ending 1");
                    return path;
                }
            }
            else
            {
                //Debug.Log ("Going y direction");
                if (targetPos.y > this.gameObject.transform.position.y + 0.5)
                {
                    directions[0] = 0;
                    directions[1] = 1;
                    path.Add(new int[] { 0, 1 });
                    //Debug.Log("up");
                }
                else if (targetPos.y < this.gameObject.transform.position.y - 0.5)
                {
                    directions[0] = 0;
                    directions[1] = -1;
                    path.Add(new int[] { 0, -1 });
                    //Debug.Log("down");
                }
                else
                {
                    directions[0] = 0;
                    directions[1] = 0; 
                    //Debug.Log("Good Ending 2");
                    return path;
                }
            }

            castCheck = gameObject.GetComponent<Collider2D>().Cast(new Vector2(directions[0], directions[1]),contactFilter, results, 1f, true);
            Debug.Log("castCheck: " + castCheck);
            for (int i = 0; i < castCheck; i++)
            {
                Debug.Log("Hit: " + results[i].collider.name);
            }

            lastPos = this.gameObject.transform.position;
            this.gameObject.transform.position = new Vector2(this.gameObject.transform.position.x + directions[0], this.gameObject.transform.position.y + directions[1]);
            

            //Debug.Log("Moved to: (" + this.gameObject.transform.position.x + ", " + this.gameObject.transform.position.y + ")");
            
            for (int i = 0; i < wallColliders.Length; i++)
            {
                if (this.gameObject.GetComponent<Collider2D>().IsTouching(wallColliders[i]))
                {
                    blocked = true;
                    Debug.Log("Blocked");
                    break;
                    
                }
                else
                {
                    blocked = false;
                    //Debug.Log("Not blocked");
                }
            }
             
               
            if (blocked)
            {
                this.gameObject.transform.position = lastPos;
                foreach (int[] d in SplitPath(this.gameObject.transform.position, targetPos, directions))
                {
                    path.Add(d);
                    this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + d[1], this.gameObject.transform.position.y + d[1], 0);
                    if (!blocked)
                    {
                        break;
                    }
                    
                }
            }
        }
        Debug.Log("why am I here");
        return path;
    }

    public List<int[]> SplitPath(Vector2 startPos, Vector2 targetPos, int[] direction)
    {
        Debug.Log("In SplitPath");
        List<int[]> listP = new List<int[]>();
        List<int[]> listN = new List<int[]>();
        int[] positiveD = new int[2];
        int[] negativeD = new int[2];
        int interval = 1;
        bool stuck = false;
        
        if (direction[0] != 0)
        {
            positiveD = new int[] { 1, 0 };
            negativeD = new int[] { -1, 0 };
            while (stuck)
            {
                if (startPos.x <= targetPos.x)
                {
                    this.gameObject.transform.position = new Vector3(startPos.x + interval, startPos.y, 0);
                    this.gameObject.transform.position = new Vector3(startPos.x, startPos.y + direction[1], 0);
                    listP.Add(new int[] { 1, 0 });
                    if (!blocked)
                    {
                        return listP;
                    }
                    this.gameObject.transform.position = new Vector3(startPos.x - interval, startPos.y, 0);
                    this.gameObject.transform.position = new Vector3(startPos.x, startPos.y + direction[1], 0);
                    listP.Add(new int[] { -1, 0 });
                    if (!blocked)
                    {
                        return listP;
                    }
                }
                else
                {
                    this.gameObject.transform.position = new Vector3(startPos.x - interval, startPos.y, 0);
                    this.gameObject.transform.position = new Vector3(startPos.x, startPos.y + direction[1], 0);
                    listN.Add(new int[] { -1, 0 });
                    if (!blocked)
                    {
                        return listN;
                    }
                    this.gameObject.transform.position = new Vector3(startPos.x + interval, startPos.y, 0);
                    this.gameObject.transform.position = new Vector3(startPos.x, startPos.y + direction[1], 0);
                    listP.Add(new int[] { 1, 0 });
                    if (!blocked)
                    {
                        return listP;
                    }
                    
                }

                

            }
        }
        else
        {
            //If the wall horizontal
            positiveD = new int[] { 0,  };
            negativeD = new int[] { -1, 0 };
            while (stuck)
            {
                if (startPos.y <= targetPos.y)
                {
                    this.gameObject.transform.position = new Vector3(startPos.x, startPos.y + interval, 0);
                    this.gameObject.transform.position = new Vector3(startPos.x + direction[1], startPos.y, 0);
                    listP.Add(new int[] {0 , 1 });
                    if (!blocked)
                    {
                        return listP;
                    }
                    this.gameObject.transform.position = new Vector3(startPos.x, startPos.y - interval, 0);
                    this.gameObject.transform.position = new Vector3(startPos.x + direction[1], startPos.y, 0);
                    listN.Add(new int[] { 0, 1 });
                    if (!blocked)
                    {
                        return listN;
                    }
                }
                else
                {
                    this.gameObject.transform.position = new Vector3(startPos.x, startPos.y - interval, 0);
                    this.gameObject.transform.position = new Vector3(startPos.x + direction[1], startPos.y, 0);
                    listN.Add(new int[] { 0, -1 });
                    if (!blocked)
                    {
                        return listN;
                    }
                    this.gameObject.transform.position = new Vector3(startPos.x, startPos.y + interval, 0);
                    this.gameObject.transform.position = new Vector3(startPos.x + direction[1], startPos.y, 0);
                    listP.Add(new int[] {0, 1 });
                    if (!blocked)
                    {
                        return listP;
                    }

                }
            }
        }
        Debug.Log("returning JackAll");
        return null;
    }


    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entered trigger");
        if (collision.gameObject.tag == "obstacle")
        {
            blocked = true;
            Debug.Log("Path is blocked");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Staying in trigger");
        if (collision.gameObject.tag == "obstacle")
        {
            blocked = true;
            Debug.Log("Path is blocked");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       blocked = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Entered trigger");
        if (collision.gameObject.tag == "obstacle")
        {
            blocked = true;
            Debug.Log("Path is blocked");
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Staying in trigger");
        if (collision.gameObject.tag == "obstacle")
        {
            blocked = true;
            Debug.Log("Path is blocked");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        blocked = false;
    }
}
