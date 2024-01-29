using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgmStart : MonoBehaviour
{
    [SerializeField] private string bgmName;

    void Start()
    {
        AudioManager.Instance.StartBgm(bgmName);
        InputButtonSfx();
    }

    private void InputButtonSfx()
    {
        foreach (Button allBtn in FindObjectsOfType<Button>())
        {
            allBtn.onClick.AddListener(() => { AudioManager.Instance.StartSfx("Button"); });
        }
    }
}
