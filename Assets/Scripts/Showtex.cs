using UnityEngine;
using UnityEngine.UI;  // Required to access UI elements

public class ShowButtonOnClick : MonoBehaviour
{
    public GameObject buttonToShow;  // Reference to the button we want to show

    // This function will be called when the first button is clicked
    public void ShowButton()
    {
        // Enable the second button to make it visible
        buttonToShow.SetActive(true);
    }
}
