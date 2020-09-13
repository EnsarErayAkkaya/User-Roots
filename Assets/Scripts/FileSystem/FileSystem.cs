using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileSystem : MonoBehaviour
{
    public Folder root;
    public Folder currentDir;
    private GameObject activePlatform = null;
    void Start()
    {
        LoadDir(root);
    }
    public void LoadDir(Folder f)
    {
        if(activePlatform != null)
        {
            Destroy(activePlatform);
        }
        currentDir = f;
        Debug.Log("current dir: " + currentDir.folderName);
        activePlatform = Instantiate(currentDir.platform);
    }
}
