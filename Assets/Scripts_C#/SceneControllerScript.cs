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


    private CardInteractionScript _firstRevealed;
    private CardInteractionScript _secondRevealed;

    private int _score = 0;


    //Property returns False if second card is opened
    public bool canReveal 
    {
        get { return _secondRevealed == null; }
    }



    private void Start()
    {
        Vector3 startPos = originalFaceCard.transform.position;


        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3}; // Card pairs IDs Array
        numbers = ShuffleArray(numbers);


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


                //Setting a random card from shuffled Card pairs IDs Array
                int index = j * gridColumns + i;
                int id = numbers[index];

                //int id = Random.Range(0, images.Length);
                card.SetCard(id, images[id]);


                // Moving it due on grid
                // Original card is in lower-left corner
                float posX = (offset_X * i) + startPos.x;
                float posY = (offset_Y * j) + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z);
            }
        }
    }


    // Fisher–Yates shuffle variation (вариация тасования Фишера-Йетса)
    private int[] ShuffleArray(int[] numbers)
    {
        int[] newArray = numbers.Clone() as int[];


        for (int h = 0; h < newArray.Length; h++)
        {
            int tmp = newArray[h];

            int r = Random.Range(h, newArray.Length);

            newArray[h] = newArray[r];

            newArray[r] = tmp;
        }
        return newArray;
    }



    public void CardRevealed(CardInteractionScript card)
    {
        if (_firstRevealed == null)
        {
            _firstRevealed = card;
        }
        else
        {
            _secondRevealed = card;

            Debug.Log("Match? " + (_firstRevealed.id == _secondRevealed.id));

            StartCoroutine(CheckMatch());
        }
    }


    private IEnumerator CheckMatch()
    {
        if (_firstRevealed.id == _secondRevealed.id)
        {
            _score++;
            Debug.Log("Score: " + _score);
        }
        else
        {
            yield return new WaitForSeconds(0.5f);

            _firstRevealed.Unreveal();
            _secondRevealed.Unreveal();
        }
        _firstRevealed = null;
        _secondRevealed = null;
    }



















}
