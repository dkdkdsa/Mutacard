using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour
{

    [field:SerializeField] public float mutationProbability { get; private set; }

    public static FieldManager Instance;

    private void Awake()
    {
        
        Instance = this;

    }

    private void OnDestroy()
    {
        
        Instance = null;

    }

    public void SetProb(float prob)
    {

        mutationProbability = prob;

    }

}
