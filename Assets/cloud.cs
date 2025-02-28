using UnityEngine;
using System.Collections.Generic;

public class CloudManager : MonoBehaviour
{
    [Header("Cloud Preforms")]
    public GameObject cloudPrefab;

    [Header("Generate settings")]
    public float spawnInterval = 1f;
    public int maxCloudCount = 6;

    private List<GameObject> cloudsList = new List<GameObject>();
    private float spawnTimer = 0f;

    private float minX, maxX, minY, maxY;
    private Camera mainCam;

    void Start()
    {
        mainCam = Camera.main;
        Vector3 bottomLeft = mainCam.ScreenToWorldPoint(new Vector3(0, 0, mainCam.nearClipPlane));
        Vector3 topRight = mainCam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCam.nearClipPlane));
        minX = bottomLeft.x;
        minY = bottomLeft.y;
        maxX = topRight.x;
        maxY = topRight.y;

        for (int i = 0; i < maxCloudCount; i++)
        {
            SpawnCloud();
        }
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0f;
            if (cloudsList.Count > 0)
            {
                int randomIndex = Random.Range(0, cloudsList.Count);
                Destroy(cloudsList[randomIndex]);
                cloudsList.RemoveAt(randomIndex);
            }
            SpawnCloud();
        }
    }

    void SpawnCloud()
    {
        float randX = Random.Range(minX, maxX);
        float randY = Random.Range(minY, maxY);
        Vector3 spawnPos = new Vector3(randX, randY, 0);
        GameObject newCloud = Instantiate(cloudPrefab, spawnPos, Quaternion.identity);
        cloudsList.Add(newCloud);
    }
}