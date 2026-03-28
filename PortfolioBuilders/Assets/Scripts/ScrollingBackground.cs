using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public Transform bg1;
    public Transform bg2;
    public float speed = 2f;

    private float width;

    void Start()
    {
        //Get width of background image
        width = bg1.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float move = speed * Time.deltaTime;

        bg1.position += Vector3.left * move;
        bg2.position += Vector3.left * move;

        if (bg1.position.x <= -width)
        {
            bg1.position = new Vector2(bg2.position.x + width, bg1.position.y);
        }

        if (bg2.position.x <= -width)
        {
            bg2.position = new Vector2(bg1.position.x + width, bg2.position.y);
        }
    }
}
