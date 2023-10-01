using System.Linq;
using UnityEngine;

namespace MiniGames.Flipper.Logic
{
    public class CardsRandomizer : MonoBehaviour
    {
        [SerializeField] private Card[] cards;
        [SerializeField] private Transform[] pivotPoints;

        public void Randomize()
        {
            var randomCards = cards.OrderBy(card => Random.value).ToArray();
            for (int i = 0; i < cards.Length; i++)
            {
                randomCards[i].gameObject.SetActive(true);
                randomCards[i].transform.position = pivotPoints[i].position;
            }
        }
    }
}