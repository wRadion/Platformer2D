using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class FruitBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            Destroy(gameObject);
    }
}
