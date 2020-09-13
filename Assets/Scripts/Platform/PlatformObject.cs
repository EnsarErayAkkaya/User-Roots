using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformObject : MonoBehaviour
{
    public List<PlatformBlock> blocks;
    void OnTriggerEnter(Collider other)
    {
        blocks.Add( other.transform.GetComponent<PlatformBlock>() );
    }
    void OnDestroy()
    {
        foreach (var item in blocks)
        {
            item.ActivateMesh();
        }
        blocks.Clear();
    }
}
