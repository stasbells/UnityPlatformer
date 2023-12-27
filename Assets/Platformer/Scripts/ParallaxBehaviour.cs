using UnityEngine;

public class ParallaxBehaviour : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)] private float _parallaxStrenght = 0.1f;
    [SerializeField] private Transform _followingTarget;
    [SerializeField] private bool _disableVerticalParallax;

    private Vector3 _targetPeviousPosition;

    private void Start()
    {
        if (!_followingTarget)
            _followingTarget = Camera.main.transform;

        _targetPeviousPosition = _followingTarget.position;
    }

    private void Update()
    {
        Vector3 delta = _followingTarget.position - _targetPeviousPosition;

        if (_disableVerticalParallax)
            delta.y = 0;

        _targetPeviousPosition = _followingTarget.position;

        transform.position += delta * _parallaxStrenght;
    }
}