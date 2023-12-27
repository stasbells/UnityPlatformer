using UnityEngine;

public class EnemyWayPointMoveState : State
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private const int IndexReseter = 0;
    private int _currentPoint;

    private Transform[] _points;
    private Transform _target;
    private Transform _transform;

    private void Start()
    {
        _transform = transform;
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
            _points[i] = _path.GetChild(i);
    }

    private void Update()
    {
        _target = _points[_currentPoint];
        _transform.position = Vector3.MoveTowards(_transform.position, _target.position, _speed * Time.deltaTime);

        if (_transform.position == _target.position)
            _currentPoint++;

        if (_currentPoint >= _points.Length)
            _currentPoint = IndexReseter;
    }
}