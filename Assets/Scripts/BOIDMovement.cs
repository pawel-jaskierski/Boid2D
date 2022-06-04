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
    [SerializeField] private Transform t1;
    [SerializeField] private Transform t2;
    [SerializeField] private Transform t3;
    private Vector2 dir;
    private Vector2 clearPathDir;
    private Vector2 boidCenterDir;
    private Vector2 alignmentDir;

    public void Init()
    {
        dir = (new Vector2(Random.Range(0f, 1f), Random.Range(0f, 1f))).normalized;
    }

    public void Move()
    {
        clearPathDir = t1.position.normalized;
        boidCenterDir = t2.position.normalized;
        alignmentDir = t3.position.normalized;
        Vector2 changeVector = (dirChangeDueToObstacle * clearPathDir + boidCenterDir * dirChangeDueToCenter + alignmentDir * dirChangeDueToAlignment)/3;
        dir = ((dir + changeVector).normalized).normalized;
        rigid.velocity = speed*dir;
    }

    public void SetCenterOfBOIDS(Vector2 center)
    {

    }
}
