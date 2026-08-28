using UnityEngine;

public class Meteoro : MonoBehaviour
{
    [Header("Settings")]
    public float minFallSpeed = 2f;
    public float maxFallSpeed = 6f;
    public float minRotationSpeed = -100f;
    public float maxRotationSpeed = 100f;

    private float fallSpeed;
    private float rotationSpeed;
    private float bottomLimit;
    private float topLimit;
    private float xLimit;

    private Camera mainCam;

    void Start()
    {
        mainCam = Camera.main;
        bottomLimit = mainCam.ViewportToWorldPoint(new Vector3(0, 0, 0)).y - 1f;
        topLimit = mainCam.ViewportToWorldPoint(new Vector3(0, 1, 0)).y + 1f;
        xLimit = mainCam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;

        Randomize();
    }
    void Update()
    {
        // 1. Fall down
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime, Space.World);

        // 2. Rotate
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

        // 3. Infinite loop
        if (transform.position.y < bottomLimit)
        {
            RespawnAtTop();
        }
    }

    void RespawnAtTop()
    {
        float randomX = Random.Range(-xLimit, xLimit);
        transform.position = new Vector3(randomX, topLimit, 0);
        Randomize();
    }

    void Randomize()
    {
        fallSpeed = Random.Range(minFallSpeed, maxFallSpeed);
        rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);

        // Random scale variation - great for pixel art
        float scale = Random.Range(0.8f, 1.3f);
        transform.localScale = new Vector3(scale, scale, 1f);
    }
}