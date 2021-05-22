using UnityEngine;


namespace Controller
{
    public class KayboardTracker : MonoBehaviour
    {
        // Publiczne pole skąd będziemy zbierać input ze strzałek
        public Vector2 Input { get; private set; } = Vector2.zero;

        private void Update()
        {
            GetInput();

        }
        public void GetInput()
        {


            Vector2 newInput = new Vector2();

            if (UnityEngine.Input.GetKey(KeyCode.W))
                newInput = Vector2.up;
            else if (UnityEngine.Input.GetKey(KeyCode.S))
                newInput = Vector2.down;

            if (UnityEngine.Input.GetKey(KeyCode.A))
                newInput = new Vector2(1, newInput.y);
            if (UnityEngine.Input.GetKey(KeyCode.D))
                newInput = new Vector2(-1, newInput.y);
            Input = newInput.normalized;

        }

    }
}