using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ESCUIController : MonoBehaviour
{
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

    private class MainMenuUIController : UIController
    {
        private GameObject panel;

        public MainMenuUIController(GameObject panel)
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

            rootTrm.DOLocalMoveX(0, 0.3f).SetEase(Ease.OutSine).OnComplete(() => isControl = false).SetUpdate(true);

        }

        public override void Release()
        {

            if (isControl) return;

            isControl = true;

            rootTrm.DOLocalMoveX(800, 0.3f).SetEase(Ease.OutSine).OnComplete(() => isControl = false).SetUpdate(true);

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

            rootTrm.DOLocalMoveX(0, 0.3f).SetEase(Ease.OutSine).OnComplete(() => isControl = false).SetUpdate(true);

        }

        public override void Release()
        {

            if (isControl) return;

            isControl = true;

            rootTrm.DOLocalMoveX(800, 0.3f).SetEase(Ease.OutSine).OnComplete(() => isControl = false).SetUpdate(true);

        }

    }

    [SerializeField] private Transform escPanel;
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject exitPanel;
    [SerializeField] private Image blackPanel;
    [SerializeField] private TextMeshProUGUI pause;

    private MainMenuUIController mainMenuUIController;
    private ExitUIController exitUIController;
    private List<UIController> controllerLs = new();

    private bool isEsc = false;

    private void Awake()
    {
        mainMenuUIController = new(mainMenuPanel);
        exitUIController = new(exitPanel);

        controllerLs.Add(mainMenuUIController);
        controllerLs.Add(exitUIController);
    }

    private void Update()
    {
        if(!isEsc && Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            ShowESC();
        }
        else if(isEsc && Input.GetKeyDown(KeyCode.Escape))
        {

            Continue();
        }
    }

    public void ShowESC() //esc 누르면 뜸
    {
        FadeESC(true);
        escPanel.DOLocalMoveX(0, 0.3f).SetEase(Ease.OutSine).OnComplete(() => isEsc = true).SetUpdate(true);
    }

    public void FadeESC(bool value)
    {
        if(value)
        {
            blackPanel.DOFade(0.5f, 0.3f).SetUpdate(true);
            pause.DOFade(1, 0.3f).SetUpdate(true);
        }
        else
        {
            blackPanel.DOFade(0, 0.3f).SetUpdate(true);
            pause.DOFade(0, 0.3f).SetUpdate(true);
        }
    }

    public void Continue()
    {
        FadeESC(false);
        escPanel.DOLocalMoveX(-550, 0.3f).SetEase(Ease.OutSine).OnComplete(() => isEsc = false).SetUpdate(true);

        NoMainMenu();
        NoExit();

        Time.timeScale = 1;

    }

    #region MainMenuButton
    public void StartMainMenuControl()
    {
        mainMenuUIController.Controll();
        Release(mainMenuUIController);
    }

    public void NoMainMenu()
    {

        mainMenuUIController.Release();

    }

    public void YesMainMenu()
    {

        SceneManager.LoadScene("IntroScene");
        Time.timeScale = 1;

    }

    #endregion
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

    private void Release(UIController controller)
    {

        var controlls = controllerLs.FindAll(x => x != controller);

        foreach (var item in controlls)
        {

            item.Release();

        }

    }
}
