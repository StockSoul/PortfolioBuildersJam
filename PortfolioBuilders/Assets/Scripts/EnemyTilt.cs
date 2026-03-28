using UnityEngine;

public class EnemyTilt : MonoBehaviour
{
    public float tiltAngle = 10f;
    public float tiltSpeed = 2f;
    private float phaseOffset;

    void Start()
    {
        phaseOffset = Random.Range(0f, 2f * Mathf.PI);
    }

    void Update()
    {
        float targetZ = Mathf.Sin(Time.time * tiltSpeed + phaseOffset) * tiltAngle;
        transform.localRotation = Quaternion.Euler(0, 0, targetZ); // LOCAL rotation only
    }
}