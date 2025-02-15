using UnityEngine;

public class CoinBehavior : MonoBehaviour
{

    private void OnEnable()
    {
        transform.localPosition = new Vector2(transform.localPosition.x, Random.Range(-2.2f, -0.1f));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DataManager.Instance.coins++;
            DataManager.Instance.SaveData();
            Destroy(gameObject);
        }
    }
}