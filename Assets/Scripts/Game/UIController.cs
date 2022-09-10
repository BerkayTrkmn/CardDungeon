using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject[] panels;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI moneyText;

    private void Start()
    {
        levelText.text = "Level: " + LevelCreator.levelNumber;
        SetMoney(PlayerController.money);
    }
    private void OnEnable()
    {
        PlayerController.onGameFailed += OnGameFailed;
        PlayerController.onGameCompleted += OnGameCompleted;
        PlayerController.onGameStarted += OnGameStarted;
        PlayerController.onMoneyGain += OnMoneyGain;
    }

   

    private void OnGameStarted()
    {
        SetPanelActivity(0, false);
    }

    private void OnGameCompleted()
    {
        SetPanelActivity(1, true);
    }

    private void OnGameFailed()
    {
        SetPanelActivity(2, true);
    }
    private void OnMoneyGain()
    {
        SetMoney(PlayerController.money);
    }
    public void GameStarted()
    {
        PlayerController.onGameStarted?.Invoke();
    }
    public void NextLevel()
    {
        PlayerPrefs.SetInt(Config.PREFS_LEVEL, ++LevelCreator.levelNumber);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void SetPanelActivity(int panelID, bool activity)
    {
        panels[panelID].SetActive(activity);
    }
    public void SetMoney(int money)
    {
        moneyText.text = "Money: " + money;
    }
}
