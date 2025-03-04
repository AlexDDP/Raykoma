using UnityEngine;

public class BoatSpriteChange : MonoBehaviour
{
    [SerializeField] Sprite[] boatSprites;
    [SerializeField] GameObject firePrefab; // Prefab for the fire sprite
    private Sprite curSprite;
    private GameObject fireInstance;

    public void UpdateSprite(GameObject obj)
    {
        // Change the boat sprite
        curSprite = boatSprites[1];
        obj.GetComponent<SpriteRenderer>().sprite = curSprite;

        // Add the fire sprite
        if (fireInstance == null)
        {
            fireInstance = Instantiate(firePrefab, obj.transform);
            fireInstance.transform.localPosition = Vector3.zero; // Adjust position as needed
        }
    }
}
