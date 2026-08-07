using UnityEngine;

public class Obstacle : MonoBehaviour
{
    void Start()
    {
        float randomSize = Random.Range(1f, 5f);
        transform.localScale = new Vector3(randomSize, randomSize,1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

