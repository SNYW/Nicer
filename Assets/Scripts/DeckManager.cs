using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    Queue Deck = new Queue();

    [SerializeField]
    GameObject deckHolder;
    [SerializeField]
    GameObject cardPrefab;
    [SerializeField]
    int deckSize;
    [SerializeField]
    int ruleAmount;

    void Start()
    {
        deckHolder = GameObject.Find("Deck");
        InitialiseDeck();
    }

    public void InitialiseDeck()
    {
        for(int i = 0; i < deckSize; i++)
        {           
            GameObject c = Instantiate(cardPrefab, deckHolder.transform);
            c.SetActive(false);
            Deck.Enqueue(c);
        }
    }


}
