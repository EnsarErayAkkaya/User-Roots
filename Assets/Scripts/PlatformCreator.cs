using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCreator : MonoBehaviour
{
    public GameObject block;
    public int axisBlockWidth = 6;
    public int axisBlockLength = 8;
    public float distanceBeetwenBlocks = .3f;
    Vector3 pointerPos = Vector3.zero; 
    public Transform platformParent;
    void Start()
    {
        CreatePlatform();   
    }
    void CreatePlatform()
    {
        for (int i = 0; i < axisBlockLength; i++)
        {
            for (int j = 0; j < axisBlockWidth; j++)
            {
                var go = Instantiate(block, pointerPos, Quaternion.identity);
                go.transform.parent = platformParent;
                pointerPos.x += distanceBeetwenBlocks;
            }
            pointerPos.x = 0;
            pointerPos.z += distanceBeetwenBlocks;
        }

        pointerPos.x = 6 * distanceBeetwenBlocks;
        pointerPos.z = 0;

        for (int i = 0; i < axisBlockWidth; i++)
        {
            for (int j = 0; j < axisBlockLength; j++)
            {
                 var go = Instantiate(block, pointerPos, Quaternion.identity);
                go.transform.parent = platformParent;
                pointerPos.z += distanceBeetwenBlocks;
            }
            pointerPos.z = 0;
            pointerPos.y += distanceBeetwenBlocks;
        }

        pointerPos.z = 8 * distanceBeetwenBlocks;
        pointerPos.y = 0;
        pointerPos.x = 0;

        for (int i = 0; i < axisBlockWidth ; i++)
        {
            for (int j = 0; j < axisBlockLength -1; j++)
            {
                 var go = Instantiate(block, pointerPos, Quaternion.identity);
                go.transform.parent = platformParent;
                pointerPos.x += distanceBeetwenBlocks;
            }
            pointerPos.x = 0;
            pointerPos.y += distanceBeetwenBlocks;
        }
    }
}
