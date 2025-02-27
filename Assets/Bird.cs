using TMPro;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength = 5f;
    public logicscript logic;
    public bool birdIsAlive = true;
    private float topBoundary;
    private float bottomBoundary;
    private float leftBoundary;
    private float rightBoundary;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<logicscript>();
                Camera mainCam = Camera.main;

        float cameraY = mainCam.transform.position.y; 
        float cameraX = mainCam.transform.position.x; 
        float orthoSize = mainCam.orthographicSize;   
        float aspect = mainCam.aspect;                
        topBoundary    = cameraY + orthoSize;
        bottomBoundary = cameraY - orthoSize;
        rightBoundary  = cameraX + orthoSize * aspect;
        leftBoundary   = cameraX - orthoSize * aspect;
    }

    // Update is called once per frame
    void Update()
    {
        if (birdIsAlive && Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody.linearVelocity = Vector2.up * flapStrength;
        }
        if (birdIsAlive && 
            (transform.position.y > topBoundary || transform.position.y < bottomBoundary
            || transform.position.x > rightBoundary || transform.position.x < leftBoundary))
        {
            Debug.Log("小鸟飞出屏幕边界，游戏结束！");
            logic.gameOver();       
            birdIsAlive = false;    
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (birdIsAlive)
        {
            logic.gameOver();
            birdIsAlive = false;
        }
    }
}
