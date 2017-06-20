using UnityEngine;

public class __Plane : _MonoBehaviour
{
    protected Rigidbody rb;

    //actural gravity values
    private float g = GameManager.GRAVITY_ACCEL * GameManager.GRAVITY_SCALE;
    private float j = GameManager.JUMP_FORCE * GameManager.GRAVITY_SCALE;

    protected float v = 0.0f;
    protected Vector3 pos;

    private Vector3 org;

    private float delta;
    private Vector3 v3;

    Physics physics;

    // Use this for initialization
    protected virtual void Start()
    {
        this.rb = GetComponent<Rigidbody>();
        this.org = transform.position;
        Vector3 gravity = Physics.gravity;
        gravity.y = -g;
        Physics.gravity = gravity;
        _Reset();
    }

    protected virtual void _Reset()
    {
        transform.position = this.org;
        this.pos = transform.position;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (GameManager.ActionKeyDown())
        {
            this.v3 = transform.position;
            // 속도를 0으로 초기화
            rb.velocity = Vector2.zero;
            // 상승 힘을 부여
            rb.AddForce(Vector2.up * j);
            //Debug.LogWarning(this.GetMethodName() + ">>" + (transform.position.y - v3.y).ToString("f4") + ":position.y:" + transform.position.y.ToString("f4") + ":v3.y:" + v3.y.ToString("f4"));
        }

        ////FUCK
        //float diff = (transform.position.y - this.v3.y);
        ////Debug.Log(this.GetMethodName() + ":" + diff.ToString("f4") + ":position.y:" + transform.position.y.ToString("f4") + ":v3.y:" + v3.y.ToString("f4"));
        //if (this.v3 != Vector3.zero && diff > 0.0f && diff >= (GameManager.JUMP_LIMIT / 2.0f))
        //{
        //    //Debug.LogWarning(this.GetMethodName() + "]]" + diff.ToString("f4") + ":position.y:" + transform.position.y.ToString("f4") + ":v3.y:" + v3.y.ToString("f4"));
        //    this.v3 = Vector3.zero;
        //    rb.AddForce(Vector2.up * (j / -10.0f));
        //}

        this.delta = transform.position.y - pos.y;
        this.pos = transform.position;

        PitchBird(this.delta);
    }

    protected virtual void PitchBird(float delta) { }
}
