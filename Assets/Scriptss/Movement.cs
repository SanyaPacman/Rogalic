using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [SerializeField]
    private float moveVelocity;

    private Rigidbody2D rigBody;
    // Start is called before the first frame update
    void Start()
    {
        rigBody = GetComponent<Rigidbody2D>();
    }

    public void MoveInDirection(Vector2 direction)
    {
        if (direction.magnitude == 0)
            rigBody.velocity=Vector2.zero;
        direction.Normalize();
        rigBody.velocity = direction * moveVelocity;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
