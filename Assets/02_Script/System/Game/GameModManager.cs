using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameMods
{

    Time,
    Score,
    infinite

}

public class GameModManager : MonoBehaviour
{

    [SerializeField] private GameMods currentMod;

    public static GameModManager Instance;

    public event Action<GameMods> OnGameStarted;

    private void Awake()
    {
        
        Instance = this;

    }

    private IEnumerator Start()
    {

        yield return new WaitForSeconds(1);

        OnGameStarted?.Invoke(currentMod);

    }

}
