using System.IO;

namespace WpfApplication1
{
    class StateDelete : State
    {
        public override void Handle(Context context)
        {
            
            context.State = new StatePastle();
            context.State = new StateCopy();
            string filePath = Path.Combine();
                File.Delete(filePath);
        }
       
    }
}
