using System;

namespace HRSystem.Application.Features.EmailTypes.Commands.UpdateEmailType
{
    public class UpdateEmailTypeDto
    {
        public int EmailTypeID { get; set; }

        public string Name { get; set; }
    }
}
