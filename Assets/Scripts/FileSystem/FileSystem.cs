using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileSystem : MonoBehaviour
{
    public Folder root;
    public Folder currentDir;
    void Start()
    {
        currentDir = root;
    }
    public void LoadDir(Folder f)
    {
        currentDir = f;
        Debug.Log("current dir: " + currentDir.folderName);
        //...//
    }
}
