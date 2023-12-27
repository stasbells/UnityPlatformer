using UnityEngine;

public class FollowState : State
{
    [SerializeField] private float _speed;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        if (Target != null)
            _transform.position = Vector2.MoveTowards(_transform.position, Target.transform.position, _speed * Time.deltaTime);
    }
}