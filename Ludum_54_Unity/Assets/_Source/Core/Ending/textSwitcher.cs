using TMPro;
using UnityEngine;

namespace Core.Ending
{
    public class textSwitcher : MonoBehaviour
    {
        public TextMeshProUGUI textUI;
        public string[] texts;

        private int counter;
        
        public void Next()
        {
            textUI.text = texts[counter];
            counter++;
        }
    }
}