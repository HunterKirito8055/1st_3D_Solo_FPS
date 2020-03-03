using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    [SerializeField]
    Transform  Player, LookRoot;

    [SerializeField]
    bool invert;

    [SerializeField]
    bool can_unlock = true;

    [SerializeField]
    float sensitivity;

    [SerializeField]
    Vector2 clampingLooks = new Vector2(-75f, 85f);

    Vector2 mouse_look;
    Vector2 look_at;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        Lock_Unlock_Cursor();

        if (Cursor.lockState == CursorLockMode.Locked)
        {
            LookAround();    
        }
    }
    void Lock_Unlock_Cursor()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

    }

    void LookAround()
    {
        /* Note This bro.........*/
        //X and Y are inverted in Unity world space
        // X gives vertical values and Y gives Horizontal Values bro..
                        //new vector2(float X, float Y)
        mouse_look = new Vector2(Input.GetAxis(MouseAxis.MOUSE_Y), Input.GetAxis(MouseAxis.MOUSE_X));

        look_at.x += mouse_look.x * sensitivity * (invert ? 1f:-1f);
        look_at.y += mouse_look.y * sensitivity;

        look_at.x = Mathf.Clamp(look_at.x, clampingLooks.x, clampingLooks.y);

        LookRoot.localRotation= Quaternion.Euler(look_at.x, 0f, 0f);
        Player.localRotation = Quaternion.Euler(0f, look_at.y, 0f);

    }





}//class

















