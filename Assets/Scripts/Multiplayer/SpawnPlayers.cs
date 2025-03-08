using UnityEngine;
using Photon.Pun;
using Unity.Cinemachine;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    public CinemachineCamera cineCamera;

    //public Vector2 spawnPos;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    void Start()
    {
        Vector2 randomPos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        GameObject player = PhotonNetwork.Instantiate(playerPrefab.name, randomPos, Quaternion.identity);

        if (player != null)
        {
            cineCamera.Follow = player.transform;
        }

    }


}
