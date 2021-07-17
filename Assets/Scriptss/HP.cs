using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    [SerializeField] private float maxHP = 1;
    public bool isDead => currentHP > 0;
    [SerializeField] private HPBar currHPBar;
    private float _currentHP;
    public float currentHP
    {
        private set
        {
            if (value<0)
            {
                _currentHP = 0;
            }
            else
            {
                _currentHP = value;
            }
        }
        get
        {
            return _currentHP;
        }
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        currHPBar.UpdateHPBar(currentHP/maxHP);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
