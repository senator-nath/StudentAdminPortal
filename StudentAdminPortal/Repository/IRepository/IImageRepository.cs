namespace StudentAdminPortal.Repository.IRepository
{
    public interface IImageRepository
    {
        Task<string> Upload(IFormFile file, String fileName);
    }
}
