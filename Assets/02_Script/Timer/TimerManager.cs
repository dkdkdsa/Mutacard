using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TimerManager : MonoBehaviour
{
    [SerializeField] private float MaxTimer;
    private float Timer;
    [SerializeField] private float PlusTime;
    [SerializeField] private float PlusTimeCount;

    public UnityEvent OverEvenet;

    [SerializeField] private TextMeshProUGUI TimerText;
    [SerializeField] private TextMeshProUGUI PlusTimerText;
    [SerializeField] private GameObject PlusTimerGameo;
    // Start is called before the first frame update
    void Start()
    {
        Timer = MaxTimer;
        TimerText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        TimerText.text = Timer.ToString("0.##");
        if (Timer > 0 )
        {
            
            Timer -= Time.deltaTime;
        }
        else if(Timer <= 0)
        {
            if(PlusTimeCount > 0)
            {
                StartCoroutine(ShowplustTime());
                PlusTimeCount--;
                Timer += PlusTime;
            }
            else
            {
                OverEvenet.Invoke();
            }
        }
    }

    private IEnumerator ShowplustTime()
    {
        PlusTimerGameo.SetActive(true);
        PlusTimerText = GameObject.Find("PlusTime").GetComponent<TextMeshProUGUI>();
        PlusTimerText.text = "+" + PlusTime.ToString();
        yield return new WaitForSeconds(1.5f);
        Destroy(PlusTimerGameo);
    }

    public void Test()
    {
        Debug.Log("ตส");
    }
}
