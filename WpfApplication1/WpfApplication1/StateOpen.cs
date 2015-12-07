using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
class StateOpen : State
{
public override void Handle(Context context)
{
context.State = new StateCopy();
context.State = new StatePastle();
context.State = new StateDelete();
            string path = Path.GetTempFileName();
            using (FileStream fs = File.Open(path, FileMode.Open));

        }

}
}
