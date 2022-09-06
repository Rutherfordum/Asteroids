using Assets.Scripts.View;
using Asteroids;

namespace Assets.Scripts.Control
{
    public class DebugController
    {
        private DebugView _debugView;
        private DebugModel _debugModel;

        public DebugController(DebugView view, DebugModel model)
        {
            _debugView = view;
            _debugModel = model;
        }
       

    }
}
