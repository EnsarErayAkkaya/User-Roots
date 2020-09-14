using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Move Command", menuName = "Console/MoveCommand", order = 0)]
public class MoveCommand : ConsoleCommand 
{
    Player player;
    PlatformCreator platform;
    public override bool Process(string[] args)
    {
        if(platform == null)
        {
            platform = FindObjectOfType<PlatformCreator>();
            player = FindObjectOfType<Player>();
        }
        
        if(args.Length > 1 || args.Length < 1 )
        {
            return false;
        }
        Vector3 playerPos = player.transform.position;
        Vector3 angle = Vector3.zero;
        if( "right".Equals( args[0], System.StringComparison.OrdinalIgnoreCase ) )
        {
            Vector3 newPos = playerPos + (player.transform.right * platform.distanceBeetwenBlocks);
            if(platform.IsInPlatform(newPos))
            {
                player.CallLerpPose(newPos, new Vector3(0,90,0));
                return true;
            }
            else
            {
                return false;
            }
        }
        else if( "left".Equals( args[0], System.StringComparison.OrdinalIgnoreCase ) )
        {
            Vector3 newPos =  playerPos + (-player.transform.right *  platform.distanceBeetwenBlocks);
            if(platform.IsInPlatform(newPos))
            {
                player.CallLerpPose(newPos, new Vector3(0,-90,0));
                return true;
            }
            else
            {
                return false;
            }
        }
        else if( "forward".Equals( args[0], System.StringComparison.OrdinalIgnoreCase ) )
        {
            Vector3 newPos =  playerPos + (player.transform.forward * platform.distanceBeetwenBlocks);
            if(platform.IsInPlatform(newPos))
            {
                player.CallLerpPose(newPos, new Vector3(0,0,0));
                return true;
            }
            else
            {
                return false;
            }
        }
        else if( "back".Equals( args[0], System.StringComparison.OrdinalIgnoreCase ) )
        {
            Vector3 newPos =  playerPos + (-player.transform.forward * platform.distanceBeetwenBlocks);
            if(platform.IsInPlatform(newPos))
            {
                player.CallLerpPose(newPos, new Vector3(0,180,0));
                return true;
            }
            else
            {
                return false;
            }
        }
        
        return false;
    }
    
}

