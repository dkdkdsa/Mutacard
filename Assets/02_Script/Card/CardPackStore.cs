using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardPackStore : MonoBehaviour
{

    [SerializeField] private GameObject cardPackPrefab;
    [SerializeField] private int price;

    private void OnMouseDown()
    {

        if (MoneyManager.instance.Buy(price))
        {

            var obj = Instantiate(cardPackPrefab);
            NewCard(obj);

        }

    }

    private void NewCard(GameObject obj)
    {

        Vector3 end = Random.insideUnitCircle * (Random.value + 1.5f);
        end.z = 0;

        Sequence seq = DOTween.Sequence();
        seq.Append(obj.transform.DORotate(new Vector3(360 * Random.Range(1, 3), 360 * Random.Range(1, 3)), 0.3f, RotateMode.FastBeyond360).SetEase(Ease.OutQuad));
        seq.Join(obj.transform.DOJumpZ(end, -2, 1, 0.3f).SetEase(Ease.OutQuad));
        seq.AppendCallback(() => obj.transform.position = end);

    }

#if UNITY_EDITOR

    private void OnValidate()
    {

        GetComponentInChildren<TMP_Text>().text = $"{price}$";

    }

#endif

}
