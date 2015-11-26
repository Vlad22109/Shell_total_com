using System.IO;

namespace WpfApplication1
{
    class StateCopy : State
    {
        public override void Handle(Context context)
        {
            context.State = new StatePastle();
            context.State = new StateDelete();
            string filePath = Path.Combine();
            string destFileName = null;
            File.Copy(filePath, destFileName);
        }
       

    }
}
