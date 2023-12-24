namespace Lilith.Utility.Interfaces;

public interface IService: INameable {
    void Run();
    void Close();
}