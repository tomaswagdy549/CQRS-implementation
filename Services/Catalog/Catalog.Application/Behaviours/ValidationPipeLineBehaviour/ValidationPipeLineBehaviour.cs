using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Behaviours.ValidationPipeLineBehaviour
{
    public class ValidationPipeLineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        IEnumerable<IValidator<TRequest>> _validators;
        public ValidationPipeLineBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var validationResults = await Task.WhenAll(
                    _validators.Select(v => v.ValidateAsync(context, cancellationToken))
                );

                var failures = validationResults
                    .SelectMany(r => r.Errors)
                    .Where(f => f != null)
                    .ToList();

                if (failures.Any())
                    throw new ValidationException(failures);
            }

            return await next();
        }
    }
}
