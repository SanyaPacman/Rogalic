using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    [SerializeField] private GameObject misslePrefab;
    [SerializeField] private float reloadTime;
    [SerializeField] private Transform _gunPoint;
    [SerializeField] private float velocityPower;

    public Transform gunPoint
    {
        private set
        {
            _gunPoint = value;
        }
        get
        {
            return _gunPoint;
        }
    }
    private float currReloadTime=0f;
    public void Fire(Vector2 target)
    {
        if (CanFire())
        {
            GameObject pref = Instantiate(misslePrefab,gunPoint.position,new Quaternion());
            Vector2 direction = target - (Vector2)gunPoint.position;
            pref.GetComponent<Rigidbody2D>().AddForce(velocityPower*direction.normalized);
            SetReload();
        }
    }

    private void SetReload()
    {
        currReloadTime = 0;
    }

    private bool CanFire()
    {
        return currReloadTime > reloadTime;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!CanFire())
        {
            currReloadTime += Time.deltaTime;    
        }
    }
}
