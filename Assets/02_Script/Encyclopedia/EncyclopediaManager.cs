using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncyclopediaManager : MonoBehaviour
{
    public static EncyclopediaManager Instance;

    public Dictionary<string, EncyclopediaData> encyclopediaDataDick = new Dictionary<string, EncyclopediaData>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(transform);
        }

        foreach (EncyclopediaData data in Resources.LoadAll<EncyclopediaData>("EncyclopediaData"))
        {
            encyclopediaDataDick[data.dataName] = data;
        }
    }

    public void RegistrationData(string dataName)
    {
        if (!encyclopediaDataDick.ContainsKey(dataName))
        {
            Debug.Log($"{dataName}(은)는 도감에는 존재하지 않는 포켓몬");
            return;
        }

        encyclopediaDataDick[dataName].isCatch = true;
    }
}
