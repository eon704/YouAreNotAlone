using UnityEngine;

namespace Player {
    public class PlayerMovement : MonoBehaviour {

        [SerializeField] private float speed = 1f;
        [SerializeField] private Rigidbody2D rb2d;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void FixedUpdate()
        {
            Vector2 input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            if (input.sqrMagnitude > 1f) {
                input = input.normalized;
            }
            Vector2 move = input * this.speed * Time.fixedDeltaTime;
            this.rb2d.MovePosition(move + this.rb2d.position);
        }
    }
}
