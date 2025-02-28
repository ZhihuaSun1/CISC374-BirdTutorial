using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public float driftSpeed = 0.2f;
    public Vector2 driftDirection = new Vector2(1, 0);

    void Update()
    {
        transform.Translate(driftDirection.normalized * driftSpeed * Time.deltaTime);
    }
}