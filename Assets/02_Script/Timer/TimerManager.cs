using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TimerManager : MonoBehaviour
{

    [SerializeField] private float timeLimit;

    private float currentTime;
    private float totalTime;
    private bool gameStrarted;

    public event Action<float> OnTimeChangedEvent;
    public event Action<float> OnTimeOutEvent;
    public event Action<float> OnTimeAddEvent;
    public static TimerManager Instance;

    private void Awake()
    {

        Instance = this;
        currentTime = timeLimit;

    }

    private void Start()
    {

        GameModManager.Instance.OnGameStarted += HandleGameStarted;

    }

    private void HandleGameStarted(GameMods mod)
    {

        gameStrarted = true;
        if(mod == GameMods.Time)
        {

            CardManager.Instance.OnCardMarged += HandleCardMarged;

        }

    }

    private void HandleCardMarged(int rank)
    {

        AddTime(rank * 1.5f);

    }

    private void Update()
    {

        if (gameStrarted)
        {

            currentTime -= Time.deltaTime;
            totalTime += Time.deltaTime;

            if(GameModManager.Instance.cMod == GameMods.Time)
            {

                ScoreManager.Instance.Score = (ulong)totalTime;

            }

            OnTimeChangedEvent?.Invoke(currentTime);

        }

        if(currentTime <= 0 && gameStrarted)
        {

            gameStrarted = false;
            OnTimeOutEvent?.Invoke(totalTime);

        }

    }

    public void AddTime(float time)
    {

        if (!gameStrarted) return;

        OnTimeAddEvent?.Invoke(time);

        currentTime += time;

    }

}
