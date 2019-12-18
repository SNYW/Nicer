using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

    bool tracking;
    float fMoveSpeed;
    Vector2 swipeStartPos;
    Vector2 swipeCurrentPos;

    bool nice;

    void Start()
    {
        tracking = false;
        fMoveSpeed = 1f;
        swipeStartPos = new Vector2(0, 0);
        if(Random.Range(0,1) == 1) 
        {
            nice = false; 
        } 
        else 
        {
            nice = true; 
        }
    }

    void Update()
    {
        manageOffset();
        manageSwipe();
    }

    void OnMouseDown()
    {
        swipeStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        tracking = true;
    }

    void OnMouseUp()
    {
        swipeStartPos = new Vector2(0, 0);
        swipeCurrentPos = new Vector2(0, 0);
        tracking = false;
    }

    Vector2 GetSwipeOffset(Vector2 startPos, Vector2 currentPos)
    {
        Vector2 offsetPos = new Vector2(currentPos.x - startPos.x, 0);
        return offsetPos;
    }

    float GetSwipeOffsetFloat(Vector2 startPos, Vector2 currentPos)
    {
        Vector2 offsetPos = new Vector2(currentPos.x - startPos.x, 0);
        //Debug.Log(offsetPos.x);
        return offsetPos.x;
    }

    void manageOffset()
    {
        if (tracking)
        {
            swipeCurrentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 offsetv3 = GetSwipeOffset(swipeStartPos, swipeCurrentPos);
            transform.position = offsetv3;
            transform.rotation = Quaternion.Euler(0, 0, -offsetv3.x);
        }
        else
        {
            Vector3 offsetv3 = GetSwipeOffset(swipeStartPos * 1.5f, swipeCurrentPos * 1.5f);
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, 0), fMoveSpeed);
            transform.rotation = Quaternion.Euler(0, 0, -(offsetv3.x));
        }

    }

    void manageSwipe()
    {
        if(transform.position.x < -4f)
        {
            GameManager.gm.Swipe(this.gameObject, "Naughty");
        }
        if (transform.position.x > 4f)
        {
            GameManager.gm.Swipe(this.gameObject, "Nice");
        }
    }

    public void Hide(string dir)
    {
        Vector2 targetPos = new Vector2(0, 0);

        if (dir == "Left")
        {
            targetPos = new Vector2(-20, 0);
        }
        else
        {
            targetPos = new Vector2(20, 0);
        }

        while (true)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, 1f);
        }

    }

}
