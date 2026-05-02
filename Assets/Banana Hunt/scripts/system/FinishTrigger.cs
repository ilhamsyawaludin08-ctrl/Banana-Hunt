using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            int finalScore = FindObjectOfType<ScoreManager>().score;
            FindObjectOfType<FinishManager>().ShowFinish(finalScore);
        }
    }
}