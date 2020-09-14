using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AutoTextScroller : MonoBehaviour
{
    ScrollRect scrollRect;

    void Start()
    {
        scrollRect = GetComponent<ScrollRect>();
    }
    public void OnValueChanged()
    {
        StartCoroutine( GoToBottom() );
    }
    IEnumerator GoToBottom()
    {
        yield return new WaitForEndOfFrame();
        scrollRect.verticalNormalizedPosition = 0f;
    }

}
