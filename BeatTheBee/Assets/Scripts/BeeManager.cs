using UnityEngine;

public class BeeManager : MonoBehaviour
{
    [System.Serializable]
    public struct RotateIntervals
    {
        public float min;
        public float max;
    }

    [System.Serializable]
    private struct SpawnArea
    {
        public Vector2 bottomLeft;
        public Vector2 topRight;
    }

    public static BeeManager Instance { get; private set; }

    [SerializeField] private SpawnArea spawnArea;
    [SerializeField] private Bee[] bees;
    [SerializeField] private Collider2D field;
    [SerializeField] private RotateIntervals rotateInterval;
    [SerializeField] private float speed;

    public Vector2 Center { get { return (spawnArea.bottomLeft + spawnArea.topRight) * 0.5f; } }
    public Collider2D Field { get { return field; } }
    public RotateIntervals RotateInterval { get { return rotateInterval; } }
    public Bee QueenBee { get; private set; }
    public float Speed { get { return speed; } }

    private void Awake()
    {
        Instance = this;
        int queenBee = Random.Range(0, bees.Length);
        for (var i = 0; i < bees.Length; i++)
        {
            bees[i].transform.position = new Vector3(Random.Range(spawnArea.bottomLeft.x, spawnArea.topRight.x),
            Random.Range(spawnArea.bottomLeft.y, spawnArea.topRight.y), -1f);
            bees[i].transform.rotation = new Quaternion(0f, 0f, Random.Range(0f, 1f), 0f);
            bees[i].Angle = Random.Range(-180, 180);
            if (i == queenBee)
            {
                QueenBee = bees[i];
                QueenBee.IsQueen = true;
            }
        }
    }

    public void KillWithGameObjectInstanceID(int instanceID)
    {
        int number = 65535;
        for (var i = 0; i < bees.Length; i++)
        {
            if (bees[i].gameObject.GetInstanceID().Equals(instanceID))
            {
                number = i;
            }
        }
        if (number != 65535)
        {
            bees[number].Kill();
        }
    }
}