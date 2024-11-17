using GestionPersonas.Domain.Entities;
using GestionPersonas.Domain.Enums;
using GestionPersonas.Domain.ExcepcionesGenerales;
using GestionPersonas.Domain.ValueObjects;
using GestionPersonas.Infraestructura.Persistencia;
using GestionPersonas.Infraestructura.Repositorios;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace GestionPersonas.UnitTest
{
    public class RepositorioGenerico
    {

        private readonly Mock<AplicacionDbContext> _mockDbContext;
        private readonly RepositorioGenerico<Medico> _repositorio;

        public RepositorioGenerico()
        {
            _mockDbContext = new Mock<AplicacionDbContext>(new DbContextOptions<AplicacionDbContext>());
            _repositorio = new RepositorioGenerico<Medico>(_mockDbContext.Object);
        }

        [Fact]
        public async Task AddAsync()
        {
            // Arrange
            Direccion direccion = new Direccion("Calle 70", "Manizales", "Caldas", "Manizales");
            var medico = Medico.CrearMedico("Juan Sebastian", "Gonzalez Echeverri", DateTime.Parse("25/01/1985"), direccion, "3136658", "juanse@gmail.com", Rol.Medico, Especialidad.Cirujano, "6543245641465", DateTime.Parse("01/10/2024"), Departamento.Cirujia);
            _mockDbContext.Setup(db => db.Set<Medico>().Add(It.IsAny<Medico>()));

            // Act
            var result = await _repositorio.AddAsync(medico);

            // Assert
            _mockDbContext.Verify(db => db.Set<Medico>().Add(It.Is<Medico>(r => r == medico)), Times.Once);
            _mockDbContext.Verify(db => db.SaveChangesAsync(default), Times.Once);
            Assert.Equal(medico, result);
        }

        [Fact]
        public async Task GetAllAsync()
        { // Arrange
            Direccion direccion1 = new Direccion("Calle 70", "Manizales", "Caldas", "Manizales");
            Direccion direccion2 = new Direccion("Calle 90", "Manizales", "Caldas", "Manizales");

            var medicos = new List<Medico> {
                                Medico.CrearMedico("Juan Sebastian", "Gonzalez Echeverri", DateTime.Parse("25/01/1985"), direccion1, "3136658", "juanse@gmail.com", Rol.Medico, Especialidad.Cirujano,"6543245641465", DateTime.Parse("01/10/2024"), Departamento.Cirujia ),
                                Medico.CrearMedico("Juan Camilo", "Quiceno Gomez", DateTime.Parse("25/01/1989"), direccion2, "313654984", "juanca@gmail.com", Rol.Medico, Especialidad.MeidicoGeneral,"6489234654645", DateTime.Parse("01/10/2024"), Departamento.MedicinaGeneral )
                             };
            _mockDbContext.Setup(db => db.Set<Medico>().ToListAsync(default)).ReturnsAsync(medicos);
            // Act
            var result = await _repositorio.GetAllAsync();
            // Assert 
            Assert.Equal(medicos, result);
        }

        [Fact]
        public async Task GetByIdAsync()
        {
            // Arrange
            Direccion direccion1 = new Direccion("Calle 70", "Manizales", "Caldas", "Manizales");
            var medico = Medico.CrearMedico("Juan Sebastian", "Gonzalez Echeverri", DateTime.Parse("25/01/1985"), direccion1, "3136658", "juanse@gmail.com", Rol.Medico, Especialidad.Cirujano, "6543245641465", DateTime.Parse("01/10/2024"), Departamento.Cirujia);
            _mockDbContext.Setup(db => db.Set<Medico>().FindAsync(1)).ReturnsAsync(medico);

            // Act
            var result = await _repositorio.GetByIdAsync(1);

            // Assert
            Assert.Equal(medico, result);
        }

        [Fact]
        public async Task GetByIdAsync_DeberiaSacarExcepcionNoHayDatosException_CuandoIdNoExiste()
        {
            // Arrange
            _mockDbContext.Setup(db => db.Set<Medico>().FindAsync(It.IsAny<int>())).ReturnsAsync((Medico)null);

            // Act & Assert
            await Assert.ThrowsAsync<NoHayDatosException>(() => _repositorio.GetByIdAsync(1));
        }
    }
}