using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInteractionScript : MonoBehaviour
{
    [SerializeField]
    private SceneControllerScript controller; //SceneController Obj, with relevant Script on it

    [SerializeField]
    private GameObject cardBack; //Child Obj (CardBack) to cover Face of a Card

    private int _id;



    public int id
    {
        get { return _id; }
    }

    public void SetCard(int id, Sprite image)
    {
        _id = id;

        GetComponent<SpriteRenderer>().sprite = image;
    }
 

    public void OnMouseDown()
    {
        Debug.Log("Card was Clicked On!");

        if (cardBack.activeSelf)
        {
            cardBack.SetActive(false);
        }
    }
}
