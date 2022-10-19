using Domain.Entities;
using Domain.RepositoryInterfaces;
using Moq;
using Service.Implementations;

namespace Service.Tests
{
    public class TimetableServiceTest
    {
        private readonly TimetableService _timetableService;
        private readonly Mock<ITimetableRepository> _timetableRepositoryMock;

        public TimetableServiceTest()
        {
            _timetableRepositoryMock = new Mock<ITimetableRepository>();
            _timetableService = new TimetableService(_timetableRepositoryMock.Object);
        }

        [Fact]
        public void AddTimeTable_Verify()
        {
            var result = _timetableService.AddTimeTable(It.IsAny<Doctor>(), It.IsAny<DateTime>(), It.IsAny<DateTime>());
            Assert.True(result.Value);
        }
        [Fact]
        public void EditTimeTable_Verify()
        {
            var result = _timetableService.EditTimeTable(It.IsAny<Doctor>(), It.IsAny<DateTime>(), It.IsAny<DateTime>());
            Assert.True(result.Value);
        }
    }
}
