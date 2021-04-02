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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallControll : MonoBehaviour
{
    //posicao seta

    //seta
    public GameObject setaGo;

    //ang
    public float zRotate;
    public bool liberaRot = false;
    public bool liberaTiro = false;
    bool sonido = false;

    //Força
    private Rigidbody2D bola;
    private float force = 0;
    public GameObject seta2Img;

    //Paredes
    private Transform paredeLD, paredeLE;

    //Circulo
    private GameObject circPonto;

    //Morte Bola Anim
    [SerializeField]
    private GameObject MorteBolaAnim;

    //Bola Portal
    bool CNBall = false;
    public BoxCollider2D CanoG;



    private void Awake()
    {
        setaGo = GameObject.Find("Seta");
        seta2Img = setaGo.transform.GetChild(0).gameObject;
        setaGo.GetComponent<Image>().enabled = false;
        seta2Img.GetComponent<Image>().enabled = false;
        circPonto = GameObject.Find("CircPonto");
        paredeLD = GameObject.Find("ParedeLD").GetComponent<Transform>();
        paredeLE = GameObject.Find("ParedeLE").GetComponent<Transform>();
        if(OndeEstou.instance.fase == 18 || OndeEstou.instance.fase == 19)
        {
            CanoG = GameObject.Find("CanoSaida").GetComponent<BoxCollider2D>();
        }
    }
    void Start()
    {
        //força
        bola = GetComponent<Rigidbody2D>();
        
    }
    void Update()
    {
        PosicionaSeta();
        RotacaoSeta();
        InputDeRotacao();
        LimitaRotacao();

        //força
        ControlaForca();
        AplicaForca();

        //paredes
        Paredes();

        //pontos
        //PontosUI();
        if(CNBall == true)
        {
            StartCoroutine(Inpuls());
            CNBall = false;
        }

        //Bomba
        
    }
    void PosicionaSeta()
    {
        setaGo.GetComponent<Image>().rectTransform.position = transform.position;
    }
    void RotacaoSeta()
    {
        setaGo.GetComponent<Image>().rectTransform.eulerAngles = new Vector3(0, 0, zRotate);
    }
    void InputDeRotacao()
    {

        if (liberaRot == true)
        {

            float moveY = Input.GetAxis("Mouse Y");
            if (zRotate < 90)
            {
                if (moveY > 0)
                {
                    zRotate += 2.5f;
                }
            }
            if (zRotate > 0)
            {
                if (moveY < 0)
                {
                    zRotate -= 2.5f;
                }
            }
        }
    }
    void LimitaRotacao()
    {
        if (zRotate >= 90)
        {
            zRotate = 90;
        }
        if (zRotate <= 0)
        {
            zRotate = 0;
        }
    }
    void OnMouseDown()
    {
        sonido = true;
        if (AudioManager.instance.sonsFX.volume <= 0.3 && sonido == true)
        {
            AudioManager.instance.sonsFX.volume = 1;
            sonido = false;
        }
        if (GameManager.instance.tiro == 0)
        {
            liberaRot = true;
            setaGo.GetComponent<Image>().enabled = true;
            seta2Img.GetComponent<Image>().enabled = true;
        }
        if(OndeEstou.instance.fase == 0)
        {
            UIManager.instance.expliSeta.SetActive(false);
        }

    }
    void OnMouseUp()
    {
        liberaRot = false;
        setaGo.GetComponent<Image>().enabled = false;
        seta2Img.GetComponent<Image>().enabled = false;
        if (GameManager.instance.tiro == 0 && force > 0)
        {
            liberaTiro = true;
            seta2Img.GetComponent<Image>().fillAmount = 0;
            AudioManager.instance.SonsFXToca(1);
            GameManager.instance.tiro = 1;

            StartCoroutine(BolaOciosa());
        }
    }
    void AplicaForca()
    {
        float x = force * Mathf.Cos(zRotate * Mathf.Deg2Rad);
        float y = force * Mathf.Sin(zRotate * Mathf.Deg2Rad);

        if (liberaTiro == true)
        {
            bola.AddForce(new Vector2(x, y));
            liberaTiro = false;
        }
    }
    void ControlaForca()
    {
        if (liberaRot == true)
        {
            float moveX = Input.GetAxis("Mouse X");

            if (moveX < 0)
            {
                seta2Img.GetComponent<Image>().fillAmount += 0.8f * Time.deltaTime;
                force = seta2Img.GetComponent<Image>().fillAmount * 1000;
            }
            if (moveX > 0)
            {
                seta2Img.GetComponent<Image>().fillAmount -= 0.8f * Time.deltaTime;
                force = seta2Img.GetComponent<Image>().fillAmount * 1000;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Morte"))
        {
            Instantiate(MorteBolaAnim, transform.position, Quaternion.identity);
            Destroy(this.gameObject);

            GameManager.instance.bolasEmCena -= 1;
            GameManager.instance.bolasNum -= 1;
        }
        if (this.gameObject.layer == 0)
        {
            AudioManager.instance.SonsFXToca(1);
            if (AudioManager.instance.sonsFX.volume >= 0)
            {
                if (AudioManager.instance.sonsFX.volume >= 0.8)
                {
                    AudioManager.instance.sonsFX.volume -= 0.3f;
                }
                else if (AudioManager.instance.sonsFX.volume < 0.8)
                {
                    AudioManager.instance.sonsFX.volume -= 0.2f;
                }
            }
        }
        if(OndeEstou.instance.fase == 18 || OndeEstou.instance.fase == 19)
        {
            if (collision.gameObject.CompareTag("Portal"))
            {
                Instantiate(MorteBolaAnim, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Morte"))
        {
            Instantiate(MorteBolaAnim, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            GameManager.instance.bolasEmCena -= 1;
            GameManager.instance.bolasNum -= 1;
        }
        if(collision.gameObject.CompareTag("win"))
        {
            GameManager.instance.win = true;
            int temp = OndeEstou.instance.fase + 1;
            temp++;
            PlayerPrefs.SetInt("Level"+temp,1);

        }
        if (collision.gameObject.CompareTag("Portal"))
        {
            CNBall = true;
        }
        if (collision.gameObject.CompareTag("Key"))
        {
            UIManager.instance.shieldG.SetActive(false);
            UIManager.instance.keyG.SetActive(false);
        }
    }
    void BolaDinamica()
    {
        this.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
    }
    void Paredes()
    {
        if (this.gameObject.transform.position.x > paredeLD.position.x)
        {
            Destroy(this.gameObject);
            GameManager.instance.bolasEmCena -= 1;
            GameManager.instance.bolasNum -= 1;
        }
        if (this.gameObject.transform.position.x < paredeLE.position.x)
        {
            Destroy(this.gameObject);
            GameManager.instance.bolasEmCena -= 1;
            GameManager.instance.bolasNum -= 1;
        }
    }
    /*void PontosUI()
    {
        if(GameManager.instance.win == true)
        {
            UIManager.instance.valorStar2 = 0.333f;
            if (GameManager.instance.contBall > 1 && GameManager.instance.passouBall == true)
            {
                UIManager.instance.valorStar2 = 1;
            }
            else if(GameManager.instance.passouBall == true || GameManager.instance.contBall > 1)
            {
                UIManager.instance.valorStar2 = 0.666f;
            }
            /*else if(GameManager.instance.bolasNum > 1)
            {
                UIManager.instance.valorStar2 = 0.666f;
            }
        }
        else
        {
            UIManager.instance.valorStar2 = 0;
        }

    }*/
    IEnumerator BolaOciosa()
    {

        if (bola.velocity == new Vector2(0, 0))
        {
            yield return new WaitForSeconds(8f);

            //Instantiate(MorteBolaAnim, transform.position, Quaternion.identity);
            Destroy(this.gameObject); 
            GameManager.instance.bolasEmCena -= 1;

            GameManager.instance.bolasNum -= 1;
        }
    }
    IEnumerator Inpuls()
    {
        yield return new WaitForSeconds(1);
        this.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        bola.AddForce(new Vector2(300, 0));
        yield return new WaitForSeconds(2);
        if(OndeEstou.instance.fase > 17)
        {
            CanoG.isTrigger = false;
        }
    }
}