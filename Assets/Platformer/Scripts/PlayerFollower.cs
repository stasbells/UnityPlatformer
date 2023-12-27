using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    private Transform _player;
    private int _cameraPositionZ = -10;

    private void Start()
    {
        _player = GameObject.Find(nameof(Player)).transform;
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(_player.position.x, transform.position.y, _cameraPositionZ);
    }
}