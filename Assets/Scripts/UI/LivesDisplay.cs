using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class LivesDisplay : MonoBehaviour
{
    [SerializeField] private Player _target;
    
    private TMP_Text _livesDisplay;

    private void Start()
    {
        _livesDisplay = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        _target.LivesChanged += OnLivesChanged;
    }

    private void OnDisable()
    {
        _target.LivesChanged -= OnLivesChanged;
    }

    private void OnLivesChanged(int lives)
    {
        _livesDisplay.text = lives.ToString();
    }
}
