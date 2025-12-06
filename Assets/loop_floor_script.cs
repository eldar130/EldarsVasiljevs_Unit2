using UnityEngine;

public class loop_floor_script : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float width = 35.2f;
    private SpriteRenderer _spriteRenderer;
    private Vector2 startSize;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        startSize = new Vector2(_spriteRenderer.size.x, _spriteRenderer.size.y);
    }

    void Update()
    {
        _spriteRenderer.size = new Vector2(_spriteRenderer.size.x + speed * Time.deltaTime, _spriteRenderer.size.y);
        if (_spriteRenderer.size.x > width)
        {
            _spriteRenderer.size = startSize;
        }
    }
}
