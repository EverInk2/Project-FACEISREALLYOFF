using UnityEngine;

public class gridsnap : MonoBehaviour
{
    // The size of your grid cells in Unity units (e.g., 1.0 for 1x1 grid)
    public float gridSize = 1.0f;

    // Reference to the Rigidbody2D
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("SnapToGrid script requires a Rigidbody2D component!");
        }
    }

    void Update()
    {
        // Check if the object has stopped moving
        if (rb.linearVelocity.magnitude < 0.01f)
        {
            SnapPositionToGrid();
        }
    }

    /// <summary>
    /// Rounds the current position to the nearest grid point.
    /// </summary>
    public void SnapPositionToGrid()
    {
        Vector2 currentPosition = rb.position;

        // Calculate the snapped X and Y coordinates
        float snappedX = Mathf.RoundToInt(currentPosition.x / gridSize) * gridSize;
        float snappedY = Mathf.RoundToInt(currentPosition.y / gridSize) * gridSize;

        // Set the new, snapped position using MovePosition for physics consistency
        rb.MovePosition(new Vector2(snappedX, snappedY));
    }
}
