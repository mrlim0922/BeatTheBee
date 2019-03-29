using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    //singleton

    public static GameManager Instance
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

    public float moveSpeed = 1f;
    public float currentSpeed;
}