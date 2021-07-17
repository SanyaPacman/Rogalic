using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI: MonoBehaviour
{

    [SerializeField] private Transform[] _wayPoints;

    public Transform[] wayPoints
    {
        protected set
        {
            _wayPoints = value;
        }
        get
        {
            return _wayPoints;
        }
    }


    virtual protected void Update()
    {
        
    }

    public NavMeshAgent agent  { private set;  get; }
        public GameObject currentTarget  { private set;  get; }
        
        protected Animator stateAnimator;
        virtual protected void Start()
        {
            agent =  GetComponent<NavMeshAgent>();
            agent.updateRotation = false;
            agent.updateUpAxis = false;
            stateAnimator = GetComponent<Animator>();
        }



        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<Player>()!=null)
            {
                stateAnimator.SetBool("EnemyinRange",true);
                currentTarget = other.gameObject;
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.GetComponent<Player>()!=null)
            {
                stateAnimator.SetBool("EnemyinRange",false);
                currentTarget = null;
            }
        }
    }
