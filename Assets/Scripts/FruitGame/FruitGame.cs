using UnityEngine;

public class FruitGame : MonoBehaviour
{
    public GameObject[] fruitPrefabs;
    public float[] fruitSize = { 0.5f, 0.75f, 1f, 1.25f, 1.5f, 1.7f, 1.9f };

    public GameObject currentFruit;
    public int currentFruitType;

    public float fruitStartHeight = 5.0f;
    public float gameWidth = 6.0f;
    public bool isGameOver = false;
    public Camera mainCamera;

    public float fruitTimer;

    void SpawnnewFruit()
    {
        if (isGameOver)
            return;
        currentFruitType = Random.Range(0, 3);

        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);

        Vector3 spawnPosition = new Vector3(worldPosition.x, fruitStartHeight, 0);

        float halfFruitSize = fruitSize[currentFruitType] / 2f;

        spawnPosition.x = Mathf.Clamp(spawnPosition.x, -gameWidth / 2f + halfFruitSize, gameWidth / 2f - halfFruitSize);

        currentFruit = Instantiate(fruitPrefabs[currentFruitType], spawnPosition, Quaternion.identity);
        currentFruit.transform.localScale = new Vector3(fruitSize[currentFruitType], fruitSize[currentFruitType], 1);

        Rigidbody2D rb = currentFruit.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.gravityScale = 0.0f;
        }
    }

    void Start()
    {
       mainCamera = Camera.main;
        SpawnnewFruit();
        fruitTimer = -3.0f;
    }

    void DropFruit()
    {
        Rigidbody2D rb = currentFruit.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = 1.0f;
            currentFruit = null;
            fruitTimer = 1.0f;
        }
    }

    public void MergeFruita(int fruitType, Vector3 position)
    {
        if (fruitType < fruitPrefabs.Length -1)
        {
            GameObject newFruit = Instantiate(fruitPrefabs[fruitType + 1], position, Quaternion.identity);
            newFruit.transform.localScale = new Vector3(fruitSize[fruitType + 1], fruitSize[fruitType + 1], 1.0f);
        }
    }

    void Update()
    {
        if (isGameOver)
            return;
        if (fruitTimer >= 0)
        {
            fruitTimer -= Time.deltaTime;
        }

        if ( fruitTimer < 0 && fruitTimer > -2)
        {
            SpawnnewFruit();
            fruitTimer = -3.0f;
        }

        if ( currentFruit != null)
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);

            Vector3 newPosition = currentFruit.transform.position;

            newPosition.x = worldPosition.x;

            float halfFruitSize = fruitSize[currentFruitType] / 2f;

            if (newPosition.x > gameWidth / 2f + halfFruitSize)
            {
                newPosition.x = gameWidth / 2f + halfFruitSize;
            }

            currentFruit.transform.position = newPosition;
        }

        if (Input.GetMouseButtonDown(0) && fruitTimer == -3.0f)
        {
            DropFruit();
        }
    }
}
