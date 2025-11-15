using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Quiz_Manager : MonoBehaviour
{

    public List<soru_cevap> S_C;
    public GameObject[] options;
	// Unity Editor'da atayabileceğiniz ScriptableObject
    public PlayerData playerData; 

    public int current_Question;
    public int toplam_soru;
	public string sceneName;

    public Text QuestionText;
    public Text Score;


    // Start is called before the first frame update
    void Start()
    {
        soru_uret();
        toplam_soru = S_C.Count;
    }

    void soru_uret()
    {
        if (S_C.Count > 0)
        {
            current_Question = UnityEngine.Random.Range(0, S_C.Count);
            Debug.Log(current_Question);
            QuestionText.text = S_C[current_Question].Question;
            SetAnswers();
            S_C.RemoveAt(current_Question);
        }
        else
        {
            Debug.Log("Sınav Bitti");
            GameOver();
        }

    }
    public void Retry()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    void GameOver()
    {
        // Quiz tamamlandığında veya iptal edildiğinde oyun sahnesine geri dön
        //GameManager.instance.LoadGameScene();
		
    }
    public void Right()
    {
        //playerData.cevaplanan_soru.Add(current_Question);            
		//playerData.dogru_sayisi++;
		sceneName=playerData.level;
        SceneManager.LoadScene(sceneName);
        //soru_uret();
    }
    public void Wrong()
    {
        playerData.cevaplanan_soru.Add(current_Question);            
		playerData.yanlis_sayisi++;
 		sceneName=playerData.level;
		SceneManager.LoadScene(sceneName);
        //soru_uret();
    }
    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<cevap>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = S_C[current_Question].Answers[i];

            if (S_C[current_Question].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<cevap>().isCorrect = true;

            }

        }


    }

}
