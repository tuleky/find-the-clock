using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		Camera.main.backgroundColor = Random.ColorHSV();
    }
}
