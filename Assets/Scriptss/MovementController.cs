using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class MovementController: MonoBehaviour
    {
        [SerializeField]
        private Movement movement;

        private Vector2 direcrion;
        [SerializeField]
        private KeyCode keyUp;
        [SerializeField]
        private KeyCode keyDown;
        [SerializeField]
        private KeyCode keyLeft;
        [SerializeField]
        private KeyCode keyRight;
        [SerializeField]
        private KeyCode keyDodge;
        [SerializeField]
        private KeyCode keyFire;
        private void Start()
        {
            direcrion = new Vector2(0, 0);
        }

        private Vector2 GetDirecrion()
        {
            direcrion = Vector2.zero; 
            if (Input.GetKey(keyUp))
            {
                direcrion+=Vector2.up;
            }
            if (Input.GetKey(keyDown))
            {
                direcrion+=Vector2.down;
            }
            if (Input.GetKey(keyRight))
            {
                direcrion+=Vector2.right;
            }
            if (Input.GetKey(keyLeft))
            {
                direcrion+=Vector2.left;
            }
            return direcrion;
        }
        private void Update()
        {
            direcrion = GetDirecrion();
            movement.MoveInDirection(direcrion);
        }
    }
