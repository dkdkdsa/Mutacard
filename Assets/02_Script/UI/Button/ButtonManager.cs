using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(transform);
        }
    }

    public void ActiveTrueObj(GameObject obj)
        => obj.SetActive(true);

    public void ActiveFalseObj(GameObject obj)
        => obj.SetActive(false);

    public void ActiveReversObj(GameObject obj)
        => obj.SetActive(!obj.activeSelf);

    public void LoadScene(string name)
        => SceneManager.LoadScene(name);

    public void QuitGame()
        => Application.Quit();
}
