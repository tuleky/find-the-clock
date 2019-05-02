using System.Collections;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Ekle: Akrep bir tur attığında oyunu durdur, yeniden başlat
/// </summary>


public class Saat : MonoBehaviour
{
	public Transform akrepObj;
	public Transform yelkovanObj;
	public Text saatText;
	public Text basariText;
	public Text hedefText;

	public enum Panels
	{
		Hedef,
		Basari,
	}

	public GameObject[] panels;

	public int dondurmeHizi;


	private int saat = 0;
	private int dakika = 0;
	public bool dursunMu = false;




	private void Awake()
	{
		GameManager.instance.YeniHedefSaatUret();

	}

	private IEnumerator BaslatmaGeciktirme(float time)
	{
		dursunMu = true;
		yield return new WaitForSeconds(time);
		dursunMu = false;
	}

	private void Start()
	{
		HedefZamanGoster();
		StartCoroutine(BaslatmaGeciktirme(2f));
		//oyun başında ürettiğimiz rastgele saati göstermesi için saatin akrebini hare
		akrepObj.Rotate(new Vector3(0f, 0f, GameManager.instance.rastgeleSaat * -30f));
		//Debug.Log(GameManager.instance.rastgeleSaat);
	}


	private void HedefZamanGoster()
	{
		//eğer dakika 9'dan küçükse başına 0 koy
		if (GameManager.instance.rastgeleDakika > 9)
		{
			hedefText.text = GameManager.instance.rastgeleSaat + ":" + GameManager.instance.rastgeleDakika;
		}
		else if (GameManager.instance.rastgeleDakika <= 9)
		{
			hedefText.text = GameManager.instance.rastgeleSaat + ":0" + GameManager.instance.rastgeleDakika;
		}
	}

	/// <summary>
	/// Butona basıldığında saati durdurması için değişkeni true yapıyor
	/// </summary>
	public void Durdur()
	{
		if (dursunMu)
		{
			return;
		}

		dursunMu = true;

		SaatBul();
		SaatYazdir();

		//hedef saat ile durduralan saati karşılaştır
		if (Mathf.Abs(GameManager.instance.rastgeleDakika - dakika) <= 2 && GameManager.instance.rastgeleSaat == saat)
		{
			//başarılı
			basariText.text = "EXCELLENT";
		}
		else if (Mathf.Abs(GameManager.instance.rastgeleDakika - dakika) <= 5 && GameManager.instance.rastgeleSaat == saat)
		{
			//başarılı
			basariText.text = "CONGRATULATIONS";
		}
		else if (Mathf.Abs(GameManager.instance.rastgeleDakika - dakika) <= 9 && GameManager.instance.rastgeleSaat == saat)
		{
			//başarılı
			basariText.text = "YOU CAN DO BETTER";
		}
		else
		{
			basariText.text = "TRY AGAIN!";
		}

		panels[(int)Panels.Basari].SetActive(true);

		//beklet ve sonra yeniden sayı türet 

		//Debug.Log(GameManager.instance.rastgeleSaat + " " + GameManager.instance.rastgeleDakika);
	}


	private void Cevir()
	{
		if (!dursunMu)
		{
			akrepObj.Rotate(new Vector3(0f, 0f, dondurmeHizi/12f) * -Time.deltaTime);
			yelkovanObj.Rotate(new Vector3(0f, 0f, dondurmeHizi) * -Time.deltaTime);
		}
	}



	private void SaatBul()
	{
		//1 derece 2 dakika anlamına geliyor
		//360'dan dereceSaati çıkararak öncelikle elimizdeki dereceyi bulucaz
		//dereceyi 30'a bölüp bunun alt sınırındaki sayıya yuvarlayarak saat karşılığını bul
		//yine aynı derecenin 30'a bölümünden kalanıyla dakika karşılığını bul
		float saatDerecesi;

		saatDerecesi = 360 - akrepObj.rotation.eulerAngles.z;

		saat = Mathf.FloorToInt(saatDerecesi / 30);

		dakika = Mathf.FloorToInt((saatDerecesi % 30) * 2);

		if (saat == 0)
		{
			saat = 12;
			return;
		}
	}


	private void SaatYazdir()
	{
		string temp = "";
		if (!(dakika > 9))
		{
			temp = "0";
		}
		saatText.text = saat + ":" + temp + dakika;
	}


    // Update is called once per frame
    void Update()
    {
		Cevir();
    }
}
