using UnityEngine;

public class FollowDistanceTransition : Transition
{
    [SerializeField] private float _transitionRange = 10;
    [SerializeField] private float _attackDistance;

    private void Update()
    {
        if (Target == null)
            return;

        float distance = Vector2.Distance(transform.position, Target.transform.position);

        if (distance < _transitionRange && distance > _attackDistance)
            NeedTransit = true;
    }
}