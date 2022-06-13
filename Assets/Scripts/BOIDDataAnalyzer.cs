using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOIDDataAnalyzer{
    private Transform scriptBOID;
    public BOIDDataAnalyzer(Transform BOID)
    {
        scriptBOID = BOID;
    }

    public Vector2[] AnalyzeData(List<Rigidbody2D> otherBOIDS)
    {
        Vector2[] answer = new Vector2[2];
        Vector2 sum = Vector2.zero;
        if (otherBOIDS.Count > 0)
        {

            for (int i = 0; i < otherBOIDS.Count; i++)
            {
                sum += otherBOIDS[i].velocity.normalized;
            }
            answer[0] = (sum / otherBOIDS.Count).normalized;
            answer[1] = answer[0] - new Vector2(scriptBOID.position.x, scriptBOID.position.y).normalized;
        }
        return answer;
    }
}
