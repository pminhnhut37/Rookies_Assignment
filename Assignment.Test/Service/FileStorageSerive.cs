using Moq;
using MyAssignment.Services;

namespace Assignment.Test.Service
{
    public static class FileStorageSerive
    {
        public static IStorageService IStorageService()
        {
            var fileStorageService = Mock.Of<IStorageService>();

            return fileStorageService;
        }
    }
}
