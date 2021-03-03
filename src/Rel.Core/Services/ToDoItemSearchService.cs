using Ardalis.Result;
using Rel.Core.Entities;
using Rel.Core.Interfaces;
using Rel.Core.Specifications;
using Rel.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rel.Core.Services
{
    public class ToDoItemSearchService : IToDoItemSearchService
    {
        private readonly IRepository _repository;

        public ToDoItemSearchService(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<Result<List<ToDoItem>>> GetAllIncompleteItemsAsync(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                var errors = new List<ValidationError>();
                errors.Add(new ValidationError()
                {
                    Identifier = nameof(searchString),
                    ErrorMessage = $"{nameof(searchString)} is required."
                });
                return Result<List<ToDoItem>>.Invalid(errors);
            }

            var incompleteSpec = new IncompleteItemsSpecification();

            try
            {
                var items = await _repository.ListAsync(incompleteSpec);
                return new Result<List<ToDoItem>>(items);
            }
            catch (Exception ex)
            {
                return Result<List<ToDoItem>>.Error(new[] { ex.Message });
            }

            //var items = await _repository.ListAsync<ToDoItem>(incompleteSpec);

            //return new Result<List<ToDoItem>>(items);
        }

        public async Task<Result<ToDoItem>> GetNextIncompleteItemAsync()
        {
            var incompleteSpec = new IncompleteItemsSpecification();
            var items = await _repository.ListAsync(incompleteSpec);
            if (!items.Any())
            {
                return Result<ToDoItem>.NotFound();
            }
            return new Result<ToDoItem>(items.First());
        }
    }
}
