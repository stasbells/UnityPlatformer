using UnityEngine;

public class EnemyView : MonoBehaviour
{
    private Transform _transform;
    private SpriteRenderer _spriteRenderer;
    private float _previousFramePosition;



    private void Start()
    {
        _transform = transform;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _previousFramePosition = _transform.position.x;
    }

    private void Update()
    {
        FlipSprite();
    }

    private void FlipSprite()
    {
        if (_previousFramePosition >= _transform.position.x)
            _spriteRenderer.flipX = true;
        else
            _spriteRenderer.flipX = false;

        _previousFramePosition = _transform.position.x;
    }
}