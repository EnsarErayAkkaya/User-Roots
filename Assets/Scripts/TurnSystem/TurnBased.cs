using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TurnBased : MonoBehaviour
{
    void OnEnable()
    {
        TurnManager.OnTurnStarted += MakeMove;
    }


    void OnDisable()
    {
        TurnManager.OnTurnStarted -= MakeMove;
    }

    public abstract void MakeMove();
}
