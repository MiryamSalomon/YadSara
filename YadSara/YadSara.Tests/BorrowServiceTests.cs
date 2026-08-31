using Microsoft.Extensions.Logging;
using Moq;
using YadSara.Core.Entities;
using YadSara.Core.Repositories;
using YadSara.Service;
using Xunit;

namespace YadSara.Tests
{
    public class BorrowServiceTests
    {
        private readonly Mock<IBorrowRepository> _repository = new();
        private readonly BorrowService _sut;

        public BorrowServiceTests()
        {
            _sut = new BorrowService(_repository.Object, Mock.Of<ILogger<BorrowService>>());
        }

        [Fact]
        public async Task GetListAsync_ReturnsRepositoryResult()
        {
            var borrows = new List<Borrow> { new("1", "Name", "0500000000", "Address", 1) };
            _repository.Setup(r => r.GetAllAsync()).ReturnsAsync(borrows);

            var result = await _sut.GetListAsync();

            Assert.Same(borrows, result);
        }

        [Fact]
        public async Task GetBorrowAsync_WhenNotFound_ReturnsNull()
        {
            _repository.Setup(r => r.GetByIdAsync("missing")).ReturnsAsync((Borrow?)null);

            var result = await _sut.GetBorrowAsync("missing");

            Assert.Null(result);
        }

        [Fact]
        public async Task AddBorrowAsync_ReturnsAddedBorrow()
        {
            var borrow = new Borrow("1", "Name", "0500000000", "Address", 1);
            _repository.Setup(r => r.AddAsync(borrow)).ReturnsAsync(borrow);

            var result = await _sut.AddBorrowAsync(borrow);

            Assert.Equal(borrow, result);
            _repository.Verify(r => r.AddAsync(borrow), Times.Once);
        }

        [Fact]
        public async Task UpdateBorrowAsync_WhenNotFound_PropagatesKeyNotFoundException()
        {
            var borrow = new Borrow("missing", "Name", "0500000000", "Address", 1);
            _repository.Setup(r => r.UpdateAsync(borrow)).ThrowsAsync(new KeyNotFoundException());

            await Assert.ThrowsAsync<KeyNotFoundException>(() => _sut.UpdateBorrowAsync(borrow));
        }

        [Fact]
        public async Task DeleteBorrowAsync_WhenFound_ReturnsTrue()
        {
            _repository.Setup(r => r.DeleteAsync("1")).ReturnsAsync(true);

            var result = await _sut.DeleteBorrowAsync("1");

            Assert.True(result);
        }

        [Fact]
        public async Task DeleteBorrowAsync_WhenNotFound_ReturnsFalse()
        {
            _repository.Setup(r => r.DeleteAsync("missing")).ReturnsAsync(false);

            var result = await _sut.DeleteBorrowAsync("missing");

            Assert.False(result);
        }
    }
}
