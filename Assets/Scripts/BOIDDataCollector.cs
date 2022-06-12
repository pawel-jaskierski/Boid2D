using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class BOIDDataCollector
{
    [SerializeField] private Transform BOID;
    [SerializeField] private float visionRange;
    [Range(0,360)]
    [SerializeField] private int visionArch;
    public (List<Rigidbody2D>, Vector2) GetVisibleData()
    {
        BOID.gameObject.layer = 2;
        List<Rigidbody2D> rigids = new List<Rigidbody2D>();
        Vector2 clearPath = Vector2.zero;
        Vector2 lookingDir = (BOID.rotation * Vector2.one);
        float angle = AngleStandarization(BOID.rotation.eulerAngles.z + 90);
        for (int archIncrease = 0; archIncrease <= visionArch; archIncrease++)
        {
            float radianAngle = (angle + archIncrease) * Mathf.Deg2Rad;
            radianAngle = archIncrease % 2 == 0 ? Mathf.CeilToInt(radianAngle/2) : Mathf.CeilToInt(-radianAngle/2);  
            Vector2 archDir = new Vector2(Mathf.Sin(radianAngle), Mathf.Cos(radianAngle));
            RaycastHit2D hit = Physics2D.CircleCast(BOID.position,BOID.localScale.x,archDir,visionRange);
            if (hit.collider != null)
            {
                //Debug.Log("I hit something");
                if (!hit.collider.tag.Equals("Wall"))
                {
                    //Debug.Log("Hi");
                    hit.collider.gameObject.layer = 2;
                    rigids.Add(hit.rigidbody);
                }
                else
                {
                    //Debug.Log("I hit wall");
                }
            }
            else if (clearPath == Vector2.zero) {
                clearPath = archDir;
                //Debug.Log(archIncrease);
            }
        }
        for (int i = 0; i < rigids.Count; i++)
        {
            rigids[i].gameObject.layer = 0;
        }
        if (clearPath == Vector2.zero) clearPath = -lookingDir;
        BOID.gameObject.layer = 0;
        return (rigids, clearPath);
    }
    private float AngleStandarization(float angle)
    {
        if(angle > 360)
        {
            return angle % 360;
        }
        while(angle < 0)
        {
            angle += 360;
        }
        return angle;
    }
}
