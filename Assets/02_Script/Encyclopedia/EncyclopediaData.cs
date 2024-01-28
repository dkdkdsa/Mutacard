using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Data/EncyclopediaData", fileName = "Data")]
public class EncyclopediaData : ScriptableObject
{
    public bool isCatch;
    public Sprite dataSprite;
    public string dataName;
    public string dataExplanation;
}
