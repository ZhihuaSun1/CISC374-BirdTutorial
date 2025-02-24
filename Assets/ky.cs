using UnityEngine;

public class ky : MonoBehaviour
{
    public GameObject pipe;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(pipe, transform.position, transform.rotation);
    }
}
