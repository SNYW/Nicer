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
        Invoke("GetNextCard", 0.5f);
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
        Destroy(cc.gameObject, 1f);

        Invoke("GetNextCard", 0.2f);

    }

    public void GetNextCard()
    {
       GameObject c = (GameObject)dm.Deck.Dequeue();
        c.SetActive(true);
    }

}
