﻿using HRSystem.Application.Responses;

namespace HRSystem.Application.Features.Addresses.Commands.CreateAddress
{
    public class CreateAddressCommandResponse : BaseResponse
    {
        public CreateAddressCommandResponse() : base()
        {

        }

        public CreateAddressDto Address { get; set; }
    }
}