using MediatR;
using System.IO;

namespace HRSystem.Application.Features.Employees.Commands.UploadEmployeePhoto
{
    public class UploadEmployeePhotoCommand : IRequest<UploadEmployeePhotoCommandResponse>
    {
        public int EmployeeID { get; set; }

        public Stream Stream { get; set; }

        public string FileExtension { get; set; }

        public string PathToSave { get; set; }
    }

}
