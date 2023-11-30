using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnergySystem : MonoBehaviour
{
    [Header("Energy Config")]
    [Space(3)]
    [SerializeField] private int _maxEnergy = 100;
    [SerializeField] private int _consumeEnergyAmount = 10;
    [SerializeField] private int _energyRechargeDurationInSeconds = 30;

    [Header("Notification Handler")]
    [Space(3)]
    [SerializeField] private AndroidNotificationHandler _androidNotificationHandler;

    private int _energy;
    private const int MinEnergy = 0;

    public const string EnergyKey = "Energy";
    public const string EnergyReadyKey = "EnergyReady";

    public int Energy
    {
        get
        {
            return PlayerPrefs.GetInt(EnergyKey, _maxEnergy);
        }
    }

    private void Awake()
    {
        _energy = PlayerPrefs.GetInt(EnergyKey, _maxEnergy);
        if (_energy == MinEnergy)
        {
            string energyReadyAsString = PlayerPrefs.GetString(EnergyReadyKey, string.Empty);
            if (energyReadyAsString.Equals(string.Empty)) { return; }

            DateTime energyReady = DateTime.Parse(energyReadyAsString);

            if (DateTime.Now > energyReady)
            {
                FillEnergy();
            }
        }
    }

    private void FillEnergy()
    {
        _energy = _maxEnergy;
        PlayerPrefs.SetInt(EnergyKey, _energy);
    }

    public void ConsumeEnergy()
    {
        _energy -= _consumeEnergyAmount;
        _energy = Mathf.Max(_energy, MinEnergy);
        PlayerPrefs.SetInt(EnergyKey, _energy);
    }

    public void SetNextEnergyReadyDate()
    {
        DateTime nextEnergyReady = DateTime.Now.AddSeconds(_energyRechargeDurationInSeconds);
        PlayerPrefs.SetString(EnergyReadyKey, nextEnergyReady.ToString());
#if UNITY_ANDROID
        _androidNotificationHandler.ScheduleNotification(nextEnergyReady);
#endif
    }

    public void PlayAgain()
    {
        if (_energy > MinEnergy)
        {
            ConsumeEnergy();
            SceneManager.LoadScene("Scene_Game");
        }

        if (_energy == MinEnergy)
        {
            SetNextEnergyReadyDate();
        }
    }
}
