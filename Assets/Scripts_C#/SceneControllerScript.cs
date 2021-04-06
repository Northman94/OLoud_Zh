using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Should be attached to SceneController Obj
public class SceneControllerScript : MonoBehaviour
{
    [SerializeField]
    private CardInteractionScript oiginalFaceCard; //CardFace in a Scene reference, with relevant Script on it


    [SerializeField]
    private Sprite[] images; // Array of Links to Sprites

    private void Start()
    {
        int id = Random.Range(0, images.Length);

        oiginalFaceCard.SetCard(id, images[id]);
    }


}
