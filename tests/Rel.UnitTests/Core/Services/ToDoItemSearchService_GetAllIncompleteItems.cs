using Ardalis.Result;
using Ardalis.Specification;
using Moq;
using Rel.Core.Entities;
using Rel.Core.Services;
using Rel.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Rel.UnitTests.Core.Services
{
    public class ToDoItemSearchService_GetAllIncompleteItems
    {
        [Fact]
        public async Task ReturnsInvalidGivenNullSearchString()
        {
            var repo = new Mock<IRepository>();
            var service = new ToDoItemSearchService(repo.Object);

            var result = await service.GetAllIncompleteItemsAsync(null);
            Assert.Equal(Ardalis.Result.ResultStatus.Invalid,
                result.Status);
            Assert.Equal("searchString is required.", result.ValidationErrors.First().ErrorMessage);
        }

        [Fact]
        public async Task ReturnsErrorGivenDataAccessException()
        {
            //string expectedErrorMessage = "Database not there.";
            var repo = new Mock<IRepository>();
            var service = new ToDoItemSearchService(repo.Object);
            repo.Setup(r => r.ListAsync(It.IsAny<ISpecification<ToDoItem>>()))
                .ThrowsAsync(new System.Exception(null));

            var result = await service.GetAllIncompleteItemsAsync("Database not there.");
            Assert.Equal(Ardalis.Result.ResultStatus.Error,
                result.Status);
            //Assert.Equal(expectedErrorMessage, result.Errors.First());
        }

        [Fact]
        public async Task ReturnsListGivenSearchString()
        {
            var repo = new Mock<IRepository>();
            var service = new ToDoItemSearchService(repo.Object);

            var result = await service.GetAllIncompleteItemsAsync("foo");
            Assert.Equal(Ardalis.Result.ResultStatus.Ok,
                result.Status);
        }


        private List<ToDoItem> GetTestItems()
        {
            var builder = new ToDoItemBuilder();

            var items = new List<ToDoItem>();

            var item1 = builder.WithDefaultValues().Build();
            items.Add(item1);

            var item2 = builder.WithDefaultValues().Id(2).Build();
            items.Add(item2);

            var item3 = builder.WithDefaultValues().Id(3).Build();
            items.Add(item3);

            return items;
        }

    }
}
