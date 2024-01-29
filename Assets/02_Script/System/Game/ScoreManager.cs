using LootLocker.Requests;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    private string boardKey;
    private string id;
    private ulong score;

    public ulong Score {
        get
        {

            return score;

        }

        set { score = value; }

    }


    public event Action<int> OnScoreAdded;
    public event Action OnScoreUploadEnd;


    public static ScoreManager Instance;

    private void Awake()
    {
        
        Instance = this;

        if(!LootLockerSDKManager.CheckInitialized())
        {

            LootLockerController.Init((x) =>
            {

                if (x)
                {

                    LootLockerSDKManager.GetPlayerInfo((y) =>
                    {

                        id = y.ulid;

                    });

                }

            });

        }
        else
        {

            LootLockerSDKManager.GetPlayerInfo((y) =>
            {

                id = y.ulid;

            });

        }

    }


    private void Start()
    {

        GameModManager.Instance.OnGameStarted += HandleGameStarted;
        TimerManager.Instance.OnTimeOutEvent += HandleGameEnd;

    }

    private void HandleGameEnd(float obj)
    {

        LootLockerController.UplodeScore(id, (int)score, boardKey, (x) =>
        {

            if (x)
            {

                OnScoreUploadEnd?.Invoke();

            }

        });

    }

    private void HandleGameStarted(GameMods mod)
    {

        boardKey = mod switch
        {

            GameMods.Score => "Score",
            GameMods.Time => "Time",
            GameMods.infinite => "",
            _ => ""

        };
    
    }

    public void AddScore(int score)
    {

        this.score += (ulong)score;
        OnScoreAdded?.Invoke(score);

    }

}
