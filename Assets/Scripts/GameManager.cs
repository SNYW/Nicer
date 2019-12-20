using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Text.RegularExpressions;
using System;

public class GameManager : MonoBehaviour
{

    public static GameManager gm;

    DeckManager dm;
    bool playerGuess;

    public Card minimumGoodStats;

    //Text areas for minimum criteria
    public TextMeshProUGUI minimumDetentionText;
    public TextMeshProUGUI avgGradeText;
    public TextMeshProUGUI timeOutsText;

    [SerializeField]
    public TextAsset boynamedata;
    [SerializeField]
    public TextAsset girlnamedata;

    public List<string> boyfirstNames;
    public List<string> girlfirstNames;

    private string grades;
    public String[] gradesInOrder;

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
        grades = "A B C D E F";
        gradesInOrder = grades.Split(' ');
        GenerateMinimumGoodStats();
        dm.InitialiseDeck();
        Invoke("GetNextCard", 0.5f);
       
    }

    private void Update()
    {
        if(dm.Deck.Count < 3)
        {
            dm.InitialiseDeck();
        }
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
    
    private void GenerateMinimumGoodStats()
    {
        minimumGoodStats.ResetCard();
        minimumGoodStats.detentionTimes = UnityEngine.Random.Range(1, 50);
        minimumDetentionText.SetText(minimumGoodStats.detentionTimes.ToString());
        minimumGoodStats.avgGrade =UnityEngine.Random.Range(0, gradesInOrder.Length);
        avgGradeText.SetText(gradesInOrder[minimumGoodStats.avgGrade]);
        minimumGoodStats.timeOuts = UnityEngine.Random.Range(1, 50);
        timeOutsText.SetText(minimumGoodStats.detentionTimes.ToString());
    }

}
