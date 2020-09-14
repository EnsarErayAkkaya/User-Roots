using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : TurnBased
{
    Player player;
    PlatformCreator platform;
    void Start()
    {
        player = FindObjectOfType<Player>();
        platform = FindObjectOfType<PlatformCreator>();
    }
    public override void MakeMove()
    {
        CalculateMove();
    }
    public void CalculateMove()
    {
        Vector3 dist = player.transform.position - transform.position;
        
        dist /= platform.distanceBeetwenBlocks;
        
        Vector3 angle = Vector3.zero;
        Vector3 newPos = Vector3.zero;
        
        if(dist == Vector3.zero)
            return;

        Debug.Log("dist to player : " + dist);
        if( dist.y > .1f || dist.y < -.1f )
        {
            Debug.Log("dist.y : "+dist.y+ " , 0 dan farklı değil" + (dist.y != 0.0f));
            int dir =  (dist.y == 0.0f? 0 : dist.y > 0.0f?1:-1);
            newPos = new Vector3(transform.position.x, transform.position.y + (dir * platform.distanceBeetwenBlocks), transform.position.z );
        }
        else if(dist.x > .1f || dist.x < -.1f)
        {        
            Debug.Log("dist.x : "+dist.x+ " , 0 dan farklı değil" + (dist.x != 0.0f));   
            int dir =  (dist.x == 0.0f? 0 : dist.x > 0.0f? 1:-1);
            
            newPos = new Vector3(transform.position.x + (dir * platform.distanceBeetwenBlocks), transform.position.y, transform.position.z );
            angle.y = dir > 0.0f ? 90 : -90;
        }
        else if(dist.z > .1f || dist.z < -.1f)
        {
            Debug.Log("dist.z : "+dist.z+ " , 0 dan farklı değil" + (dist.z != 0.0f));
            int dir =  (dist.z == 0.0f? 0 : dist.z > 0.0f?1:-1);

            newPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + (dir * platform.distanceBeetwenBlocks) );
            angle.y = dir > 0.0f ? 0 : 180;
        }
        
        Debug.Log("new po should be : "+newPos);
        StartCoroutine( LerpPosition(newPos, angle) );
    }
    
    IEnumerator LerpPosition(Vector3 newPos, Vector3 newAngle)
    {
        float t = 0;
        Vector3 startingAngle = transform.rotation.eulerAngles;
        Vector3 startingPos = transform.position; 
        while( t < 1 )
        {
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(startingPos, newPos, t);
            transform.rotation = Quaternion.Euler( Vector3.Lerp(transform.rotation.eulerAngles, startingAngle + newAngle, t) ); 
            yield return null;
        }
    }
}
