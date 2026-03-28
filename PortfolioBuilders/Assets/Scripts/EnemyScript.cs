using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    

     public float speed = 5f;
     public float maxSpeed = 35f;
    
    void Start()
    {
      
    }
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

         // if enemy moved past X = -10 (off left side)
        if (transform.position.x < -10f)
        {
                 Destroy(gameObject);
        }

         
    }
     public void SetSpeed(float newSpeed)
       {
        speed = Mathf.Min(newSpeed, maxSpeed); // ensures it doesn't exceed maxSpeed
       }
}
