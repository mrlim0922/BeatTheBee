using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private static UIManager instance;

    //singleton

    public static UIManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else DestroyObject(gameObject);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        GameManager.Instance.currentSpeed *= 10;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        GameManager.Instance.currentSpeed = GameManager.Instance.moveSpeed;
    }
}