using UnityEngine;

public class loop_floor_script : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float width = 35.2f;
    private SpriteRenderer spriteRenderer;
    private Vector2 startSize;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startSize = new Vector2(spriteRenderer.size.x, spriteRenderer.size.y);
    }

    void Update()
    {
        //make the floor loop when it reaches derired width
        spriteRenderer.size = new Vector2(spriteRenderer.size.x + speed * Time.deltaTime, spriteRenderer.size.y);
        if (spriteRenderer.size.x > width)
        {
            spriteRenderer.size = startSize;
        }
    }
}
