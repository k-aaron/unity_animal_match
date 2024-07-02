using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Card : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer cardRenderer;

    [SerializeField]
    private Sprite animalSprite;

    [SerializeField]
    private Sprite backSprite;

    private bool isFlipped = false;
    private bool isFlipping = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FlipCard()
    {
        isFlipping = true;

        // Scale to 0 (on X axis))
        Vector3 originalScale = transform.localScale;
        Vector3 targetScale = new Vector3(0f, originalScale.y, originalScale.z);
        
        transform.DOScale(targetScale, 0.2f).OnComplete(() => 
        {
            isFlipped = !isFlipped;

            if (isFlipped)
            {
                cardRenderer.sprite = animalSprite;
            }
            else
            {
                cardRenderer.sprite = backSprite;
            }

            transform.DOScale(originalScale, 0.2f).OnComplete(() => 
            {
                isFlipping = false;
            });
        });
    }

    void OnMouseDown()
    {
        if (!isFlipping)
            FlipCard();
    }
}
