using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOIDController : MonoBehaviour
{ 
    
    [SerializeField] private BOIDMovement movement;
    [SerializeField] private BOIDDataCollector dataCollector;
    [SerializeField] private float timeTick;
    private BOIDDataAnalyzer analyzer;
    void Start()
    {
        analyzer = new BOIDDataAnalyzer(transform);
        movement.Init();
        StartCoroutine(UpdateTick());
    }

    void FixedUpdate()
    {
        movement.Move();   
        
        
    }

    private IEnumerator UpdateTick()
    {
        while (true)
        {
            (List<Rigidbody2D> rigids, Vector2 clearPath) data = dataCollector.GetVisibleData();
            Vector2[] analayzedData = analyzer.AnalyzeData(data.rigids);
            movement.SetCenterOfBOIDS(analayzedData[1]);
            movement.SetAlignmentOfBOIDS(analayzedData[0]);
            movement.SetClearPath(data.clearPath);
            yield return new WaitForSeconds(timeTick);
        }
    }

}
