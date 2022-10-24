using Domain.Entities;
using Domain.RepositoryInterfaces;
using Moq;
using Service.Implementations;

namespace Service.Tests
{
    public class AppointmentServiceTest
    {
        private readonly AppointmentService _appointmentService;
        private readonly Mock<IAppointmentRepository> _appointmentRepositoryMock;

        public AppointmentServiceTest()
        {
            _appointmentRepositoryMock = new Mock<IAppointmentRepository>();
            _appointmentService = new AppointmentService(_appointmentRepositoryMock.Object);
        }

        [Fact]
        public void GetFreeDatesForSpecializationWithEmptyName_Fail()
        {
            Specialization specialization = new Specialization(string.Empty);
            var result = _appointmentService.GetFreeDatesForSpecialization(specialization);
            Assert.Null(result.Value);
        }

        [Fact]
        public void GetFreeDatesForSpecializationWithDigitName_Fail()
        {
            Specialization specialization = new Specialization("1");
            var result = _appointmentService.GetFreeDatesForSpecialization(specialization);
            Assert.Null(result.Value);
        }

        [Fact]
        public void GetFreeDatesForSpecializationWithEmptyList_Fail()
        {
            _appointmentRepositoryMock.Setup(repository => repository.SelectFreeDatesForSpecialization(It.IsAny<Specialization>())).
                Returns(() => null);
            var result = _appointmentService.GetFreeDatesForSpecialization(It.IsAny<Specialization>());
            Assert.Null(result.Value);
        }

        [Fact]
        public void GetFreeDatesForSpecialization_Verify()
        {
            var result = _appointmentService.GetFreeDatesForSpecialization(It.IsAny<Specialization>());
            Assert.NotNull(result.Value);
        }

        [Fact]
        public void SaveAppointmentWithEmptyList_Fail()
        {
            _appointmentRepositoryMock.Setup(repository => repository.UpdateAppointment(It.IsAny<Doctor>(), It.IsAny<DateTime>())).Returns(() => false);
            var result = _appointmentService.SaveAppointment(It.IsAny<Doctor>(), It.IsAny<DateTime>());
            Assert.False(result.Value);
        }

        [Fact]
        public void SaveAppointmentWithNoDate_Fail()
        {
            _appointmentRepositoryMock.Setup(repository => repository.UpdateAppointment(It.IsAny<Doctor>(), It.IsAny<DateTime>())).Returns(() => false);
            var result = _appointmentService.SaveAppointment(It.IsAny<Doctor>(), It.IsAny<DateTime>());
            Assert.False(result.Value);
        }

        [Fact]
        public void SaveAppointment_Verify()
        {
            var result = _appointmentService.SaveAppointment(It.IsAny<Doctor>(), It.IsAny<DateTime>());
            Assert.False(result.Value);
        }

        [Fact]
        public void SaveAppointmentToAnyDoctorhEmptyList_Fail()
        {
            _appointmentRepositoryMock.Setup(repository => repository.UpdateAppointmentToAnyDoctor(It.IsAny<Specialization>(), It.IsAny<DateTime>())).Returns(() => false);
            var result = _appointmentService.SaveAppointmentToAnyDoctor(It.IsAny<Specialization>(), It.IsAny<DateTime>());
            Assert.False(result.Value);
        }

        [Fact]
        public void SaveAppointmentToAnyDoctorWithNoDate_Fail()
        {
            _appointmentRepositoryMock.Setup(repository => repository.UpdateAppointmentToAnyDoctor(It.IsAny<Specialization>(), It.IsAny<DateTime>())).Returns(() => false);
            var result = _appointmentService.SaveAppointmentToAnyDoctor(It.IsAny<Specialization>(), It.IsAny<DateTime>());
            Assert.False(result.Value);
        }

        [Fact]
        public void SaveAppointmentToAnyDoctor_Verify()
        {
            var result = _appointmentService.SaveAppointmentToAnyDoctor(It.IsAny<Specialization>(), It.IsAny<DateTime>());
            Assert.False(result.Value);
        }

    }
}
