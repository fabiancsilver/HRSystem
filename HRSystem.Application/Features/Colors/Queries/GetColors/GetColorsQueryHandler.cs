using AutoMapper;
using HRSystem.Application.Common;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Colors.Queries.GetColors
{
    public class GetColorsQueryHandler : IRequestHandler<GetColorsQuery, IEnumerable<GetColorsVm>>
    {
        private readonly IHRAsyncRepository<Color> _colorRepository;

        private readonly IMapper _mapper;

        public GetColorsQueryHandler(IMapper mapper, IHRAsyncRepository<Color> colorRepository)
        {
            _mapper = mapper;
            _colorRepository = colorRepository;
        }

        public async Task<IEnumerable<GetColorsVm>> Handle(GetColorsQuery request, CancellationToken cancellationToken)
        {
            QueryParameters queryParameters = request.queryParameters;

            var colors = await _colorRepository.GetAll(queryParameters);
            var colorsVm = _mapper.Map<IEnumerable<GetColorsVm>>(colors);

            return colorsVm;
        }
    }
}
