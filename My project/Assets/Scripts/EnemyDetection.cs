using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    private float detectionRadius = 3f;
    private float FOVAngle = 90f;
    private Transform player;
    public bool playerDetected;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 directionToPlayer = (player.position - transform.position).normalized;
            float distanceToPlayer = Vector3.Distance(transform.position, directionToPlayer);
            
            if (distanceToPlayer < detectionRadius)
            {
                //Dot products were in fact relevent to my field
                float dotProduct = Vector3.Dot(transform.position, directionToPlayer);
                float angleThreshold = Mathf.Cos(FOVAngle * Mathf.Deg2Rad);

                if (dotProduct >= angleThreshold)
                {
                    //using raycasting for a line of sight here
                    if (!Physics.Raycast(transform.position, directionToPlayer, 
                                        distanceToPlayer, LayerMask.GetMask("Obstacle")))
                    {
                        Debug.Log("Player detected");
                        playerDetected = true;
                    }
                    else
                    {
                        playerDetected = false;
                    }
                }
            }
        }
    }
}
