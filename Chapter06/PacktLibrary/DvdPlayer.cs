namespace Packt.Shared;

public class  DvdPlayer : IPlayable
{
    public void Pause()
    {
        WriteLine("DVD Paused");
    }

    public void Play()
    {
        WriteLine("DVD Playing");
    }

    // Non è necessario implementarlo perché ha già un'implementazione di default nell'interfaccia
}
