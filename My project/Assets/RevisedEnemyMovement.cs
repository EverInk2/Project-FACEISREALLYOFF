using UnityEngine;

public class RevisedEnemyMovement : MonoBehaviour
{
    public Transform[] movementPoints;
    public float speed = 5f;
    private int movementPointIndex;
    EnemyDetection EnemyDetection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movementPointIndex = 0;
        transform.position = movementPoints[movementPointIndex].position;
        EnemyDetection = GetComponent<EnemyDetection>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movementPoints[movementPointIndex].position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movementPoints[movementPointIndex].position) < 0.1f)
        {
            movementPointIndex = (movementPointIndex + 1) % movementPoints.Length;
        }
        else if (EnemyDetection.playerDetected == true)
        {
            transform.position = EnemyDetection.player.position;
        }
    }
}
