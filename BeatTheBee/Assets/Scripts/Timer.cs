using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Timer Instance { get; private set; }

    [SerializeField] private int timeReduction;
    [SerializeField] private Text time;

    private int timeLeft = 180;
    private WaitForSeconds delay = new WaitForSeconds(1f);

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartCoroutine(StartUp());
    }

    private IEnumerator StartUp()
    {
        while (true)
        {
            yield return delay;
            timeLeft--;
            time.text = string.Format("{0:0}:{1:00}", timeLeft / 60, timeLeft % 60);
            if (timeLeft <= 0)
            {
                break;
            }
        }
        GameUI.Instance.GameOver();
    }

    public void ReduceTime()
    {
        timeLeft -= timeReduction;
        time.text = string.Format("{0:0}:{1:00}", timeLeft / 60, timeLeft % 60);
    }
}