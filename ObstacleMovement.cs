using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleMovement : MonoBehaviour
{
private float moveSpeed = 2.5f;  
int currentLevelIndex;

void Start()
{
    currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
       
       
    if (currentLevelIndex == 1)
        {
            moveSpeed = 2.2f;  
        }
     if (currentLevelIndex == 2)
        {
            moveSpeed = 3.2f;  
        }
}
    void Update()
    {


        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        if (transform.position.x < -10f)  
        {
            Destroy(gameObject);
        }
    }

}
