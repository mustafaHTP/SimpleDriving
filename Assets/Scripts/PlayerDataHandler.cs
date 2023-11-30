using UnityEngine;

public class PlayerDataHandler : MonoBehaviour
{
    private const string HighScoreKey = "HighScore";
    private const string EnergyKey = "Energy";
    private const string EnergyReadyKey = "EnergyReady";

    private const int DefaultHighScore = 0;
    private const int DefaultEnergyAmount = 0;
    private const string DefaultEnergyReady = "";

    public void ResetHighScore()
    {
        if (PlayerPrefs.HasKey(HighScoreKey))
        {
            PlayerPrefs.SetFloat(HighScoreKey, DefaultHighScore);
            PlayerPrefs.Save();
        }
    }

    public void ResetEnergy()
    {
        if (PlayerPrefs.HasKey(EnergyKey))
        {
            PlayerPrefs.SetInt(EnergyKey, DefaultEnergyAmount);
            PlayerPrefs.Save();
        }

        if (PlayerPrefs.HasKey(EnergyReadyKey))
        {
            PlayerPrefs.SetString(EnergyReadyKey, DefaultEnergyReady);
            PlayerPrefs.Save();
        }
    }
}
