using Domain.Entities;
using Domain.RepositoryInterfaces;
using Moq;
using Service.Implementations;

namespace Service.Tests
{
    public class DoctorServiceTest
    {
        private readonly DoctorService _doctorService;
        private readonly Mock<IDoctorRepository> _doctorRepositoryMock;

        public DoctorServiceTest()
        {
            _doctorRepositoryMock = new Mock<IDoctorRepository>();
            _doctorService = new DoctorService(_doctorRepositoryMock.Object);
        }

        [Fact]
        public void CreateDoctorWithEmptyName_Fail()
        {
            string name = string.Empty;
            Specialization specialization = new Specialization(It.IsAny<string?>());
            _doctorRepositoryMock.Setup(repository => repository.CreateDoctor(It.IsAny<string>(), It.IsAny<Specialization>())).Returns(() => null);
            var result = _doctorService.CreateDoctor(name, specialization);
            Assert.Null(result.Value);
        }

        [Fact]
        public void CreateDoctorWithDigitName_Fail()
        {
            string name = "1";
            Specialization specialization = new Specialization(It.IsAny<string?>());
            _doctorRepositoryMock.Setup(repository => repository.CreateDoctor(It.IsAny<string>(), It.IsAny<Specialization>())).Returns(() => null);
            var result = _doctorService.CreateDoctor(name, specialization);
            Assert.Null(result.Value);
        }
        [Fact]
        public void CreateDoctor_Verify()
        {
            string name = "John Hetcher";
            Specialization specialization = new Specialization(It.IsAny<string?>());
            _doctorRepositoryMock.Setup(repository => repository.CreateDoctor(It.IsAny<string>(), It.IsAny<Specialization>())).Returns(() => new Doctor(name, specialization));
            var result = _doctorService.CreateDoctor(name, specialization);
            Assert.NotNull(result.Value);
        }
        [Fact]
        public void DeleteDoctorIsNotExist_Fail()
        {
            var result = _doctorService.DeleteDoctor(It.IsAny<Doctor>());
            Assert.False(result.Value);
        }

        [Fact]
        public void DeleteDoctor_Verify()
        {
            Doctor doctor = new Doctor("John Hetcher", It.IsAny<Specialization>());
            _doctorRepositoryMock.Setup(repository => repository.FindDoctorById(It.IsAny<int?>())).Returns(() => new Doctor("John Hetcher", It.IsAny<Specialization>()));
            var result = _doctorService.DeleteDoctor(doctor);
            Assert.True(result.Value);
        }

        [Fact]
        public void GetDoctorByIdIsNotExist_Fail()
        {
            var result = _doctorService.GetDoctorById(It.IsAny<int?>());
            Assert.Null(result.Value);
        }

        [Fact]
        public void GetDoctorById_Verify()
        {
            Doctor doctor = new Doctor("John Hetcher", It.IsAny<Specialization>());
            _doctorRepositoryMock.Setup(repository => repository.FindDoctorById(It.IsAny<int?>())).Returns(() => new Doctor("John Hetcher", It.IsAny<Specialization>()));
            var result = _doctorService.GetDoctorById(It.IsAny<int?>());
            Assert.NotNull(result.Value);
        }

        [Fact]
        public void GetDoctorBySpecializationIsNotExist_Fail()
        {
            var result = _doctorService.GetDoctorBySpecialization(It.IsAny<Specialization>());
            Assert.Null(result.Value);
        }

        [Fact]
        public void GetDoctorBySpecialization_Verify()
        {
            Doctor doctor = new Doctor("John Hetcher", It.IsAny<Specialization>());
            _doctorRepositoryMock.Setup(repository => repository.FindDoctorBySpecialization(It.IsAny<Specialization>())).Returns(() => new Doctor("John Hetcher", It.IsAny<Specialization>()));
            var result = _doctorService.GetDoctorBySpecialization(It.IsAny<Specialization>());
            Assert.NotNull(result.Value);
        }

        [Fact]
        public void GetDoctorsIsEmpty_Fail()
        {
            _doctorRepositoryMock.Setup(repository => repository.Select()).Returns(() => null);
            var result = _doctorService.GetDoctors();
            Assert.Null(result.Value);
        }

        [Fact]
        public void GetDoctors_Verify()
        {
            _doctorRepositoryMock.Setup(repository => repository.Select()).Returns(() => new List<Doctor>());
            var result = _doctorService.GetDoctors();
            Assert.NotNull(result.Value);
        }
    }
}
