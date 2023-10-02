using TMPro;
using UnityEngine;

namespace Memories.Meta
{
    public class MemoryShower : MonoBehaviour
    {
        [SerializeField] private GameObject panel;
        [SerializeField] private SpriteRenderer memoryShow;
        [SerializeField] private TextMeshProUGUI text;

        public void Show(Memory memory)
        {
            panel.SetActive(true);
            memoryShow.gameObject.SetActive(true);
            text.gameObject.SetActive(true);

            memoryShow.sprite = memory.Sprite;
            text.text = memory.Text;
        }

        public void Hide()
        {
            panel.SetActive(false);
            memoryShow.gameObject.SetActive(false);
            text.gameObject.SetActive(false);
        }
    }
}