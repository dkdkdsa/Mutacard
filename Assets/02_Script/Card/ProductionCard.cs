using FD.Dev;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductionCard : Card
{

    protected override void Start()
    {

        if(GameModManager.Instance.cMod == GameMods.Score)
        {

            StartCoroutine(ScoreSetCo());

        }


    }

    private IEnumerator ScoreSetCo()
    {

        while (true)
        {

            yield return new WaitForSeconds(5);
            ScoreManager.Instance.AddScore(data.rank * 100);
            FAED.TakePool<TextEffect>("TEF", transform.position + new Vector3(0, 0.5f) / 2).Show($"+{data.rank * 100}", Color.green);

        }

    }

}
