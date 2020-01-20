using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

 public class Gamecontrol : MonoBehaviour
{
    public static Gamecontrol gameControl; //VARIÁVEL QUE REFERENCIA A CLASSE. PADRÃO SINGLETON. ATRAVÉS DELA ACESSAMOS AS VARIÁVEIS PÚBLICAS
    public GameObject gameOverText;
  
    public bool gameOver = false;
    public float scrollSpeed = 1.5f;

    public Text scoreText; //VARIÁVEI PARA ATUALIZAR O TEXTO DE PONTUANÇÃO
    private int score = 0; //VARIÁVEL DA PONTUANÇÃO


    // Start is called before the first frame update
    void Awake()       // AWAKE ACONTECE ANTES DO START. GARANTE QUE O GAMECONTROL TENHAM SUAS VARIÁVEIS INICIANDO ANTES DOS OUTROS OBJETOS
    {
        if (gameControl == null) //SE NÃO HOUVER NENHUM GAMECONTROL, ESTE OBJETO SE TORNA O GAMECONTROL
            gameControl = this;
       
        else if (gameControl != this) //SE JÁ HOUVER UM GAMERCONTROLLER, DESTROI ESTE OBJETO E GARANTE SÓ UM GAMECONTROL EM CENA.
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //CLASSE SCENEMANAGER, CHAMA FUNÇÃO LOADSCENE. ATRAVÉS DA CLASSE, PEGA A CENA ATIVA E CARREGA SEU BUILDINDEX.

        }
    }

    public void BirdScore()
    {
        if (gameOver)
        {
            return;
        }

        score++;
        scoreText.text = "Pontos: " + score.ToString(); //score é um variável tipo int, então usa-se a função ToString para transformá-la.
    }

    public void BirdDie()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }
}
