using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public enum masks 
{
    JOHNNY,
    angry,
    security,

}
public class maskyoink : MonoBehaviour
{
    SuspicionMeter meter;
    masks mask = masks.JOHNNY;
    GameObject player; 
    GameObject[] npcs;
    GameObject npc;
    float yoinkCD = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        meter = new SuspicionMeter();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            AssumeIdentity();   

        }
        yoinkCD -= Time.deltaTime;
    }

    private void OnGUI()
    {
        
    }

    

    internal void AssumeIdentity()
    {
        //if its on cd don't do the rest of the code
        if (yoinkCD > 0)
        {
            Debug.Log("on CD");
            return;
        }

        //loop through and find closest enemy
        float prox = int.MaxValue;
        npcs = GameObject.FindGameObjectsWithTag("npc");
        foreach (GameObject npc in npcs)
        {
            if(Vector3.Distance(npc.transform.position, player.transform.position) < prox)
            {
                prox = Vector3.Distance(npc.transform.position, player.transform.position);
                this.npc = npc;
            }
        }

        // if the distance is too big fuck the rest of ts
        if (prox > 1.5)
        {
            Debug.Log("too far");
            return;
        }

        //redo CD
        yoinkCD = 5;
        //Debug.Log("activated");


        //kirby transform
        player.GetComponent<SpriteRenderer>().sprite = npc.GetComponent<SpriteRenderer>().sprite;
        if(player.GetComponent<SpriteRenderer>().color != null)
        {
            player.GetComponent<SpriteRenderer>().color = npc.GetComponent<SpriteRenderer>().color;
        }

        

        
        //assign mask enum to johnny
        string look = player.GetComponent<SpriteRenderer>().sprite.ToString().ToLower().Trim();
        string[] looks = look.Split(" ");
        look = looks[0];
        Debug.Log("look is: "+ look);

        switch (look) //passes in "circle" MAKE SURE TO CHANGE WHEN WE GET THE SCRIPTS ON
        {
            case "circle":
                mask = masks.angry;
                break;
            case "angry":
                break;
            case "security":
                break;
            default:
                mask = masks.JOHNNY;
                break;
        }

        Debug.Log("mask is: " + mask);
        //switch (look)
        //{
        //    case 
        //        break;
        //}
        //kill enemy
        //doesn't work because enemyEliminated calls for an object, not a gameobject

        meter.EnemyEliminated(npc);
    }
}
