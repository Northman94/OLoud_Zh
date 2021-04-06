using UnityEngine;
using System.Collections;

//Should be attached to SceneController Obj
public class SceneControllerScript : MonoBehaviour
{
    public const int gridColumns = 4;
    public const int gridRows = 2;

    public const float offset_X = 2f;
    public const float offset_Y = 2.5f;



    [SerializeField]
    private CardInteractionScript originalFaceCard; //CardFace in a Scene reference, with relevant Script on it

    [SerializeField]
    private Sprite[] images; // Array of Links to Sprite Faces



    private void Start()
    {
        Vector3 startPos = originalFaceCard.transform.position;


        for (int i = 0; i < gridColumns; i++)
        {
            for (int j = 0; j < gridRows; j++)
            {

                CardInteractionScript card;

                if (i == 0 && j == 0)
                {
                    card = originalFaceCard;
                }
                else
                {
                    card = Instantiate(originalFaceCard) as CardInteractionScript;

                }

                //Setting a random card
                int id = Random.Range(0, images.Length);
                card.SetCard(id, images[id]);


                // Moving it due on grid
                float posX = (offset_X * i) + startPos.x;
                float posY = (offset_Y * j) + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z);
            }





        }
    }



}
