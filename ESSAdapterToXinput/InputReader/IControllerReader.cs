using System;

namespace WpfApp.InputReader
{
    public delegate void StateEventHandler(IControllerReader sender, ControllerState state);

    public interface IControllerReader
    {
        event StateEventHandler ControllerStateChanged;
        event EventHandler ControllerDisconnected;

        void Finish();
    }
}
