using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BOIDMovement
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rigid;
    [Range(0, 1)]
    [SerializeField] private float dirChangeDueToObstacle;
    [Range(0, 1)]
    [SerializeField] private float dirChangeDueToCenter;
    [Range(0, 1)]
    [SerializeField] private float dirChangeDueToAlignment;
    [SerializeField] private Transform transform;
    private Vector2 dir;
    private Vector2 clearPathDir;
    private Vector2 boidCenterDir;
    private Vector2 alignmentDir;

    public void Init()
    {
        dir = Random.insideUnitCircle.normalized;
        alignmentDir = Vector2.zero;
        boidCenterDir = Vector2.zero;
    }

    public void Move()
    {
        //Debug.Log("Clear Path " + clearPathDir);
        //.Log(clearPathDir);
        Vector2 changeVector = (dirChangeDueToObstacle * clearPathDir + boidCenterDir * dirChangeDueToCenter + alignmentDir * dirChangeDueToAlignment)/3;
        //Debug.Log(changeVector);
        dir = ((dir + changeVector)/2).normalized;
        transform.rotation = Quaternion.FromToRotation(Vector2.up, dir);
        rigid.velocity = speed * dir;   
     }

    public void SetCenterOfBOIDS(Vector2 center)
    {
        boidCenterDir = center;
    }
    public void SetAlignmentOfBOIDS(Vector2 alignment) {
        alignmentDir = alignment;
    }
    public void SetClearPath(Vector2 path)
    {
        clearPathDir = path;
    }
}
