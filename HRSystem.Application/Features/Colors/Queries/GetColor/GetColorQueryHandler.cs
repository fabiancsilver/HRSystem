using AutoMapper;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Colors.Queries.GetColor
{
    public class GetColorQueryHandler : IRequestHandler<GetColorQuery, GetColorVm>
    {
        private readonly IHRAsyncRepository<Color> _colorRepository;
        
        private readonly IMapper _mapper;

        public GetColorQueryHandler(IMapper mapper, IHRAsyncRepository<Color> colorRepository)
        {
            _mapper = mapper;
            _colorRepository = colorRepository;            
        }

        public async Task<GetColorVm> Handle(GetColorQuery request, CancellationToken cancellationToken)
        {
            var color = await _colorRepository.GetById(request.ColorID);
            var colorVm = _mapper.Map<GetColorVm>(color);            

            return colorVm;
        }
    }
}
