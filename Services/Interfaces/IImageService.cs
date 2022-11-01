namespace ContactMVC.Services.Interfaces
{
    public interface IImageService
    {
        // Needs to be implemented for Interface, No logic, all is public, all
        // methods have to be implemented here for class inteded to be a service
        public Task<byte[]> ConvertFileToByteArrayAsync(IFormFile file);
        public string ConvertByteArrayToFile(byte[] fileData, string extension);
    }
}
