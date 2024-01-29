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

        }

    }

}
