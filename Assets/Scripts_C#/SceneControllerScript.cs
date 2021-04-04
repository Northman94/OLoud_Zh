using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControllerScript : MonoBehaviour
{
    [SerializeField]
    private CardInteractionScript oiginalCArd; //Card in a Scene reference

    [SerializeField]
    private Sprite[] images; // Array of Links to Sprites


    private void Start()
    {
        int id = Random.Range(0, images.Length);

        oiginalCArd.SetCard(id, images[id]);
    }
}
