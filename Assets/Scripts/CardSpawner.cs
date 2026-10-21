using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.RuleTile.TilingRuleOutput;

/// <summary>
/// Will hold a list of all the flies that exist in the scene
/// </summary>
public class flySpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefabToSpawn;
    [SerializeField] private RectTransform canvasParent;  // The Canvas Panel transform
    [SerializeField] private float flyMoveSpeed = 30f;

    private void Start()
    {
        // Start the loop when the game begins
        StartCoroutine(ThreeSecondLoop());
    }
    private IEnumerator ThreeSecondLoop()
    {
        // while(true) creates an infinite loop, but the "yield" 
        // prevents it from crashing your game.
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(.3f);
        }
    }

    public void Spawn()
    {
        // Place the code you want to run here
        Debug.Log("This message prints every 3 seconds");
        GameObject image = Instantiate(prefabToSpawn, canvasParent);
        RectTransform rectTransform = image.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(0f, 0f);
        rectTransform.localScale = Vector3.one;
        float canvasWidth = canvasParent.rect.width;
        float canvasHeight = canvasParent.rect.height;
        float randomX = Random.Range(-canvasWidth / 2f, canvasWidth / 2f);
        float randomY = Random.Range(-canvasHeight / 2f, canvasHeight / 2f);
        rectTransform.anchoredPosition = new Vector2(randomX, randomY);
        StartCoroutine(FlyAround(rectTransform));
    }

    private IEnumerator FlyAround(RectTransform fly)
    {
        while (fly != null)
        {
            yield return new WaitForSeconds(Random.Range(0.2f, 0.6f));

            float halfWidth = Mathf.Max(0f, (canvasParent.rect.width - fly.rect.width) / 2f);
            float halfHeight = Mathf.Max(0f, (canvasParent.rect.height - fly.rect.height) / 2f);
            Vector2 target = new Vector2(
                Random.Range(-halfWidth, halfWidth),
                Random.Range(-halfHeight, halfHeight));

            while (fly != null && Vector2.Distance(fly.anchoredPosition, target) > 0.1f)
            {
                fly.anchoredPosition = Vector2.MoveTowards(
                    fly.anchoredPosition,
                    target,
                    Mathf.Max(1f, flyMoveSpeed) * Time.deltaTime);
                yield return null;
            }
        }
    }
}
