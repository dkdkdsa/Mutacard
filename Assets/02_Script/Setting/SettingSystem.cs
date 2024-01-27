using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingSystem : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown languageDropdown;
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider sfxSlider;

    private void Update()
    {
        int idx = languageDropdown.value; //0�̸� �ѱ���, 1�̸� ����
        //���� �ڵ�

        AudioManager.Instance.SetBgmVolume(bgmSlider.value);
        AudioManager.Instance.SetSfxVolume(sfxSlider.value);
    }
}
