using UnityEngine;

public class BoatSpriteChange : MonoBehaviour {
    // array of boat sprites
    [SerializeField] Sprite[] boatSprites;
    private Sprite curSprite;
    public void UpdateSprite(GameObject obj)
    {
        curSprite = boatSprites[1];
        obj.GetComponent<SpriteRenderer>().sprite = curSprite;
    }
}
