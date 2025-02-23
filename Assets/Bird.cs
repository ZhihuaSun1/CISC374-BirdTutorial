using UnityEngine;

public class Bird : MonoBehaviour
{
    public Rigidbody2D myRigidbody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody.velocity = Vector2.up * 10; 
    }
}
