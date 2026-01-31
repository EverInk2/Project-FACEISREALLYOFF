using System.Collections.Generic;
using UnityEngine;

public class PathFindingScript : MonoBehaviour
{
    private List<int[]> path;
    private int[] directions;
    private Vector2 lastPos;
    private Vector3 targetPos;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private List<int[]> FindPath(Vector2 startPos, Vector2 targetPos)
    //{
    //    transform.position = startPos;
    //    while (Mathf.Abs(targetPos.x - transform.position.x) < 0.8 && Mathf.Abs(targetPos.y - transform.position.y) < 0.8)
    //    {
    //        if (Mathf.Abs(targetPos.x - transform.position.x) >= Mathf.Abs(targetPos.y - transform.position.y))
    //        {
    //            if (targetPos.x > transform.position.x + 0.5)
    //            {
    //                directions = new int[] { 1, 0 };
    //                path.Add(directions);
    //            }
    //            else if (targetPos.x < transform.position.x - 0.5)
    //            {
    //                directions = new int[] { -1, 0 };
    //                path.Add(directions);
    //            }
    //            else
    //            {
    //                directions = new int[] { 0, 0 };
    //                return path;
    //            }
    //        }
    //        else
    //        {
    //            if (targetPos.y > transform.position.y + 0.5)
    //            {
    //                directions = new int[] { 0, 1 };
    //                path.Add(directions);
    //            }
    //            else if (targetPos.y < transform.position.y - 0.5)
    //            {
    //                directions = new int[] { 0, -1 };
    //                path.Add(directions);
    //            }
    //            else
    //            {
    //                directions = new int[] { 0, 0 };
    //                return path;
    //            }
    //        }
    //    }
    //}
}
