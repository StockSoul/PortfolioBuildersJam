using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    private Camera cam;
    private float halfHeight;
    private float halfWidth;

    private float playerHalfWidth;
    private float playerHalfHeight;

    private Shooting shooting;

    void Start()
    {
        //Get our main camera (WHICH SHOULD BE THE ONLY ONE IN THIS PROJECT)
        cam = Camera.main;

        halfHeight = cam.orthographicSize;

        var bounds = GetComponent<SpriteRenderer>().bounds;
        playerHalfHeight = bounds.extents.y;

        shooting = GetComponent<Shooting>();
    }

    void Update()
    {
        //We only move up and down because we are moving "forward"
        float moveY = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(0f, moveY, 0f);
        transform.position += move * speed * Time.deltaTime;

        // Clamp AFTER movement
        ClampToCamera();

        if (Input.GetKeyDown("space"))
        {
            shooting.Shoot();
        }
    }

    void ClampToCamera()
    {
        Vector3 pos = transform.position;

        float clampedY = Mathf.Clamp(
            pos.y,
            -halfHeight + playerHalfHeight,
            halfHeight - playerHalfHeight
        );

        transform.position = new Vector2(pos.x, clampedY);
    }
    void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("DeadlyEnemy") || other.CompareTag("KillableEnemy"))
    {
        Die();
    }
}
    public void Die()
    {
        Debug.Log("Player Died");

        Destroy(gameObject);

        
    }

}