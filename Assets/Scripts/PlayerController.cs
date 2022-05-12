using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;



public class PlayerController : MonoBehaviour
{
    public Rigidbody Player;
    public float speed = 1000f;
    private int score = 0;
    public int health = 5;
    public Text scoreText;
    public Text healthText;
    public Text winLoseText;
    public Image winLoseBG;
    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey("w"))
        {
            Player.AddForce(0, 0, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey("s"))
        {
            Player.AddForce(0, 0, -speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d"))
        {
            Player.AddForce(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a"))
        {
            Player.AddForce(-speed * Time.deltaTime, 0, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Pickup")
        {
            score = score + 1;
            // Debug.Log("Score: " + score);
            SetScoreText();
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag == "Trap")
        {
            health = health - 1;
            // Debug.Log("Health: " + health);
            SetHealthText();
        }
        if(other.gameObject.tag == "Goal")
        {
            winLoseText.color = Color.black;
            winLoseText.text = "You Win!";
            winLoseBG.color = Color.green;
            winLoseBG.gameObject.SetActive(true);
            StartCoroutine(LoadScene(3));
        }
            //Debug.Log("You win!");
    }
    

    void SetScoreText()
    {
        scoreText.text = $"Score: {score}";
    }

    void SetHealthText()
    {
        healthText.text = $"Health: {health}";
    }

    void Update()
    {
        if (health == 0)
        {
            winLoseText.color = Color.white;
            winLoseText.text = "Game Over!";
            winLoseBG.color = Color.red;
            winLoseBG.gameObject.SetActive(true);
            StartCoroutine(LoadScene(3));

            //Debug.Log("Game Over!");
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu");
        }
    }

    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
