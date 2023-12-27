using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(SpriteRenderer))]
public class ColorChanger : MonoBehaviour
{
    [SerializeField] private float _interval;

    private Color _resetColor;
    private Color _targetColor;
    private bool _isChanged;

    private Player _player;
    private SpriteRenderer _sprite;
    private Coroutine _colorController;

    private void OnEnable()
    {
        _player.Damaged += ChangedColorTo;
        _player.Recovered += ChangedColorTo;
    }

    private void OnDisable()
    {
        _player.Damaged -= ChangedColorTo;
        _player.Recovered -= ChangedColorTo;
    }

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _player = GetComponent<Player>();
        _resetColor = new Color(1, 1, 1, 1);
        _isChanged = true;
    }

    private void ChangedColorTo(Color color)
    {
        _targetColor = color;

        if (_colorController != null)
            StopCoroutine(_colorController);

        _colorController = StartCoroutine(ChangeColor());

        _isChanged = true;
    }

    private IEnumerator ChangeColor()
    {
        while (true)
        {
            OnChangedColor();

            yield return null;
        }
    }

    private void OnChangedColor()
    {
        if (_sprite.color != _targetColor && _isChanged)
        {
            _sprite.color = Color.Lerp(_sprite.color, _targetColor, _interval * Time.deltaTime);
        }
        else
        {
            _sprite.color = Color.Lerp(_sprite.color, _resetColor, _interval * Time.deltaTime);
            _isChanged = false;
        }
    }
}