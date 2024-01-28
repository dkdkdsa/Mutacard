using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

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

            rootTrm.DOLocalMoveX(0, 0.3f).SetEase(Ease.OutSine).OnComplete(() => isControl = false);

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

            rootTrm.DOLocalMoveX(0, 0.3f).SetEase(Ease.OutSine).OnComplete(() => isControl = false);

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

            rootTrm.DOLocalMoveX(0, 0.3f).SetEase(Ease.OutSine).OnComplete(() => isControl = false);

        }

        public override void Release()
        {

            if (isControl) return;

            isControl = true;

            rootTrm.DOLocalMoveX(800, 0.3f).SetEase(Ease.OutSine).OnComplete(() => isControl = false);

        }

    }

    [SerializeField] private Transform modeSelectUI;
    [SerializeField] private Transform rankingUI;
    [SerializeField] private Transform settingUI;
    [SerializeField] private Transform bookUI;
    [SerializeField] private TMP_Text languageText;
    [Header("-rankings-")]
    [SerializeField] private Transform rankingParent;
    [SerializeField] private RankingPanel panelPrefab;

    private ModeSelectUIControll modeSelectUIController;
    private RankingUIController rankingUIController;
    private SettingUIController settingUIController;
    private BookUIController bookUIController;
    private List<UIController> controllerLs = new();

    private LanguageType current;

    private void Awake()
    {

        current = LanguageManager.CurrentLanguageType;

        modeSelectUIController = new(modeSelectUI);
        rankingUIController = new(rankingUI);
        settingUIController = new(settingUI);
        bookUIController = new(bookUI);

        controllerLs.Add(modeSelectUIController);
        controllerLs.Add(rankingUIController);
        controllerLs.Add(settingUIController);
        controllerLs.Add(bookUIController);

        LootLockerController.Init((x) =>
        {

            if (x)
            {

                SetScoreRanking();

            }

        });

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

            LanguageType.KOR => "ÇÑ±¹¾î",
            LanguageType.ENG => "English",
            _ => "Error!"

        };

    }

}
