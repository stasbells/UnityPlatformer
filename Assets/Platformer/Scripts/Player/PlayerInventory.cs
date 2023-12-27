using TMPro;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private TMP_Text _canvasText;

    private Player _player;
    private int _coins;

    private void FixedUpdate() 
    {
        _canvasText.text = _coins.ToString();
        _player = GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            Destroy(coin.gameObject);
            _coins++;
        }

        if (collision.TryGetComponent<Heal>(out Heal heal))
        {
            _player.ApplyHaelth(heal.Health);
            Destroy(heal.gameObject);
        }
    }
}