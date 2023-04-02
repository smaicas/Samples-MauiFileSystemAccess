namespace Nj.Samples.FileDisclaimer.Abstractions;
public interface IFolderPicker
{
    Task<string> PickFolder();
}
