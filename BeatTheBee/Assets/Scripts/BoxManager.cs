using UnityEngine;
using UnityEngine.UI;

public class BoxManager : MonoBehaviour
{
    [System.Serializable]
    private struct SpawnArea
    {
        public Vector2 bottomLeft;
        public Vector2 topRight;
    }

    [SerializeField] private SpawnArea spawnArea;
    [SerializeField] private Box[] boxes;
    [SerializeField] private Text scent;

    public static BoxManager Instance { get; private set; }
    public Text Scent { get { return scent; } }

    private void Awake()
    {
        Instance = this;

        for (var i = 0; i < boxes.Length; i++)
        {
            boxes[i].transform.position = new Vector3(Random.Range(spawnArea.bottomLeft.x, spawnArea.topRight.x),
                Random.Range(spawnArea.bottomLeft.y, spawnArea.topRight.y), -1f);
        }
    }

    public void AttackWithGameObjectInstanceID(int instanceID)
    {
        int number = 65535;
        for (var i = 0; i < boxes.Length; i++)
        {
            if (boxes[i].gameObject.GetInstanceID().Equals(instanceID))
            {
                number = i;
            }
        }
        if (number != 65535)
        {
            boxes[number].Attack();
        }
    }
}