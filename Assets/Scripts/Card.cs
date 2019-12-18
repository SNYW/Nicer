using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

    bool tracking;
    float fMoveSpeed;
    Vector2 swipeStartPos;
    Vector2 swipeCurrentPos;

    GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();

    void Start()
    {
        tracking = false;
        fMoveSpeed = 1f;
        swipeStartPos = new Vector2(0, 0);
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
            Debug.Log("LEFT");
        }
        if (transform.position.x > 4f)
        {
            Debug.Log("RIGHT");
        }
    }

}
