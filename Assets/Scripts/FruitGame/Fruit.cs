using UnityEngine;

public class Fruit : MonoBehaviour
{
    public int fruitType;
    public bool hasMerged = false;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasMerged)
            return;

        Fruit otherFruit = collision.gameObject.GetComponent<Fruit>();

        if (otherFruit != null && otherFruit.fruitType == fruitType && !otherFruit.hasMerged)
        {
            
            hasMerged = true;
            otherFruit.hasMerged = true;
            
            Vector3 mergePosition  = (transform.position + otherFruit.transform.position) / 2f;

            FruitGame gameManager = FindObjectOfType<FruitGame>();

            if (gameManager != null)
            {
                gameManager.MergeFruita(fruitType , mergePosition);
            }

            Destroy(gameObject);
            Destroy(otherFruit.gameObject);
        }
    }
}
