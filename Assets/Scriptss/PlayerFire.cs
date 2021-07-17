using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] private RangedAttack rangedAttack;

    [SerializeField] private KeyCode attackKey;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         Vector2 mousePos= Camera.main.ScreenToWorldPoint(Input.mousePosition);
         if (Input.GetKey(attackKey))
         {
             rangedAttack.Fire(mousePos);
         }
    }
}
