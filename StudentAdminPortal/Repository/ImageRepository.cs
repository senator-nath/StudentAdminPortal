using StudentAdminPortal.Repository.IRepository;

namespace StudentAdminPortal.Repository
{
    public class ImageRepository : IImageRepository
    {
        public async Task<string> Upload(IFormFile file, string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"Resources/Image", fileName);
            using Stream filestream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(filestream);
            return GetServerRelativePath(fileName);
        }
        private string GetServerRelativePath(string fileName)
        {
            return Path.Combine(@"Resources/Image", fileName);
        }
    }
}
