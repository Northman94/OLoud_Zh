using UnityEngine;
using System.Collections;

// Should be attached to core FaceCar Obj
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

        if (cardBack.activeSelf && controller.canReveal)
        {
            cardBack.SetActive(false);
            controller.CardRevealed(this); //Informing controller of card opening
        }
    }

    // Close card if pair matching Failed
    public void Unreveal()
    {
        cardBack.SetActive(true);
    }
}
