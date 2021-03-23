using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rig;

    public GameObject Gp;
    Manager mng;

    void Start()
    {
        mng = FindObjectOfType<Manager>();
        rig = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //rig.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
            rig.velocity = Vector2.up * 4;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("chao"))
        {
            Gp.SetActive(false);
            mng.life--;
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ponto"))
        {
            mng.Pontos++;
            if(PlayerPrefs.GetInt("pontos") == 0)
            {
                PlayerPrefs.SetInt("pontos", mng.Pontos);
            }
            else if(mng.Pontos >= PlayerPrefs.GetInt("pontos"))
            {
                PlayerPrefs.SetInt("pontos", mng.Pontos);
            }
            mng.txt.text = mng.Pontos.ToString();
        }
    }
}
