using System.Collections;
using UnityEngine;
using Fusion;
using Fusion.Sockets;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;

namespace Assets.Script
{
    /// <summary>
    /// 服务器框架
    /// </summary>
    public class NetFromWorker : MonoBehaviour, INetworkRunnerCallbacks
    {
        [SerializeField] private NetworkRunner networkRunner = null;
        [SerializeField] private NetworkPrefabRef playerPrefab;

        private Dictionary<PlayerRef, NetworkObject> playerList = new();
        private void Start()
        {
            StartGame(GameMode.AutoHostOrClient);
        }
        async private void StartGame(GameMode gameMode)
        {
            networkRunner.ProvideInput = true;
            await networkRunner.StartGame(new StartGameArgs()
            {
                GameMode = gameMode,
                SessionName = "Funsion Room",
                Scene = SceneManager.GetActiveScene().buildIndex,
                SceneManager = gameObject.AddComponent<NetworkSceneManagerDefault>()
            });
        }
        public void OnConnectedToServer(NetworkRunner runner)
        {
        }

        public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
        {
        }

        public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
        {
        }

        public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
        {
        }

        public void OnDisconnectedFromServer(NetworkRunner runner)
        {
        }

        public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
        {
        }

        public void OnInput(NetworkRunner runner, NetworkInput input)
        {
        }

        public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
        {
        }

        public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
        {
            NetworkObject networkObject = runner.Spawn(playerPrefab, Vector3.up * 2, Quaternion.identity, player);
            playerList.Add(player, networkObject);
        }

        public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
        {
            if(playerList.TryGetValue(player, out NetworkObject networkObject))
            {
                runner.Despawn(networkObject);
                playerList.Remove(player);
            }
        }

        public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data)
        {
        }

        public void OnSceneLoadDone(NetworkRunner runner)
        {
        }

        public void OnSceneLoadStart(NetworkRunner runner)
        {
        }

        public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
        {
        }

        public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
        {
        }

        public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
        {
        }
    }
}