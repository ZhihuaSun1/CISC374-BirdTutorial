using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [Header("云朵预制体")]
    public GameObject cloudPrefab;

    [Header("生成设置")]
    public float spawnInterval = 1f;
    public int maxCloudCount = 6;
    
    private float spawnTimer = 0f;
    private float minX, maxX, minY, maxY;
    private Camera mainCam;

    void Start()
    {
        mainCam = Camera.main;
        Vector3 bottomLeft = mainCam.ScreenToWorldPoint(new Vector3(0, 0, mainCam.nearClipPlane));
        Vector3 topRight   = mainCam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCam.nearClipPlane));
        minX = bottomLeft.x;
        minY = bottomLeft.y;
        maxX = topRight.x;
        maxY = topRight.y;
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            GameObject[] currentClouds = GameObject.FindGameObjectsWithTag("Cloud");
            if (currentClouds.Length < maxCloudCount)
            {
                SpawnCloud();
            }
            spawnTimer = 0f;
        }
    }

    void SpawnCloud()
    {
        float randX = Random.Range(minX, maxX);
        float randY = Random.Range(minY, maxY);
        Vector3 spawnPos = new Vector3(randX, randY, 0);
        Instantiate(cloudPrefab, spawnPos, Quaternion.identity);
    }
}