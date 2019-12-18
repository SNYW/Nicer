using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager gm;

    DeckManager dm;

    void init()
    {
        if(gm != null)
        {
            gm = null;
            gm = this.gameObject.GetComponent<GameManager>();
        }
        else
        {
            gm = this.gameObject.GetComponent<GameManager>();
        }

        dm = GetComponent<DeckManager>();

    }

    void Awake()
    {
        init();
    }

    void Start()
    {
        dm.InitialiseDeck();
    }

    public void Swipe(GameObject c, string decision)
    {

        Card cc = c.GetComponent<Card>();

        if (decision=="Naughty")
        {
            cc.Hide("Left");
        }
        else
        {
            cc.Hide("Right");
        }
    }
}
