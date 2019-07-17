using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CardChest : MonoBehaviour
{
    public GameObject ChestUI;
    public List<Card> CardTypes = new List<Card>();
    public List<ChestSlot> chestSlots = new List<ChestSlot>();

    [SerializeField]
    private Player player;
    private void Awake()
    {
        ChestUI.SetActive(false);
        if (chestSlots.Count == 0) return;
        foreach (ChestSlot slot in chestSlots.ToList())
        {
            slot.OfferedCard = CardTypes[Random.Range(0, CardTypes.Count)];
            slot.CardPicked.AddListener(CardChosen);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.GetComponent<Player>())
        {
            if(player == null) player = collision.GetComponent<Player>();
            if(!ChestUI.activeSelf) ChestUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            ChestUI.SetActive(false);
            player = null;
        }
    }

    void CardChosen(Card chosenCard)
    {
        Debug.Log("Card picked");
        player.GetComponent<CardThrow>().Deck.AddCard(chosenCard);
        Destroy(gameObject);
    }
}
