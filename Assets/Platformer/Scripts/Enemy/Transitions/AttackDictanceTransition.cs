using UnityEngine;

public class AttakDictanceTransition : Transition
{
    [SerializeField] private float _transitionRange = 10;

    private void Update()
    {
        if (Target != null && Vector2.Distance(transform.position, Target.transform.position) < _transitionRange)
            NeedTransit = true;
    }
}