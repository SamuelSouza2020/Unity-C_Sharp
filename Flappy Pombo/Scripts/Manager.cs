using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public Text txt;
    public Text txt2;
    Image img;
    Button btn;

    public int Pontos = 0;
    public int life = 1;

    private void Awake()
    {
        img = GameObject.Find("GameOver").GetComponent<Image>();
        btn = GameObject.Find("Play").GetComponent<Button>();
        StartCoroutine(Desativar());
    }
    private void Start()
    {
        txt2.text = PlayerPrefs.GetInt("pontos").ToString();
    }
    private void Update()
    {
        if(life <= 0)
        {
            img.gameObject.SetActive(true);
            btn.gameObject.SetActive(true);
        }
    }    
    public void JogarNovamente()
    {
        life++;
        SceneManager.LoadScene(0);
    }
    IEnumerator Desativar()
    {
        yield return new WaitForSeconds(0.005f);
        img.gameObject.SetActive(false);
        btn.gameObject.SetActive(false);
    }
}
