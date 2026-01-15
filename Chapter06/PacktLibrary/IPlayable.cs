namespace Packt.Shared;

public interface IPlayable
{
    void Play();
    void Pause();
    void Stop() //prima di c# 8 non si potevano avere implementazioni nei metodi delle interfacce
    {
        WriteLine("Stopped"); //default implementation
    }
}
