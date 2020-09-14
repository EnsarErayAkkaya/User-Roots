using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public delegate void TurnAction();
    public static event TurnAction OnTurnStarted;

    public void CallStartTurn()
    {
        StartCoroutine( StartTurn() );
    }
    IEnumerator StartTurn()
    {
        yield return new WaitForSeconds(1);
        OnTurnStarted();
    }
}
