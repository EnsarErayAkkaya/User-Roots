using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float rotationSpeed;
    public void CallLerpPose(Vector3 newPos, Vector3 newAngle)
    {
        StartCoroutine( LerpPosition(newPos, newAngle) );
    }
    IEnumerator LerpPosition(Vector3 newPos, Vector3 newAngle)
    {
        float t = 0;
        Vector3 startingAngle = transform.rotation.eulerAngles;
        while( t < 1 )
        {
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, newPos, t);
            transform.rotation = Quaternion.Euler( Vector3.Lerp(transform.rotation.eulerAngles, startingAngle + newAngle, t) ); 
            yield return null;
        }
    }
}
