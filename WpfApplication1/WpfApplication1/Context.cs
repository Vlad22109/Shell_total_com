using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication1
{
class Context
{
        public State State { get; set; }

        public Context(State state)
        {
            this.State = state;
        }
        public void Request()
        {
            this.State.Handle(this);
        }

        public void Handle(Context context)
        {
            throw new NotImplementedException();
        }
    }
}
