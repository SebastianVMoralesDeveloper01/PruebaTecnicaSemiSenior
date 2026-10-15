CREATE DATABASE PruebaTecnica
GO
USE PruebaTecnica

CREATE TABLE TipoDocumento
(
  TipoDocumentoId INT IDENTITY (1,1) PRIMARY KEY,
  Codigo Varchar(5) NOT NULL UNIQUE
)

CREATE TABLE Genero 
(
 GeneroId INT IDENTITY (1,1) PRIMARY KEY,
 Codigo Varchar(5) NOT NULL UNIQUE
)

CREATE TABLE Pacientes
(
 PacienteId INT IDENTITY (1,1) PRIMARY KEY,
 TipoDocumentoId INT  NOT NULL CONSTRAINT FK_Paciente_TipDoc REFERENCES  TipoDocumento,
 NumeroDocumento VARCHAR(20) NOT NULL,
 NombrePaciente VARCHAR(200) NOT NULL,
 FechaNacimiento DATE NOT NULL,
 CorreoElectronico VARCHAR(150) NOT NULL,
 GeneroId INT NOT NULL CONSTRAINT FK_Paciente_Genero REFERENCES dbo.Genero,
 Direccion NVARCHAR(200) NOT NULL,
 Telefono VARCHAR(20) NOT NULL,
 Activo BIT NOT NULL
)

CREATE UNIQUE INDEX UXPACIENTE ON Pacientes (TipoDocumentoId, NumeroDocumento);


--Creacion de SP

--Registro de paciente
CREATE PROCEDURE SP_Crear_Paciente(
 @TipoDocumentoId INT , 
 @NumeroDocumento VARCHAR(20), 
 @NombrePaciente VARCHAR(200),
 @FechaNacimiento DATE,
 @CorreoElectronico VARCHAR(150),
 @GeneroId INT,
 @Direccion NVARCHAR(200),
 @Telefono VARCHAR(20),
 @Activo BIT
)
AS
BEGIN

	INSERT INTO Pacientes (TipoDocumentoId, NumeroDocumento, NombrePaciente, FechaNacimiento, CorreoElectronico,
							GeneroId, Direccion, Telefono, Activo)
			VALUES (@TipoDocumentoId, @NumeroDocumento, @NombrePaciente, @FechaNacimiento, @CorreoElectronico,
							@GeneroId, @Direccion, @Telefono, @Activo);

SELECT CAST(SCOPE_IDENTITY() AS INT) AS PACIENTEID;

END;

--Consulta de paciente
CREATE PROCEDURE SP_Consulta_Pacientes
AS
BEGIN

	SELECT * FROM Pacientes
	ORDER BY PacienteId DESC
END

--Consulta de paciente por ID

CREATE PROCEDURE SP_Consulta_Pacientes_Id
(@PacienteId INT)
AS
BEGIN

	SELECT * FROM Pacientes
	WHERE PacienteId = @PacienteId
	ORDER BY PacienteId DESC
END

--Actualizacion de paciente
CREATE PROCEDURE SP_Actualizar_Paciente(
 @PacienteId INT,
 @TipoDocumentoId INT,
 @NumeroDocumento VARCHAR(20),
 @NombrePaciente VARCHAR(200),
 @FechaNacimiento DATE,
 @CorreoElectronico VARCHAR(150),
 @GeneroId INT,
 @Direccion NVARCHAR(200),
 @Telefono VARCHAR(20),
 @Activo BIT
)
AS
BEGIN

	UPDATE Pacientes
	SET TipoDocumentoId = @TipoDocumentoId,
		NumeroDocumento = @NumeroDocumento,
		NombrePaciente = @NombrePaciente,
		FechaNacimiento = @FechaNacimiento,
		CorreoElectronico = @CorreoElectronico,
		GeneroId = @GeneroId,
		Direccion = @Direccion,
		Telefono = @Telefono,
		Activo = @Activo
	WHERE PacienteId = @PacienteId;

END
GO

--Eliminacion de paciente
CREATE PROCEDURE SP_Eliminar_Paciente
(@PacienteId INT)
AS
BEGIN

	DELETE FROM Pacientes
	WHERE PacienteId = @PacienteId;

END
GO

---COnsultas y validaciones

select * from Pacientes;




EXEC SP_Consulta_Pacientes;

EXEC SP_Consulta_Pacientes_Id 3;