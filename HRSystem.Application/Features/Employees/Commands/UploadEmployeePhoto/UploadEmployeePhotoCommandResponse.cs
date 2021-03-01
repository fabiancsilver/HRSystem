using HRSystem.Application.Responses;

namespace HRSystem.Application.Features.Employees.Commands.UploadEmployeePhoto
{
    public class UploadEmployeePhotoCommandResponse : BaseResponse
    {
        public UploadEmployeePhotoCommandResponse() : base()
        {

        }

        public string FileSystemNameWithExtenstion { get; set; }
    }
}