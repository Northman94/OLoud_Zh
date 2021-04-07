using System.Collections;
using UnityEngine;

// Could use UI > Button (On Canvas)
public class RestartButtonScript : MonoBehaviour
{
    [SerializeField]
    private GameObject targetObject; //SceneController Obj
    [SerializeField]
    private string targetMessage;

    public Color highlightColor = Color.cyan;


    public void OnMouseEnter()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();

        if (sprite != null)
        {
            sprite.color = highlightColor;
        }
    }

    public void OnMouseExit()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();

        if (sprite != null)
        {
            sprite.color = Color.white;
        }
    }

    // Changing Button Size
    public void OnMouseDown()
    {
        transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
    }

    public void OnMouseUp()
    {
        transform.localScale = Vector3.one;

        if (targetObject != null)
        {
            targetObject.SendMessage(targetMessage);
            // Target Message is wtitten in Inspector &
            // is a Name of a Restart() in SceneControllerScript
        }
    }







}
