using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInteractionScript : MonoBehaviour
{
    [SerializeField]
    private GameObject cardBack; //Child Obj to cover Face of a Card

    public void OnMouseDown()
    {
        Debug.Log("Card was Clicked On!");

        if (cardBack.activeSelf)
        {
            cardBack.SetActive(false);
        }
    }
}
