using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TagSystem))]
public class TimerSystem : MonoBehaviour
{
    [SerializeField]
    private float _startingTime = 30.0f;

    [SerializeField]
    private TextMeshProUGUI _timerText;

    private float _timeRemaining;
    private TagSystem _tagSystem;

    public float TimeRemaining { get { return _timeRemaining; } }

    private void Start()
    {
        _tagSystem = GetComponent<TagSystem>();
        _timeRemaining = _startingTime;
        if (_timerText)
        {
            _timerText.text = _timeRemaining.ToString("0.0");
        }
    }

    private void Update()
    {
        if (!_tagSystem.Tagged) return;

        _timeRemaining -= Time.deltaTime;
        _timeRemaining = Mathf.Clamp(_timeRemaining, 0, _startingTime);

        if (_timerText)
        {
            _timerText.text = _timeRemaining.ToString("0.0");
        }
    }
}
