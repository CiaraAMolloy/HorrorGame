using UnityEngine;
using UnityEngine.UI;

public class SpeedHUD : MonoBehaviour
{
    public Slider speedSlider;
    public Image fillImage;
    public GameObject player;

    public Color minColor = Color.green;     
    public Color maxColor = Color.yellow;

    private StarterAssets.FirstPersonController fpc; 

    void Start()
    {
        if (player != null)
        {
            fpc = player.GetComponent<StarterAssets.FirstPersonController>();
        }
    }

    void Update()
    {
        if (fpc == null) return;

        
        float speed = fpc.GetComponent<CharacterController>().velocity.magnitude;

        
        if (speedSlider != null)
        {
            speedSlider.value = speed;

            // Get normalized value (0 → 1 across min/max)
            float t = speedSlider.normalizedValue;

            // Lerp color between green → yellow
            if (fillImage != null)
            {
                fillImage.color = Color.Lerp(minColor, maxColor, t);
            }
        }

    }
}
