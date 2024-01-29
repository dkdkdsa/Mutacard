using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroSceneUIController : MonoBehaviour
{

    private class ModeSelectUIControll : UIController
    {

        private Transform rootTrm;

        public ModeSelectUIControll(Transform rootTrm)
        {

            this.rootTrm = rootTrm;

        }

        public override void Controll()
        {

            if (isControl) return;

            isControl = true;

            rootTrm.DOLocalMoveX(110, 0.3f).SetEase(Ease.OutSine).OnComplete(() => isControl = false);

        }

        public override void Release()
        {

            if (isControl) return;

            isControl = true;

            rootTrm.DOLocalMoveX(800, 0.3f).SetEase(Ease.OutSine).OnComplete(() => isControl = false);

        }

    }
    private class RankingUIController : UIController
    {

        private Transform rootTrm;

        public RankingUIController(Transform rootTrm)
        {

            this.rootTrm = rootTrm;

        }

        public override void Controll()
        {

            if (isControl) return;

            isControl = true;

            rootTrm.DOLocalMoveX(100, 0.3f).SetEase(Ease.OutSine).OnComplete(() => isControl = false);

        }

        public override void Release()
        {

            if (isControl) return;

            isControl = true;

            rootTrm.DOLocalMoveX(800, 0.3f).SetEase(Ease.OutSine).OnComplete(() => isControl = false);

        }

    }
    private class SettingUIController : UIController
    {

        private Transform rootTrm;

        public SettingUIController(Transform rootTrm)
        {

            this.rootTrm = rootTrm;

        }

        public override void Controll()
        {

            if (isControl) return;

            isControl = true;

            rootTrm.DOLocalMoveX(0, 0.3f).SetEase(Ease.OutSine).OnComplete(() => isControl = false);

        }

        public override void Release()
        {

            if (isControl) return;

            isControl = true;

            rootTrm.DOLocalMoveX(800, 0.3f).SetEase(Ease.OutSine).OnComplete(() => isControl = false);

        }

    }

    private class BookUIController : UIController
    {

        private Transform rootTrm;

        public BookUIController(Transform rootTrm)
        {

            this.rootTrm = rootTrm;

        }

        public override void Controll()
        {

            if (isControl) return;

            isControl = true;

            rootTrm.DOLocalMoveX(258, 0.3f).SetEase(Ease.OutSine).OnComplete(() => isControl = false);

        }

        public override void Release()
        {

            if (isControl) return;

            isControl = true;

            rootTrm.DOLocalMoveX(800, 0.3f).SetEase(Ease.OutSine).OnComplete(() => isControl = false);

        }

    }

    private class ExitUIController : UIController
    {
        private GameObject panel;

        public ExitUIController(GameObject panel)
        {
            this.panel = panel;
        }

        public override void Controll()
        {
            panel.SetActive(true);
        }

        public override void Release()
        {
            panel.SetActive(false);
        }
    }


    [SerializeField] private ShowTitle titleUI;
    [SerializeField] private Transform mainUI;
    [SerializeField] private Transform modeSelectUI;
    [SerializeField] private Transform rankingUI;
    [SerializeField] private Transform settingUI;
    [SerializeField] private Transform bookUI;
    [SerializeField] private GameObject exitUI;
    [SerializeField] private TMP_Text languageText;
    [SerializeField] private GameObject namePanel;
    [Header("-rankings-")]
    [SerializeField] private Transform rankingParent;
    [SerializeField] private RankingPanel panelPrefab;

    [Header("Title")]
    [SerializeField] private float endValue;
    [SerializeField] private float duration;
    [SerializeField] private float waitTime;

    [Header("Other")]
    [SerializeField] private Slider sounudSlider;

    private ModeSelectUIControll modeSelectUIController;
    private RankingUIController rankingUIController;
    private SettingUIController settingUIController;
    private BookUIController bookUIController;
    private ExitUIController exitUIController;
    private List<UIController> controllerLs = new();

    private LanguageType current;

    private void Awake()
    {

        current = LanguageManager.CurrentLanguageType;

        modeSelectUIController = new(modeSelectUI);
        rankingUIController = new(rankingUI);
        settingUIController = new(settingUI);
        bookUIController = new(bookUI);
        exitUIController = new(exitUI);

        controllerLs.Add(modeSelectUIController);
        controllerLs.Add(rankingUIController);
        controllerLs.Add(settingUIController);
        controllerLs.Add(bookUIController);
        controllerLs.Add(exitUIController);

        LootLockerController.Init((x) =>
        {

            if (x)
            {

                SetScoreRanking();

                LootLockerController.GetPlayerName((x) =>
                {

                    if(x == string.Empty)
                    {

                        namePanel.gameObject.SetActive(true);

                    }

                });

            }

        });

        Sequence seq = DOTween.Sequence();

        titleUI.Title(waitTime, endValue, duration);
        
        seq.PrependInterval(3f)
            .Append(mainUI.DOLocalMoveX(0, 0.3f));

        SetLanguageText();

        AudioLoad();

    }

    public void SetName()
    {

        string name = namePanel.GetComponentInChildren<TMP_InputField>().text;

        LootLockerController.SetPlayerName(name);

    }

    public void StartModeControl()
    {

        modeSelectUIController.Controll();
        Release(modeSelectUIController);

    }

    public void StartRankingControl()
    {

        rankingUIController.Controll();
        Release(rankingUIController);

    }

    public void StartSettingControl()
    {

        settingUIController.Controll();
        Release(settingUIController);

    }

    public void StartBookControl()
    {

        bookUIController.Controll();
        Release(bookUIController);

    }

    #region ExitButton
    public void StartExitControl()
    {
        exitUIController.Controll();
        Release(exitUIController);
    }

    public void NoExit()
    {
        exitUIController.Release();
    }

    public void YesExit()
    {
        Debug.Log("게임 나가기!");
        Application.Quit();
    }
    #endregion

    public void ReleaseAll()
    {

        modeSelectUIController.Release();

    }

    public void SetScoreRanking()
    {

        LootLockerController.GetLederboard("Score", 9, (x) =>
        {

            for (int i = 0; i < rankingParent.childCount; i++)
            {

                Destroy(rankingParent.GetChild(i).gameObject);

            }

            for (int i = 0; i < x.Count; i++)
            {

                Instantiate(panelPrefab, rankingParent).SetRanking(x[i].rank, x[i].player.name, x[i].score);

            }


        });

    }

    public void SetTimeRanking()
    {

        LootLockerController.GetLederboard("Time", 9, (x) =>
        {

            for(int i = 0; i < rankingParent.childCount; i++)
            {

                Destroy(rankingParent.GetChild(i).gameObject);

            }

            for (int i = 0; i < x.Count; i++)
            {

                Instantiate(panelPrefab, rankingParent).SetRanking(x[i].rank, x[i].player.name, x[i].score);

            }


        });

    }

    private void Release(UIController controller)
    {

        var controlls = controllerLs.FindAll(x => x != controller);

        foreach(var item in controlls)
        {

            item.Release();

        }

    }

    public void LoadScene(string sceneName)
    {

        SceneManager.LoadScene(sceneName);

    }

    public void AudioSetting(Slider slider)
    {
        PlayerPrefs.SetFloat("SoundValue", slider.value);

        AudioManager.Instance.SetBgmVolume(slider.value);
        AudioManager.Instance.SetSfxVolume(slider.value);
    }

    private void AudioLoad()
    {
        float soundValue = PlayerPrefs.GetFloat("SoundValue");
        if (soundValue == 0.0f) soundValue = 1;

        sounudSlider.value = soundValue;

        AudioManager.Instance.SetBgmVolume(soundValue);
        AudioManager.Instance.SetSfxVolume(soundValue);
    }

    public void LanChPlus()
    {

        int c = (int)current + 1;

        if(c >= 2)
        {

            LanguageManager.CurrentLanguageType = LanguageType.KOR;

        }
        else
        {

            LanguageManager.CurrentLanguageType = LanguageType.ENG;

        }

        current = LanguageManager.CurrentLanguageType;

        SetLanguageText();

    }

    public void LanChM()
    {

        int c = (int)current - 1;

        if (c < 0)
        {

            LanguageManager.CurrentLanguageType = LanguageType.ENG;

        }
        else
        {

            LanguageManager.CurrentLanguageType = LanguageType.KOR;

        }

        current = LanguageManager.CurrentLanguageType;

        SetLanguageText();

    }

    private void SetLanguageText()
    {

        languageText.text = LanguageManager.CurrentLanguageType switch
        {

            LanguageType.KOR => "한국어",
            LanguageType.ENG => "English",
            _ => "Error!"

        };

    }

}
