using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class GameManager : MonoBehaviour
{

    public static GameManager gm;

    DeckManager dm;
    bool playerGuess;

    public Card minimumGoodStats;

    [SerializeField]
    public TextAsset boynamedata;
    [SerializeField]
    public TextAsset girlnamedata;

    public List<string> boyfirstNames;
    public List<string> girlfirstNames;

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
        string[] boynamelines = boynamedata.ToString().Split('\n');
        foreach(string s in boynamelines)
        {
            string ss = Regex.Replace(s, "[^\\w\\._]", "");
            boyfirstNames.Add(ss);
        }
        string[] girlnamelines = girlnamedata.ToString().Split('\n');
        foreach (string s in girlnamelines)
        {
            string ss = Regex.Replace(s, "[^\\w\\._]", "");
            girlfirstNames.Add(ss);
        }

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
            playerGuess = false;
        }
        else
        {
            cc.Hide("Right");
            playerGuess = true;
        }

        if(playerGuess == cc.nice)
        {
            Debug.Log("Correct");
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
