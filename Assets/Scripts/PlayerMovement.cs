using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Audio;

namespace Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        //Player Movement
        public float movespeed = 5f;
        Rigidbody2D rb;
        Camera cam;
        Vector2 movement;
        Vector2 mousePos;
        public bool canMove = true;
        Joystick joystick;
        float footstepTime = 0;

        //Sound
        public SoundPack footsteps;
        AudioSource audioSource;

        bool mobile;

        void Start()
        {
            //Get Rigidbody2D
            rb = gameObject.GetComponent<Rigidbody2D>();
            cam = GameObject.Find("MainCamera").GetComponent<Camera>();

            //Get Audio Source
            audioSource = gameObject.GetComponent<AudioSource>();

            // Get platform
            /*
            if ((Application.platform == RuntimePlatform.IPhonePlayer) || (Application.platform == RuntimePlatform.Android))
                mobile = true;
            else mobile = false;

            if (mobile)
                joystick = HUD.joystick.GetComponent<FixedJoystick>();
            */
        }

        void Update()
        {
            if (!mobile)
            {
                movement.x = Input.GetAxisRaw("Horizontal");
                movement.y = Input.GetAxisRaw("Vertical");
                mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            }
            else
            {
                movement.x = joystick.Horizontal;
                movement.y = joystick.Vertical;
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);
                    mousePos = Camera.main.ScreenToWorldPoint(touch.position);
                }
            }
        }

        // Used for moving the player
        void FixedUpdate()
        {
            // Movement
            if (canMove)
            {
                rb.MovePosition(rb.position + movement * movespeed * Time.fixedDeltaTime);
                Vector2 lookDir = mousePos - rb.position;
                float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
                rb.rotation = angle;

                //Used for footstep sound
                if (movement.x != 0 || movement.y != 0)
                {
                    if (Time.time >= footstepTime)
                    {
                        if (Time.timeScale != 0)
                        {
                            audioSource.clip = footsteps.audio[1];
                            audioSource.Play();
                            footstepTime = Time.time + .5f;
                        }
                    }
                }
            }
        }

        public void incMoveSpd(float speed)
        {
            movespeed += speed;
        }

        public bool decMoveSpd(float speed)
        {
            if ((movespeed - speed) > 0)
            {
                movespeed -= speed;
                return true;
            }
            else return false;
        }

        public void DisableMovement()
        {
            canMove = false;
        }

        public void EnableMovement()
        {
            canMove = true;
        }
    }
}
