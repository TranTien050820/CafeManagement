namespace Cafe_Management.Core.Interfaces
{
    public interface IImageRepository
    {
        string SaveImage(string imgStr, string imgName, string _path);
    }
}
