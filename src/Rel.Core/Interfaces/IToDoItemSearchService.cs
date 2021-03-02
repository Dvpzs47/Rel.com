using Ardalis.Result;
using Rel.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rel.Core.Interfaces
{
    public interface IToDoItemSearchService
    {
        Task<Result<ToDoItem>> GetNextIncompleteItem();
        Task<Result<List<ToDoItem>>> GetAllIncompleteItems(string searchString);
    }
}
