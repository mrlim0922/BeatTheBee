using System.Collections;
using UnityEngine;

public class Bee : MonoBehaviour
{
    [System.Serializable]
    public struct Types
    {
        public string numberofWings;
        public string color;
    }

    [SerializeField] private Types type;

    private new Rigidbody2D rigidbody;
    private Transform forward;

    public int Angle { get; set; }
    public bool IsQueen { get; set; }
    public Types Type { get { return type; } }

    protected void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        forward = transform.Find("Forward");
    }

    private void Start()
    {
        StartCoroutine(RotateRandomly());
    }

    private void FixedUpdate()
    {
        rigidbody.MovePosition(Vector2.MoveTowards(transform.position, forward.position, BeeManager.Instance.Speed * Time.deltaTime));
        rigidbody.MoveRotation(Mathf.LerpAngle(transform.rotation.eulerAngles.z, Angle, Time.deltaTime * 10f));
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.Equals(BeeManager.Instance.Field))
        {
            StopAllCoroutines();
            Vector2 vector = BeeManager.Instance.Center - (Vector2)transform.position;
            Angle = -(int)(Mathf.Atan2(vector.x, vector.y) * Mathf.Rad2Deg);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.Equals(BeeManager.Instance.Field))
        {
            StartCoroutine(RotateRandomly());
        }
    }

    private IEnumerator RotateRandomly()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(BeeManager.Instance.RotateInterval.min,
                BeeManager.Instance.RotateInterval.max));
            Angle = Random.Range(-180, 180);
        }
    }

    public void Kill()
    {
        if (IsQueen)
        {
            Timer.Instance.StopAllCoroutines();
            GameUI.Instance.GameClear();
            gameObject.SetActive(false);
        }
        else
        {
            Timer.Instance.ReduceTime();
            gameObject.SetActive(false);
        }
    }
}