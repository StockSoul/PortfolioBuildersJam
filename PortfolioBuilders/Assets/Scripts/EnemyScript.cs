using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
     public float destroyX = -20f;
     public float speed = 5f;
     public float maxSpeed = 35f;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

         
        if (transform.position.x < destroyX)//Destroy after it goes off screen
        {
            Destroy(gameObject);
        }
         
    }
     public void SetSpeed(float newSpeed)
       {
        speed = Mathf.Min(newSpeed, maxSpeed); // ensures it doesn't exceed maxSpeed
       }
}
