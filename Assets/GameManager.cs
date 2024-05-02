using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int MaxHealth;
    public TMP_Text FruitText;
    public HealthBarBehaviour HealthBar;

    public UnityEvent OnDeath;

    [HideInInspector]
    public GameObject Player;

    private int _fruitCount;
    private int _totalFruitCount;
    private int _currentHealth;
    private int _score = 0;

    private void Awake()
    {
        // Si jamais on charge une 2e scene
        // avec un autre GameManager
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        _currentHealth = MaxHealth;

        _totalFruitCount = FindObjectsOfType<FruitBehaviour>().Length;
    }

    public void AddScore(int score)
    {
        _fruitCount++;
        _score += score;
        FruitText.text = $"Score: {_score}";

        if (_fruitCount >= _totalFruitCount)
        {
            SceneManager.LoadScene("Level2");
        }
    }

    public void RegisterFruit(FruitBehaviour fruit)
    {
        //++_totalFruitCount;
    }

    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;
        HealthBar.SetHealth(_currentHealth, MaxHealth);
        if (_currentHealth <= 0)
            OnDeath?.Invoke();
    }
}
