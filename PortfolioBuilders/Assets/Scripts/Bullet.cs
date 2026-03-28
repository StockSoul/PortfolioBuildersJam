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
}
