﻿namespace WpfApplication1
{
    class StateDelete : State
    {
        public override void Handle(Context context)
        {
            context.State = new StateCut();
            context.State = new StatePastle();
            context.State = new StateCopy();
        }
    }
}
