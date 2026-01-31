using System.Runtime.CompilerServices;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //private direction list to del wil player and npc movment
    private int[] directions;

    //timers to control movement intervols
    public float movetimer = 0.5f;
    private float currentTime = 0f;
    public GameObject player;
    public GameObject npc_Manager; 
    private NpcMovement[] npcs;

    //
    public float moveSpeed = 5f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        directions = new int[2];
        npcs = npc_Manager.GetComponentsInChildren<NpcMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") > 0 && currentTime >= movetimer)
        {
            
            directions[0] = 1;
            currentTime = 0f;
            player.GetComponent<PlayerMovement>().Move();
            for (int i = 0; i < npc_Manager.transform.childCount; i++)
            {
                npcs[i].GetComponent<NpcMovement>().Move();
            }

        }
        else if(Input.GetAxis("Vertical") > 0 && currentTime >= movetimer)
        {
            directions[1] = 1;
            currentTime = 0f;
            player.GetComponent<PlayerMovement>().Move();
            for (int i = 0; i < npc_Manager.transform.childCount ; i++)
            {
                npcs[i].GetComponent<NpcMovement>().Move();
            }
        }
        else if(Input.GetAxis("Horizontal") < 0 && currentTime >= movetimer)
        {
            directions[0] = -1;
            currentTime = 0f;
            player.GetComponent<PlayerMovement>().Move();
            for (int i = 0; i < npc_Manager.transform.childCount; i++)
            {
                npcs[i].GetComponent<NpcMovement>().Move();
            }
        }
        else if(Input.GetAxis("Vertical") < 0 && currentTime >= movetimer)
        {
            directions[1] = -1;
            currentTime = 0f;
            player.GetComponent<PlayerMovement>().Move();
            for (int i = 0; i < npc_Manager.transform.childCount; i++)
            {
                npcs[i].GetComponent<NpcMovement>().Move();
            }
        }
        else
        {
            directions[0] = 0;
            directions[1] = 0;
            currentTime += Time.deltaTime;
        }
        
    }

    /// <summary>
    /// returns the values for the directional movement
    /// </summary>
    /// <returns></returns>
    public int[] GetDirections()
    {
        return directions;
    }
}
