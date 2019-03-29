using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Image skillFilter;
    public Text coolTimeCounter; //남은 쿨타임

    public float coolTime;

    private float currentCoolTime; //남은 쿨타임

    private bool canUseSkill = true; //스킬을 사용할 수 있는지 확인하는 변수

    private void Awake()
    {
        skillFilter.fillAmount = 0;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (canUseSkill)
        {
            Debug.Log("Use Skill");
            GameManager.Instance.currentSpeed *= 10;
            skillFilter.fillAmount = 1;
            StartCoroutine("Cooltime");

            currentCoolTime = coolTime;
            if (currentCoolTime == 0)
                coolTimeCounter.text = "";
            else
                coolTimeCounter.text = "" + currentCoolTime;

            StartCoroutine("CoolTimeCounter");

            canUseSkill = false; //스킬을 사용하면 사용할 수 없는 상태로 바꿈
        }
        else
        {
            Debug.Log("아직 스킬을 사용할 수 없습니다.");
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        GameManager.Instance.currentSpeed = GameManager.Instance.moveSpeed;
    }

    private IEnumerator Cooltime()
    {
        while (skillFilter.fillAmount > 0)
        {
            skillFilter.fillAmount -= 1 * Time.smoothDeltaTime / coolTime;

            yield return null;
        }

        canUseSkill = true; //스킬 쿨타임이 끝나면 스킬을 사용할 수 있는 상태로 바꿈

        yield break;
    }

    //남은 쿨타임
    private IEnumerator CoolTimeCounter()
    {
        while (currentCoolTime > 0)
        {
            yield return new WaitForSeconds(1.0f);

            currentCoolTime -= 1.0f;
            if (currentCoolTime == 0)
                coolTimeCounter.text = "";
            else
                coolTimeCounter.text = "" + currentCoolTime;
        }

        yield break;
    }
}