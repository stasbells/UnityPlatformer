using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField] private int _health;

    public int Health => _health;
}