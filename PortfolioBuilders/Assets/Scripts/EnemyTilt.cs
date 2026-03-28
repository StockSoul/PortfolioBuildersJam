using UnityEngine;

public class EnemyTilt : MonoBehaviour
{
    public float tiltAngle = 10f;  //how much it goes up and down
    public float tiltSpeed = 2f; //how fast it moves
    private float phaseOffset; //so not all sync

    void Start()
    {
        phaseOffset = Random.Range(0f, 2f * Mathf.PI); //Random place in wavee up down or middle.!
    }

    void Update()
    {
        float targetZ = Mathf.Sin(Time.time * tiltSpeed + phaseOffset) * tiltAngle; //Calculate current tilt
        transform.localRotation = Quaternion.Euler(0, 0, targetZ); //only rotate this child not parent
    }
}