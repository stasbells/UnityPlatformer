using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Coin _spawnedCoin;
    [SerializeField] private BoxButton _button;
    
    private readonly int Play = Animator.StringToHash(nameof(Play));
    private readonly int Press = Animator.StringToHash(nameof(Press));

    private Animator _coinBoxAnimator;
    private Animator _buttonAnimator;

    private float _launchForce = 5f;
    private int _minAmount = 2;
    private int _maxAmount = 4;
    private int _maxCoinsCount = 8;
    private int _sumSpawnedCoins;

    private void Start()
    {
        _coinBoxAnimator = GetComponent<Animator>();
        _buttonAnimator = _button.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float delayTime = 0.5f;
        float repeatRate = 0f;

        if (collision.TryGetComponent<Player>(out Player player))
        {
            _buttonAnimator.SetTrigger(Press);
            _coinBoxAnimator.SetTrigger(Play);

            if (_sumSpawnedCoins < _maxCoinsCount)
                InvokeRepeating(nameof(Spawn), delayTime, repeatRate);
        }
    }

    private void Spawn()
    {
        int coinsAmount = Random.Range(_minAmount, _maxAmount);

        for (int i = 0; i < coinsAmount; i++)
        {
            float minDirectionValueX = -0.7f;
            float maxDirectionValueX = 0.7f;

            float minDirectionValueY = 0f;
            float maxDirectionValueY = 1f;

            float minTorqueSpanValue = -2f;
            float maxTorqueSpanValue = 2f;

            Coin newCoin = Instantiate(_spawnedCoin, _spawnPoint.transform.position, Quaternion.identity);

            Rigidbody2D rigitBody2D = newCoin.GetComponent<Rigidbody2D>();

            Vector2 direction = new Vector2(Random.Range(minDirectionValueX, maxDirectionValueX), Random.Range(minDirectionValueY, maxDirectionValueY)).normalized;

            rigitBody2D.AddForce(direction * _launchForce, ForceMode2D.Impulse);
            rigitBody2D.AddTorque(Random.Range(minTorqueSpanValue, maxTorqueSpanValue), ForceMode2D.Impulse);
        }

        _sumSpawnedCoins += coinsAmount;
    }
}