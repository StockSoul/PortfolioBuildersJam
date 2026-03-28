using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;

    void Start()
    {
        Destroy(gameObject, 3f);
    }
    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }

     private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("KillableEnemy"))
        {
            Destroy(other.gameObject); // kill enemy
            Destroy(gameObject);       // destroy bullet
        }
        else if (other.CompareTag("DeadlyEnemy"))
        {
            Destroy(gameObject); // bullet just disappears
        }
    }
}
