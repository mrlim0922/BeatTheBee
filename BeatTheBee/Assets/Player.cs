using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("isColl");
        if (coll.CompareTag("Box"))
        {
            Debug.Log("Box");
            AtkBtn.boxInstanceID = coll.gameObject.GetInstanceID();
            AtkBtn.canAtk = true;
        }
        if (coll.CompareTag("Bee"))
        {
            Debug.Log("Bee");
            AtkBtn.beeInstanceID = coll.gameObject.GetInstanceID();
            AtkBtn.canAtk = true;
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        AtkBtn.canAtk = false;
    }
}