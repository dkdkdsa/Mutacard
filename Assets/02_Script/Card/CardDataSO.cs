using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Card/Data")]
public class CardDataSO : ScriptableObject
{

    [field:SerializeField] public LanguageData cardName { get; private set; }
    [field:SerializeField] public CardType cardType { get; private set; }
    [field:SerializeField] public int rank { get; private set; }
    [field:SerializeField] public Sprite icon { get; private set; }
    [field:SerializeField] public LanguageData cardExplanation { get; private set; }

}
