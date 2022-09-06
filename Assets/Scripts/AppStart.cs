using Assets.Scripts.Control;
using Assets.Scripts.View;
using Asteroids;
using UnityEngine;

namespace Assets.Scripts
{
    public class AppStart: MonoBehaviour
    {
        public GameObject _playerPrefab;
        private DebugController _debugController;
        private DebugModel _debugModel;

        public void Start()
        {
            _debugModel = new DebugModel();

            var playerObject = Instantiate(_playerPrefab, Vector3.zero, Quaternion.identity);
            var playerView = playerObject.GetComponent<DebugView>();

            _debugController = new DebugController(playerView, _debugModel);
        }
    }
}
