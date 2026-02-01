using UnityEngine;

public class TileScript : MonoBehaviour
{
    public float xAxis;
    public float yAxis;
    public GameObject contains;
    private GameObject GridC;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        contains = GameObject.FindGameObjectWithTag("floor");

        GridC = GameObject.FindGameObjectWithTag("GridControl");
        GameObject player = GridC.GetComponent<CostumeGrid>().player;
        xAxis = transform.position.x; 
        yAxis = transform.position.y;
        if (gameObject.GetComponent<Collider2D>().IsTouching(player.GetComponent<Collider2D>()))
        {
            contains = GameObject.FindGameObjectWithTag("Player");
        }
        else if (TestObject(GridC.GetComponent<CostumeGrid>().nPCcolliders))
        {
            contains = GameObject.FindGameObjectWithTag("Enemy");
        }
        else if (TestObject(GridC.GetComponent<CostumeGrid>().wallcolliders))
        {
            contains = GameObject.FindGameObjectWithTag("obstacle");
        }
        else
        {
            contains = GameObject.FindGameObjectWithTag("floor");
        }
        

            

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool TestObject(Collider2D[] Co) 
    {
        if (Co != null)
        {
            foreach (Collider2D c in Co)
                if (gameObject.GetComponent<Collider2D>().IsTouching(c))
                {
                    return true;
                }
        }
        return false;
    }
    
}
