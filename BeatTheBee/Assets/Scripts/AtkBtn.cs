using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AtkBtn : MonoBehaviour
{
    public Image skillFilter;
    public Text coolTimeCounter; //남은 쿨타임
    public float coolTime;
    public Animator hand;

    private float currentCoolTime; //남은 쿨타임

    static public bool canAtk = false; //스킬을 사용할 수 있는지 확인하는 변수
    static public bool canAttack = true; //스킬을 사용할 수 있는지 확인하는 변수
    static public int boxInstanceID;
    static public int beeInstanceID;
    public GameObject Box;

    private void Awake()
    {
        skillFilter.fillAmount = 0;
    }

    public void Attack()
    {
        if (canAttack)
        {
            hand.Play("Punch");
            if (canAtk)
            {
                Debug.Log("Attack");
                BoxManager.Instance.AttackWithGameObjectInstanceID(boxInstanceID);
                BeeManager.Instance.KillWithGameObjectInstanceID(beeInstanceID);
                boxInstanceID = beeInstanceID = 0;
                canAtk = false;
            }
            skillFilter.fillAmount = 1;
            StartCoroutine("Cooltime");

            currentCoolTime = coolTime;
            if (currentCoolTime < coolTime)
                coolTimeCounter.text = "";
            else
                coolTimeCounter.text = "" + currentCoolTime;

            StartCoroutine("CoolTimeCounter");
            canAttack = false;
        }
        else
            Debug.Log("You can't attack now");
    }

    private IEnumerator Cooltime()
    {
        while (skillFilter.fillAmount > 0)
        {
            skillFilter.fillAmount -= 1 * Time.smoothDeltaTime / coolTime;

            yield return null;
        }

        canAttack = true; //스킬 쿨타임이 끝나면 스킬을 사용할 수 있는 상태로 바꿈

        yield break;
    }

    //남은 쿨타임
    private IEnumerator CoolTimeCounter()
    {
        while (currentCoolTime > 0)
        {
            yield return new WaitForSeconds(coolTime);

            currentCoolTime -= 1 * Time.deltaTime;
            if (currentCoolTime < coolTime)
                coolTimeCounter.text = "";
            else
                coolTimeCounter.text = "" + currentCoolTime;
        }

        yield break;
    }
}