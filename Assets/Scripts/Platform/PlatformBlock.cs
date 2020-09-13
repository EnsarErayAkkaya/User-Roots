using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBlock : MonoBehaviour
{
    [SerializeField] MeshRenderer mesh;
    void OnTriggerEnter(Collider other)
    {
        mesh.enabled = false;
    }
    public void ActivateMesh ()
    {
        mesh.enabled = true;
    }
}
