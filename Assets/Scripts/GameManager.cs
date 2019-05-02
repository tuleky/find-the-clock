using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public static GameManager instance = null;


	public int rastgeleSaat;
	public int rastgeleDakika;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);

	}

	public void Play()
	{
		SceneManager.LoadScene(1);
	}

	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	//private int temp;

	public void YeniHedefSaatUret()
	{
		rastgeleSaat = Random.Range(1, 12);
		int temp = Random.Range(0, 60);
		if (temp > 9)
		{
			rastgeleDakika = temp;
		}
		else
		{
			rastgeleDakika = 01;
		}
	}
}
