using UnityEngine;

public class CollisionTesting : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("I hit something!");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("I hit something!");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("I hit something!");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("I hit something!");
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("I hit something!");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("I hit something!");
    }


}
