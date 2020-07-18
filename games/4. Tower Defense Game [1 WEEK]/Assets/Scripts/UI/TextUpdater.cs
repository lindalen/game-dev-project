using UnityEngine;
using UnityEngine.UI;

public class TextUpdater : MonoBehaviour
{
    [SerializeField] private Text textBox;

    public void UpdateTextBox(string s)
    {
        textBox.text = s;
    }
}
