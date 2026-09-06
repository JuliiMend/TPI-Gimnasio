using Application.Services;
using Data;
using Domain.Model;
using DTOs;
using Moq;

namespace Application.Services.Tests
{
    public class ClienteServiceTests
    {
        [Fact]
        public async Task Get_ClienteExiste_RetornaClienteDTO()
        {
            // Arrange
            var cliente = new Cliente(1, "Juan", "Perez", "juan@test.com", 1, DateTime.Now);
            var pais = new Pais(1, "Argentina");
            cliente.SetPais(pais);

            var mockRepository = new Mock<IClienteRepository>();
            mockRepository.Setup(r => r.GetAsync(1)).ReturnsAsync(cliente);

            var service = new ClienteService(mockRepository.Object);

            // Act
            var result = await service.GetAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Juan", result.Nombre);
            Assert.Equal("Perez", result.Apellido);
            Assert.Equal("juan@test.com", result.Email);
            Assert.Equal(1, result.PaisId);
            Assert.Equal("Argentina", result.PaisNombre);
        }

        [Fact]
        public async Task Get_ClienteNoExiste_RetornaNull()
        {
            // Arrange
            var mockRepository = new Mock<IClienteRepository>();
            mockRepository.Setup(r => r.GetAsync(999)).ReturnsAsync((Cliente?)null);

            var service = new ClienteService(mockRepository.Object);

            // Act
            var result = await service.GetAsync(999);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task Add_ClienteValido_RetornaClienteDTOConId()
        {
            // Arrange
            var dto = new ClienteDTO
            {
                Nombre = "Ana",
                Apellido = "Garcia",
                Email = "ana@test.com",
                PaisId = 1
            };

            var mockRepository = new Mock<IClienteRepository>();
            mockRepository.Setup(r => r.EmailExistsAsync(It.Is<string>(email => email == dto.Email), It.IsAny<int?>())).ReturnsAsync(false);
            mockRepository.Setup(r => r.AddAsync(It.IsAny<Cliente>()))
                         .Callback<Cliente>(c => c.SetId(100)) // Simular que la BD asigna ID 100
                         .Returns(Task.CompletedTask);

            var service = new ClienteService(mockRepository.Object);

            // Act
            var result = await service.AddAsync(dto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(100, result.Id);
            Assert.Equal("Ana", result.Nombre);
            Assert.Equal("Garcia", result.Apellido);
            Assert.Equal("ana@test.com", result.Email);
            Assert.Equal(1, result.PaisId);
            Assert.True(result.FechaAlta > DateTime.Now.AddMinutes(-1)); // Fecha reciente
        }

        [Fact]
        public async Task Add_EmailDuplicado_LanzaArgumentException()
        {
            // Arrange
            var dto = new ClienteDTO
            {
                Nombre = "Pedro",
                Apellido = "Lopez",
                Email = "pedro@test.com",
                PaisId = 1
            };

            var mockRepository = new Mock<IClienteRepository>();
            mockRepository.Setup(r => r.EmailExistsAsync(It.Is<string>(email => email == dto.Email), It.IsAny<int?>())).ReturnsAsync(true);

            var service = new ClienteService(mockRepository.Object);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => service.AddAsync(dto));
            Assert.Contains("Ya existe un cliente con el Email 'pedro@test.com'", exception.Message);
        }

        [Fact]
        public async Task Delete_IdExistente_RetornaTrue()
        {
            // Arrange
            var mockRepository = new Mock<IClienteRepository>();
            mockRepository.Setup(r => r.DeleteAsync(1)).ReturnsAsync(true);

            var service = new ClienteService(mockRepository.Object);

            // Act
            var result = await service.DeleteAsync(1);

            // Assert
            Assert.True(result);
            mockRepository.Verify(r => r.DeleteAsync(1), Times.Once);
        }

        [Fact]
        public async Task Delete_IdNoExistente_RetornaFalse()
        {
            // Arrange
            var mockRepository = new Mock<IClienteRepository>();
            mockRepository.Setup(r => r.DeleteAsync(999)).ReturnsAsync(false);

            var service = new ClienteService(mockRepository.Object);

            // Act
            var result = await service.DeleteAsync(999);

            // Assert
            Assert.False(result);
        }
    }
}