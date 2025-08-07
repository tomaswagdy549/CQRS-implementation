using Catalog.Application.Common.GenericResponse;
using Catalog.Application.Common.Interfaces;
using Catalog.Application.Features.ProductType.Dtos.CreateProductTypeResponse;
using Catalog.Core.Entities;
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
        IProductTypeRepository _productTypeRepository { get; set; }
        public CreateProductTypeCommandHandler(IProductTypeRepository productTypeRepository)
        {
            _productTypeRepository = productTypeRepository;
        }

        public async Task<GenericResponse<CreateProductTypeResponse>> Handle(CreateProductTypeCommand request, CancellationToken cancellationToken)
        {
            var productType = new Core.Entities.ProductType()
            {
                Name = request.Name
            };
            var result = await _productTypeRepository.CreateProductType(productType);
            return new GenericResponse<CreateProductTypeResponse>()
            {
                Data = new CreateProductTypeResponse(result.Name),
                Message = "Created succesfully",
                HttpStatusCode = System.Net.HttpStatusCode.Created
            };
        }

        //public async Task<CreateProductTypeResponse> Handle(CreateProductTypeCommand request, CancellationToken cancellationToken)
        //{
        //    var productType = new Core.Entities.ProductType()
        //    {
        //        Name = request.Name
        //    };
        //    var result = await _productTypeRepository.CreateProductType(productType);
        //    return new CreateProductTypeResponse(request.Name);
        //}
    }
}
