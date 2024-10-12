using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class KeyoadCatControl : MonoBehaviour
{
    [SerializeField] float catSpeed = 1.5f;

    bool isMovingHorizontal;
    bool isMovingVertical;

    private void Update()
    {
        if(Input.GetKey("up") || Input.GetKey("down"))
        {
            float catVerticalMoving = Input.GetAxis("Vertical") * catSpeed * Time.deltaTime;
            transform.Translate(0, catVerticalMoving, 0);
        }
        else if(Input.GetKey("right") || Input.GetKey("left"))
        {
            float catHorizontalMoving = Input.GetAxis("Horizontal") * catSpeed * Time.deltaTime;
            transform.Translate(catHorizontalMoving, 0, 0);
        }
    }
}
