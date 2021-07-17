using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAI : AI
{
    private RangedAttack rangedAttack;
    
    // Start is called before the first frame update
     override protected void Start()
     {
         Debug.Log(rangedAttack);
         base.Start();
         rangedAttack = GetComponent<RangedAttack>();        
     }

     
    // Update is called once per frame
    override protected void Update()
    {
        base.Update();
        stateAnimator.SetBool("EnemyOnLinesight", false);
        if (currentTarget==null)
            return;        
        ray = (Vector2)(currentTarget.transform.position - transform.position);
        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position, (Vector2)(ray).normalized, Mathf.Infinity, LayerMask.NameToLayer("IgnoreBullets"));//gameObject.layer);
        if (hit.collider.gameObject == currentTarget)
        {
            stateAnimator.SetBool("EnemyOnLinesight", true);
            Debug.Log("on line");
        }
        centr = hit.point;
    }

    private Vector3 centr;
    private Vector3 ray;
    private void OnDrawGizmosSelected()
    {       
        Gizmos.color=Color.red;
        
        Ray r = new Ray(centr, ray);
        Gizmos.DrawRay(transform.position,ray);
        Gizmos.DrawWireSphere(centr, 0.75f);
    }
}