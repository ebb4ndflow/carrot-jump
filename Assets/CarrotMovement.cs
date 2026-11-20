using UnityEngine;

public class CarrotMovement : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float jumpStrength;
    private Vector3 rotationSpeed;
    public LogicScript logic;
    public bool gameNotOver = true;

    void Start()
    {
        rotationSpeed = new Vector3(
            Random.Range(-90f, 90f),
            Random.Range(-180f, 180f),
            Random.Range(-90f, 90f)
        );
         logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && gameNotOver)
        {
            myRigidbody.linearVelocity = Vector2.up * jumpStrength;
        }
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        gameNotOver = false;
    }
}
