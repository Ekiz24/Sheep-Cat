using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepEscapeFromCat : MonoBehaviour
{
    [SerializeField] float sheepSpeed = 1f;
    [SerializeField] float sheepMoveDuration = 0.5f;
    public bool isSheepStartMoving = false;

    [SerializeField] GameObject cat;
    
    Vector2 sheepPosition;
    Vector2 catPosition;
    Vector2 escapeDirection;
    float distance;

    private void Update()
    {
        SheepEscaping();
    }

    private void SheepEscaping()
    {
        if (isSheepStartMoving)
        {
            sheepPosition = transform.position;
            catPosition = cat.transform.position;
            escapeDirection = new Vector2((2 * sheepPosition.x - catPosition.x) , 2 * sheepPosition.y - catPosition.y);
         
            distance = Vector2.Distance(sheepPosition, catPosition);

            if (distance < 3)
            {
                transform.position = Vector2.MoveTowards(sheepPosition, escapeDirection, sheepSpeed * Time.deltaTime);
                //StartCoroutine(SheepRunning());
            }
            else
            {
                transform.position = Vector2.MoveTowards(sheepPosition, escapeDirection, sheepSpeed * Time.deltaTime);
                StartCoroutine(SheepRunning());
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Cat" && !isSheepStartMoving)
        {
            isSheepStartMoving = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Cat" && !isSheepStartMoving)
        {
            isSheepStartMoving = false;
        }
    }


    IEnumerator SheepRunning()
    {
        yield return new WaitForSeconds(sheepMoveDuration);
        isSheepStartMoving = false;
        SheepEscaping();
    }
}
