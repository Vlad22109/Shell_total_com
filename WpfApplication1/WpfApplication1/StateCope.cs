using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class StateCopy: State
    {
        public override void Handle(Context context)
        {
            context.State = new StateCut();
            context.State = new StatePastle();
            context.State = new StateDelete();

        }
    }
}
