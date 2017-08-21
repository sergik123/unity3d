using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Move : MonoBehaviour {

    [SerializeField]
    private float speed = 0.05f;
    [SerializeField]
    private int lives = 5;
    [SerializeField]
    private float jumpForce = 15f;

    private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer renderer;

    public float move=0;
    private bool isGrounded=false;

    private Camera maincamera;

    [SerializeField]
    private GameObject startpos;

    [SerializeField]
    private Sprite jumpclick;

    [SerializeField]
    private Sprite jumpidle;

    [SerializeField]
    private Sprite rightclick;

    [SerializeField]
    private Sprite rightidle;

    [SerializeField]
    private Sprite leftclick;

    [SerializeField]
    private Sprite leftidle;

    [SerializeField]
    private Sprite upclick;

    [SerializeField]
    private Sprite upidle;

    [SerializeField]
    private Sprite downclick;

    [SerializeField]
    private Sprite downidle;

    [SerializeField]
    private GameObject restart;

    [SerializeField]
    private GameObject background;

    [SerializeField]
    private Text point_ui;

    private GameObject space;
    private GameObject right;
    private GameObject left;
    private GameObject up;
    private GameObject down;

    private int jump_status = 0;

    private bool is_die = false;

    public static int points = 0;

    public SaveAndLoad saveandload;

    public Vector2 jumpforce_static;

    private float x;
    public CharState state
    {
        get { return (CharState)animator.GetInteger("state"); }
        set { animator.SetInteger("state", (int) value); }
    }
   private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
	
        maincamera = Camera.main;
        space = GameObject.Find("space");
        right = GameObject.Find("right");
        left = GameObject.Find("left");
        up = GameObject.Find("up");
        down = GameObject.Find("down");
    }
   private void FixedUpdate()
   {
       JumpState();
       StartPosition();
      
   }
   void Start()
   {
       points = 0;

       x = PlayerPrefs.GetFloat("x");
       if (x != 0)
       {
           saveandload.Load();
       }
   }
   private void Update()
   {
       point_ui.text = points.ToString();
      if(isGrounded) state = CharState.Idle;

      MoveChange();
      
      // if (Input.GetButton("Horizontal")) Run();
      // if (isGrounded && Input.GetButtonDown("Jump")) { Jump(); };
   }
   public void MoveChange()
   {
       if (move == 0)
       {
           Stop();
       }
       if (move == 1)
       {
           Right();
       }
       if (move == -1)
       {
           Left();
       }
       if (move == 3)
       {
           Down();
       }
       if (move == 4)
       {
           Up();
       }
       if (move == -5)
       {
           
           Die();
       }
      
       CameraState();
   }
   public void Right()
   {
       if (is_die==false) move = 1;
      
       transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
       transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);

       if (isGrounded) state = CharState.Walk;
       right.GetComponent<Image>().sprite = rightclick;
     
   }
   public void Left()
   {
       if (is_die == false) move = -1;

       transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
       transform.rotation = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z);

       if (isGrounded) state = CharState.Walk;
       left.GetComponent<Image>().sprite = leftclick;

   }
    public void Stop()
    {
        if (is_die == false) move = 0;
       
        jumpForce = 6;
        
        if (isGrounded)
        {
            state = CharState.Idle;
        }
        right.GetComponent<Image>().sprite = rightidle;
        left.GetComponent<Image>().sprite = leftidle;
       // down.GetComponent<Image>().sprite = downidle;
      //  up.GetComponent<Image>().sprite = upidle;
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
    }
    public void Down()
    {
        if (is_die == false) move = 3;
       
        down.GetComponent<Image>().sprite = downclick;
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x,2.37f,gameObject.transform.localScale.z);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, -4.012f, gameObject.transform.position.z);
    }
    public void Die()
    {
        
        state = CharState.Die;
       
            
        
      //  Destroy(gameObject, 3f);
        restart.SetActive(true);
        background.SetActive(true);
       
    }
    public void Restart()
    {
        // Application.LoadLevel(1);
        is_die = false;
        move = 0;
        restart.SetActive(false);
        background.SetActive(false);
         saveandload.Load();
        
    }
    public void Up()
    {
        if (is_die == false) move = 4;
        up.GetComponent<Image>().sprite = upclick;
    }
   /*public void Run()
   {
      var move1 = Input.GetAxis("Horizontal");
      move = 1;
       

       if (move1 < 0)
       {
           transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
           transform.rotation=Quaternion.Euler(transform.rotation.x,180,transform.rotation.z);
       }
       else
       {
           transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
           transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);

          
       }

      if(isGrounded) state = CharState.Walk;

      CameraState();
   }*/
   public void Jump(float states=2)
   {

       if (isGrounded && move == 0)
       {
           //jumpForce = 9;
           rigidbody.AddForce(transform.up * 9, ForceMode2D.Impulse);
           
       }
       if (isGrounded && move != 0)
       {
          // jumpForce = 36;
           rigidbody.AddForce(transform.up * 7, ForceMode2D.Impulse);
       }
        
       
   }
   private void JumpState()
   {
       Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.3F);
       isGrounded = colliders.Length > 1;
	
       if (!isGrounded)
       {
           state = CharState.Jump;
           space.GetComponent<Image>().sprite = jumpclick;
           
       }
       else
       {
           space.GetComponent<Image>().sprite = jumpidle;
          
           //up.GetComponent<Image>().sprite = upidle;
       }
   }
   private void CameraState()
   {
       if (transform.position.x > maincamera.transform.position.x)
       {
           maincamera.transform.position = new Vector3(transform.position.x, maincamera.transform.position.y, maincamera.transform.position.z);
       }
       if (maincamera.transform.position.x > 0.4)
       {
           maincamera.transform.position = new Vector3(transform.position.x, maincamera.transform.position.y, maincamera.transform.position.z);
       }
       else
       {
           maincamera.transform.position = new Vector3(0.34f, maincamera.transform.position.y, maincamera.transform.position.z);
       }
       if (transform.position.y > 0)
       {
			var vector = new Vector3 (maincamera.transform.position.x,maincamera.transform.position.y, -10);
			maincamera.transform.position = Vector3.Lerp(vector, transform.position, Time.deltaTime);
          //maincamera.transform.position = new Vector3(maincamera.transform.position.x, transform.position.y, maincamera.transform.position.z);
       }
      
       else
       {
          
               var vector = new Vector3(maincamera.transform.position.x, 0, -10);
               var vector2 = new Vector3(transform.position.x, 0, transform.position.z);
               maincamera.transform.position = Vector3.Lerp(vector, vector2, Time.deltaTime);
           
			
           
           // maincamera.transform.position = new Vector3(transform.position.x+4f, 0, maincamera.transform.position.z);
       }
   }
   private void StartPosition()
   {
       if (transform.position.y < -6)
       {
           Die();
          // transform.position = startpos.transform.position;
          // maincamera.transform.position = new Vector3(0.34f, maincamera.transform.position.y, maincamera.transform.position.z);
       }
   }
   public void Exit()
   {
       Application.Quit();
   }
	void OnTriggerEnter2D(Collider2D other){
		
		//print(other.gameObject.tag);
		if (other.gameObject.tag == "enemy1") {
          var statefor_y=transform.position.y;
		//	print ("enemy " + other.gameObject.transform.position.y);
		//	print ("player " + transform.position.y);
			if (Mathf.Abs (transform.position.y - other.gameObject.transform.position.y) < 0.5f) {
                if (transform.localScale.y > 1.25)
                {
                    transform.localScale = new Vector3(1.62f, 1.24f, 1);
                }
                else
                {
                    move = -5;
                    is_die = true;
                }
               
				//Destroy (gameObject, 1.5f);

			} else {
                try
                {
                    other.gameObject.transform.localScale = new Vector3(transform.localScale.x, 0.6f, transform.localScale.z);
                    other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, other.gameObject.transform.position.z);
                    other.enabled = false;
                    if (transform.position.y < statefor_y + 2)
                        rigidbody.AddForce(jumpforce_static, ForceMode2D.Force);
                    other.gameObject.GetComponent<AudioSource>().Play();
                    Destroy(other.gameObject, 0.5f);
                }
                catch (System.Exception)
                {
                    
                    
                }
				
			}

		}
	}
}
public enum CharState
{
    Idle,
    Walk,
    Jump,
    Die
}
