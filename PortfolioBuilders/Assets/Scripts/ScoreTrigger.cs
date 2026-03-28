using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    public int scoreValue = 1;        // points for passing
    public float speed = 5f;          // how fast the trigger moves left
    private bool triggered = false;   // make sure it only triggers once

    void Update()
    {
        // move left
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // destroy if off-screen
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // only trigger for player, and only once
        if (!triggered && other.CompareTag("Player"))
        {
            triggered = true;

            ScoreManager sm = FindObjectOfType<ScoreManager>();
            if (sm != null)
            {
                sm.AddScore(scoreValue);
            }

            Destroy(gameObject); // remove immediately after giving score
        }
    }
}