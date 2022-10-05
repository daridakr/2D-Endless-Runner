using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class ScoreDisplay : MonoBehaviour
{
    private TMP_Text _scoreDisplay;
    private float _currentValue = 0;

    private void Awake()
    {
        _scoreDisplay = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        _currentValue += Time.deltaTime * 10;
        _scoreDisplay.text = $"Score: {_currentValue.ToString("F")}";
    }
}
