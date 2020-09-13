using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New CD Command", menuName = "Console/CDCommand", order = 0)]
public class CDCommand : ConsoleCommand 
{
    FileSystem fileSystem;
    public override bool Process(string[] args)
    {
        if(fileSystem == null)
        {
            fileSystem = FindObjectOfType<FileSystem>();
        }

        if(args.Length > 1 || args.Length < 1 )
        {
            return false;
        }
        else
        {
            if(args[0].Equals(".."))
            {
                fileSystem.LoadDir(fileSystem.currentDir.parent);
                return true;
            }
            else
            {
                foreach (Folder item in fileSystem.currentDir.folders)
                {
                    if( !item.folderName.Equals( args[0], System.StringComparison.OrdinalIgnoreCase ) )
                    {
                        continue;
                    }
                    else
                    {
                        fileSystem.LoadDir(item);
                        return true;
                    }
                }
            }
            
        }
        
        return false;
    }    
}
