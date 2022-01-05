using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float speed = 2.5f;



    private void PlayOnAndroid()
    {
        //OnMouseDrag();
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // get first touch since touch count is greater than zero

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                // get the touch position from the screen touch to world point
                Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                // lerp and set the position of the current object to that of the touch, but smoothly over time.
                transform.position = Vector3.Lerp(transform.position, touchedPos, Time.deltaTime);
            }
        }
    }
    private void MoveByKeboard()
    {
        
            Vector3 movement = new Vector3
            {
                x = Input.GetAxis("Horizontal"),
                y = 0f,
                z = Input.GetAxis("Vertical")
            }.normalized;

            movement *= speed * Time.deltaTime;
            transform.Translate(movement);

        

    }
   
    // Update is called once per frame
    void Update()
    {
        #if UNITY_ANDROID
                    PlayOnAndroid();
        #elif UNITY_WEBGL || UNITY_STANDALONE
                MoveByKeboard();


        #endif


    }


}
