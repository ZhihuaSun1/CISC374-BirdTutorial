using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [Header("云朵预制体设置")]
    public GameObject cloudPrefab;

    [Header("生成速率设置")]
    public float initialSpawnInterval = 1f;
    public float maxSpawnInterval = 5f;

    public float intervalIncreaseRate = 0.2f;

    public int minCloudsPerBurst = 3;
    public int maxCloudsPerBurst = 5;

    private float currentSpawnInterval;
    private float spawnTimer = 0f;

    private float minX, maxX, minY, maxY;
    private Camera mainCam;

    void Start()
    {
        currentSpawnInterval = initialSpawnInterval;
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
        if (spawnTimer >= currentSpawnInterval)
        {
            SpawnClouds();
            spawnTimer = 0f;
            currentSpawnInterval = Mathf.Min(currentSpawnInterval + intervalIncreaseRate, maxSpawnInterval);
        }
    }

    void SpawnClouds()
    {
        int count = Random.Range(minCloudsPerBurst, maxCloudsPerBurst + 1);
        for (int i = 0; i < count; i++)
        {
            float randX = Random.Range(minX, maxX);
            float randY = Random.Range(minY, maxY);
            Vector3 spawnPos = new Vector3(randX, randY, 0);
            Instantiate(cloudPrefab, spawnPos, Quaternion.identity);
        }
    }
}