using System.IO.IsolatedStorage;
using UnityEditor;
using UnityEditor.U2D.Sprites;
using UnityEngine;

public class CostumeGrid : MonoBehaviour
{
    public GameObject gridsquare;
    public int gridLength;
    public int gridWidth;
    public GameObject[,] grid;

    public GameObject walls;
    public Collider2D[] wallcolliders;
    public GameObject nPCs;
    public Collider2D[] nPCcolliders;
    public GameObject player;
    
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        grid = new GameObject[gridLength,gridLength];
        for (int i = 0; i< gridLength; i++)
        {
            for(int j = 0; j< gridWidth; j++)
            {
                grid[i,j] = Instantiate(gridsquare,new Vector2(i,j),gridsquare.transform.rotation);
                if ((i + j) % 2 == 0)
                {
                    grid[i, j].gameObject.GetComponent<SpriteRenderer>().color = new Color(0.9f,0.9f,0.9f,1);
                }

            }
        }

        if (wallcolliders != null)
        {
            wallcolliders = walls.GetComponentsInChildren<Collider2D>();
        }
        else
        {
            wallcolliders = null;
        }
        if (wallcolliders != null)
        {
            nPCcolliders = nPCs.GetComponentsInChildren<Collider2D>();
        }
        else
        {
            nPCs = null;
        }

        //grid[12, 14].transform.position = new Vector3(-1, -3,0);   
        
    }
}
