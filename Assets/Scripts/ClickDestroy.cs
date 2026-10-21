using UnityEngine;
using UnityEngine.EventSystems;

public class ClickDestroy : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private int scoreValue = 100;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (ScoreSystem.Instance != null)
            {
                ScoreSystem.Instance.AddScore(scoreValue);
            }
            else
            {
                Debug.LogWarning("ScoreManager instance missing in the scene!");
            }

            Destroy(gameObject);
        }
    }
}
