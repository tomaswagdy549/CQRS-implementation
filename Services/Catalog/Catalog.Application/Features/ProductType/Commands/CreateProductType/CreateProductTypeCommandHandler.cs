using Catalog.Application.Common.Interfaces;
using Catalog.Application.Features.ProductType.Dtos.CreateProductTypeResponse;
using Catalog.Core.Entities;
using Catalog.Core.Interfaces.GenericRepositoryInterface;
using Catalog.Core.Repositories.IProductType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Features.ProductType.Commands.CreateProductType
{
    public class CreateProductTypeCommandHandler : IGenericResponseRequestHandler<CreateProductTypeCommand, CreateProductTypeResponse>
    {
        IAdd<Core.Entities.ProductType> _addProductTypeRepository { get; set; }
        public CreateProductTypeCommandHandler(IAdd<Core.Entities.ProductType> addProductTypeRepository)
        {
            _addProductTypeRepository = addProductTypeRepository;
        }

        public async Task<GenericResponse<CreateProductTypeResponse>> Handle(CreateProductTypeCommand request, CancellationToken cancellationToken)
        {
            var productType = new Core.Entities.ProductType()
            {
                Name = request.Name
            };
            var result = await _addProductTypeRepository.AddAsync(productType);
            return new GenericResponse<CreateProductTypeResponse>()
            {
                Data = new CreateProductTypeResponse(result.Name),
                Message = "Created succesfully",
                HttpStatusCode = System.Net.HttpStatusCode.Created
            };
        }
    }
}
