using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [Header("Texts")]
    [Space(2)]
    [SerializeField] private TextMeshProUGUI _highScoreTMP;
    [SerializeField] private TextMeshProUGUI _energyTMP;

    [Header("Energy System")]
    [SerializeField] private EnergySystem _energySystem;

    private void Awake()
    {
        DisplayHighScore();
        _energyTMP.text = $"Play ({_energySystem.Energy})";
    }

    private void DisplayHighScore()
    {
        float highScore = PlayerPrefs.GetFloat(ScoreSystem.HighScoreKey, 0f);
        _highScoreTMP.text = "High Score:\n" + ((int)highScore).ToString();
    }
}
