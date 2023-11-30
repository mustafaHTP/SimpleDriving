using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreTMP;
    [SerializeField] private float _scoreMultiplier;

    private float _score;

    public static ScoreSystem Instance;
    public const string HighScoreKey = "HighScore";

    private void Update()
    {
        _score += _scoreMultiplier * Time.deltaTime;
        _scoreTMP.text = ((int)_score).ToString();
    }

    private void OnDestroy()
    {
        float currentHighScore = PlayerPrefs.GetFloat(HighScoreKey, 0f);
        if (_score > currentHighScore)
        {
            PlayerPrefs.SetFloat(HighScoreKey, _score);
        }
    }
}
