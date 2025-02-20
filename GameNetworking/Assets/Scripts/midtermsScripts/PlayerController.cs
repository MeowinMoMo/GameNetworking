using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviourPunCallbacks
{
    public float moveSpeed = 5f;
    private Renderer playerRenderer;

    private void Start()
    {
        playerRenderer = GetComponent<Renderer>();

        if (photonView.IsMine)
        {
            Color randomColor = new Color(Random.value, Random.value, Random.value);
            photonView.RPC("ChangeColor", RpcTarget.AllBuffered, randomColor.r, randomColor.g, randomColor.b);
        }
    }

    [PunRPC]
    private void ChangeColor(float r, float g, float b)
    {
        if (playerRenderer == null)
            playerRenderer = GetComponent<Renderer>(); // Ensure renderer is assigned

        playerRenderer.material.color = new Color(r, g, b);
    }

    private void Update()
    {
        if (photonView.IsMine)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            transform.Translate(movement * moveSpeed * Time.deltaTime);
        }
    }
}
