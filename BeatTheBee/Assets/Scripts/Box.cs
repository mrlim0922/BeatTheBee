using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private int number;

    public void Attack()
    {
        if (number == 0) BoxManager.Instance.Scent.text = string.Format("날개가 {0} 쌍이다. ",
            BeeManager.Instance.QueenBee.Type.numberofWings);
        else BoxManager.Instance.Scent.text = string.Format("색깔이 {0}색이다. ", BeeManager.Instance.QueenBee.Type.color);
        GameUI.Instance.Scent.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}