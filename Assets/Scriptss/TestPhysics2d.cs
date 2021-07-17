using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPhysics2d : MonoBehaviour
{
    public GameObject currentTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {       
        ray = (Vector2)(currentTarget.transform.position - transform.position);
        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position, (Vector2)(ray).normalized);
        centr = hit.point;
    }
    private Vector3 centr;
    private Vector3 ray;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(centr, 0.1f);
        Ray r = new Ray(centr, ray);
        Gizmos.DrawRay(transform.position, ray);
        Gizmos.DrawWireSphere(centr, 0.75f);
    }
}
