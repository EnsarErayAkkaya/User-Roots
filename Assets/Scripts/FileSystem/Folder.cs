using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Folder", menuName = "FileSystem/Folder", order = 0)]
public class Folder : ScriptableObject
{
    public string folderName;
    public List<Folder> folders;
    public List<File> files;
    public GameObject platform;
    public Folder parent;
}
