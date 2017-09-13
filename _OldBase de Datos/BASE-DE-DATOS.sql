use master
go

if exists(Select * FROM SysDataBases WHERE name='Inmobiliaria')
BEGIN
	DROP DATABASE Inmobiliaria
END
go

CREATE DATABASE Inmobiliaria
ON
(
	NAME=Inmobiliaria,
	FILENAME='C:\Inmobiliaria.mdf'
)
go

--pone en uso la bd
USE Inmobiliaria
go

CREATE TABLE Zona
(
acronZona char(3) Not Null check(acronZona like '[A-Z][A-Z][A-Z]'),
departamento char(1) Not Null check(departamento like '[A-S]'),
nombreOficial varchar(200) Not Null,
habitantes int Not Null check(habitantes >0),
bajaLogica bit default 0,
PRIMARY KEY(acronZona, departamento)
)
GO

CREATE TABLE ServicioZona
(
acronZona char(3),
departamento char(1),
nombreServicio varchar(200) Not Null,
FOREIGN KEY (acronZona, departamento) REFERENCES Zona(acronZona, departamento),
PRIMARY KEY(acronZona, departamento, nombreServicio)
)
GO

CREATE TABLE Empleado(
empUsuario varchar(50) not null,
empContraseña varchar(10) not null check (LEN(empContraseña) = 10),
empEliminado bit default 0,
primary key(empUsuario)
)
go

CREATE TABLE Propiedades
(
proPadron int not null check(proPadron>0), 
proDireccion varchar(60) not null,  
proPrecio int not null check(proPrecio>0),
proAccion varchar(20) not null check(proAccion IN ('VENTA', 'PERMUTA','ALQUILER')), 
proCantBaños int not null check(proCantBaños>0), 
proCantHabitaciones int not null check(proCantHabitaciones>0),
proMt2Ed int not null check(proMt2Ed>0), 
zonDepartamento char(1) not null, 
zonAcronimo char(3),
proUsuario varchar(50) foreign key references Empleado(empUsuario) not null, 
foreign key(zonAcronimo,zonDepartamento) references Zona(acronZona, departamento),
primary key(proPadron)
)
go


CREATE TABLE Casa
(
casPadron int foreign key references Propiedades(proPadron) not null, 
casMt2Ter int not null check(casMt2Ter>0), 
casJardin bit not null default 0,
primary key(casPadron)
)
go

CREATE TABLE Apartamento
(
apaPadron int foreign key references Propiedades(proPadron) not null, 
apaPiso int not null check(apaPiso>0), 
apaAsc bit not null default 0,
primary key(apaPadron)
)
go

CREATE TABLE Locales
(
locPadron int foreign key references Propiedades(proPadron) not null, 
locHabilitacion bit not null, 
primary key(locPadron)
)
go

CREATE TABLE Visita
(
visID int identity (1,1) primary key, 
visNombre varchar(30) not null, 
visTel int not null check(visTel > 0), 
visFecha datetime not null, 
visPadron int foreign key references Propiedades(proPadron) not null 
)
go
--««««««««««««««««««««««««««««««««««««««««« FIN TABLAS »»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»--

--«««««««««««««««««««««««««««««««««««««««««   VISTAS   »»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»--

--VISTA PARA TRABAJAR CON CASA
CREATE VIEW InfoCasa AS
SELECT p.proPadron, p.proDireccion, p.proPrecio, p.proAccion, p.proCantBaños, p.proUsuario,
p.proCantHabitaciones, p.proMt2Ed, p.zonDepartamento, p.zonAcronimo, c.casMt2Ter, c.casJardin
FROM Propiedades p INNER JOIN Casa c 
ON p.proPadron = c.casPadron
GO

--VISTA PARA TRABAJAR CON LOCALES
CREATE VIEW InfoLocal AS
SELECT p.proPadron, p.proDireccion, p.proPrecio, p.proAccion, p.proCantBaños, p.proUsuario,
p.proCantHabitaciones, p.proMt2Ed, p.zonDepartamento, p.zonAcronimo, l.locHabilitacion
FROM Propiedades p INNER JOIN Locales l 
ON p.proPadron = l.locPadron
GO

--VISTA PARA TRABAJAR CON APARTAMENTOS
CREATE VIEW InfoApartamento AS
SELECT p.proPadron, p.proDireccion, p.proPrecio, p.proAccion, p.proCantBaños, p.proUsuario,
p.proCantHabitaciones, p.proMt2Ed, p.zonDepartamento, p.zonAcronimo, a.apaPiso, a.apaAsc
FROM Propiedades p INNER JOIN Apartamento a 
ON p.proPadron = a.apaPadron
GO

--VISTA SERVICIO POR ZONAS
CREATE VIEW ServXZona AS
SELECT z.acronZona, z.departamento, z.nombreOficial, z.habitantes, s.nombreServicio
FROM ServicioZona s INNER JOIN Zona z
ON z.acronZona = s.acronZona AND Z.departamento = S.departamento
WHERE z.bajaLogica = 0
GO

--VISTA TRABAJAR CON ZONAS ACTIVA
CREATE VIEW ZonaActiva AS
SELECT * FROM Zona WHERE bajaLogica = 0
GO

--VISTA TRABAJAR CON ZONAS INACTIVA
CREATE VIEW Zonas AS
SELECT * FROM Zona 
GO

--VISTA TRABAJA CON EMPLEADOS ACTIVOS
CREATE VIEW EmpleadoActivo AS
SELECT * FROM Empleado WHERE empEliminado = 0
GO

--VISTA TRABAJA CON EMPLEADOS INACTIVOS
CREATE VIEW Empleados AS
SELECT * FROM Empleado 
GO
--«««««««««««««««««««««« FIN VISTAS »»»»»»»»»»»»»»»»»»»»--


--«««««««««««««««««««««««««««««««««««  PROPIEDADES »»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»
--««««««««««««««««««««««««««««««««««««««««««««»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»
--Buscar casa
CREATE PROC BuscarCasa @padron int AS
SELECT p.proPadron, p.proDireccion, p.proPrecio, p.proAccion, p.proCantBaños, p.proCantHabitaciones, 
		p.proMt2Ed, p.zonDepartamento, p.zonAcronimo, p.proUsuario, c.casMt2Ter, c.casJardin
FROM Casa c inner join Propiedades p on p.proPadron = c.casPadron
WHERE @padron = c.casPadron
go
--Buscar Locales
CREATE PROC BuscarLocal @padron int AS
SELECT *
FROM Locales l inner join Propiedades p on p.proPadron=l.locPadron
WHERE @padron = l.locPadron 
go
--Buscar apto
CREATE PROC BuscarApto @padron int AS
SELECT p.proPadron, p.proDireccion, p.proPrecio, p.proAccion, p.proCantBaños, p.proCantHabitaciones, p.proMt2Ed, p.zonDepartamento, p.zonAcronimo, p.proUsuario, c.apaPiso, c.apaAsc
FROM Apartamento c inner join Propiedades p on p.proPadron = c.apaPadron
WHERE @padron = c.apaPadron
go
----Alta Casa
CREATE PROC AltaCasa 
@padron int, 
@direccion varchar(60), 
@precio int, 
@accion varchar(20), 
@cantBaños int, 
@cantHab int, 
@mt2Ed int, 
@departamento char(1), 
@acronimo char(3), 
@usuario varchar(50), 
@mt2Ter int, 
@jardin bit 
as
BEGIN
	if(exists(select * from Propiedades  where(@padron = proPadron)))
	return -2;
	
	if(not exists(select * from Zona where(departamento = @departamento and acronZona = @acronimo)))
	return -3;
		
	if(not exists(select * from Empleado where (empUsuario = @usuario)))
	return -4;
		
	declare @error int
	begin transaction 
		insert Propiedades(proPadron, proDireccion, proPrecio, proAccion, proCantBaños, 
		proCantHabitaciones, proMt2Ed, zonDepartamento, zonAcronimo, proUsuario)
		
		values(@padron, @direccion, @precio, @accion, @cantBaños, @cantHab, @mt2Ed, 
		@departamento, @acronimo, @usuario)
		
		set @error = @@ERROR		
		
		insert Casa(casPadron, casMt2Ter, casJardin) 
		values (@padron, @mt2Ter, @jardin)
		set @error = @error + @@ERROR
		
	if(@error = 0)
		begin 
			commit tran;
			return 1;
		end
	else
		begin
			rollback tran;
			return -1;
		end	
END
go

--------------------------------------------------------------------------------------

--Modificacion Casa
CREATE PROC ModificarCasa 
@padron int, 
@direccion varchar(60), 
@precio int, 
@accion varchar(20), 
@cantBaños int, 
@cantHab int, 
@mt2Ed int, 
@departamento char(1), 
@acronimo char(3), 
@usuario varchar(50), 
@mt2Ter int, 
@jardin bit 
as
BEGIN
	if(exists(select * from Propiedades  where(@padron = proPadron)))
	return -2;
	
	if(not exists(select * from Zona where(departamento = @departamento and acronZona = @acronimo)))
	return -3;
		
	if(not exists(select * from Empleado where (empUsuario = @usuario)))
	return -4;
	
	declare @error int
	begin tran
		update Propiedades 
		set 
		proDireccion = @direccion, 
		proPrecio = @precio, 
		proAccion = @accion, 
		proCantBaños = @cantBaños, 
		proCantHabitaciones = @cantHab, 
		proMt2Ed = @mt2Ed, 
		zonDepartamento = @departamento, 
		zonAcronimo = @acronimo, 
		proUsuario = @usuario
		where proPadron = @padron
		set @error = @@ERROR
		
		update Casa set casMt2Ter = @mt2Ter, casJardin = @jardin where casPadron = @padron
		set @error = @error + @@ERROR
		
	if(@error = 0)
	begin 
		commit tran
		return 1
	end
	else
	begin
		rollback tran
		return -1
	end		
END
go
--------------------------------------------------------------------------------------
--lista todas las casas
CREATE PROCEDURE ListaCasas
AS
BEGIN
SELECT * FROM InfoCasa
END
GO
--------------------------------------------------------------------------------------

----Alta Locales
CREATE PROC AltaLocales 
@padron int, 
@direccion varchar(60), 
@precio int, 
@accion varchar(20), 
@cantBaños int, 
@cantHab int, 
@mt2Ed int, 
@departamento char(1), 
@acronimo char(3), 
@usuario varchar(50), 
@habilitacion bit 
as
BEGIN
	if(exists(select * from Propiedades  where(@padron = proPadron)))
	return -2;
	
	if(not exists(select * from Zona where(departamento = @departamento and acronZona = @acronimo)))
	return -3;
		
	if(not exists(select * from Empleado where (empUsuario = @usuario)))
	return -4;
	
	declare @error int
	begin transaction 
		insert Propiedades(proPadron, proDireccion, proPrecio, proAccion, 
		proCantBaños, proCantHabitaciones, proMt2Ed, zonDepartamento, 
		zonAcronimo, proUsuario) 
		values (@padron, @direccion, @precio, @accion, @cantBaños, @cantHab, 
		@mt2Ed, @departamento, @acronimo, @usuario)
		set @error = @@ERROR		
		
		insert Locales(locPadron, locHabilitacion) values (@padron, @habilitacion)
		set @error = @error + @@ERROR	
		
	if(@error = 0)
		begin 
			commit tran;
			return 1
		end
	else
		begin
			rollback tran;
			return -1
		end	

END
go

--------------------------------------------------------------------------------------
----Modificacion Locales
CREATE PROC ModificarLocales 
@padron int, 
@direccion varchar(60), 
@precio int, 
@accion varchar(20), 
@cantBaños int, 
@cantHab int, 
@mt2Ed int, 
@departamento char(1), 
@acronimo char(3), 
@usuario varchar(50), 
@habilitacion bit 
as
BEGIN
	if(exists(select * from Propiedades  where(@padron = proPadron)))
	return -2;
	
	if(not exists(select * from Zona where(departamento = @departamento and acronZona = @acronimo)))
	return -3;
		
	if(not exists(select * from Empleado where (empUsuario = @usuario)))
	return -4;
	
	declare @error int
	begin tran
		update Propiedades set proDireccion = @direccion, proPrecio = @precio, proAccion = @accion, proCantBaños = @cantBaños, 
		proCantHabitaciones = @cantHab, proMt2Ed = @mt2Ed, zonDepartamento = @departamento, zonAcronimo = @acronimo, 
		proUsuario = @usuario
		where proPadron = @padron
		set @error = @@ERROR
		
		update Locales set locHabilitacion = @habilitacion where locPadron = @padron
		set @error = @error + @@ERROR
		
	if(@error = 0)
	begin 
		commit tran
		return 1
	end
	else
	begin
		rollback tran
		return -1
	end		
END
go

-------------------------------------------------------------------------------------
--Lista locales
CREATE PROCEDURE ListaLocales
AS
BEGIN
SELECT * FROM InfoLocal
END
GO

-------------------------------------------------------------------------------------
----Alta Apartamentos
CREATE PROC AltaApartamentos 
@padron int, 
@direccion varchar(60), 
@precio int, 
@accion varchar(20), 
@cantBaños int, 
@cantHab int, 
@mt2Ed int, 
@departamento char(1), 
@acronimo char(3), 
@usuario varchar(50), 
@piso int, 
@ascensor bit 
as
BEGIN
	if(exists(select * from Propiedades  where(@padron = proPadron)))
	return -2;
	
	if(not exists(select * from Zona where(departamento = @departamento and acronZona = @acronimo)))
	return -3;
		
	if(not exists(select * from Empleado where (empUsuario = @usuario)))
	return -4;
	
	declare @error int
	begin transaction 
		insert Propiedades(proPadron, proDireccion, proPrecio, proAccion, proCantBaños, proCantHabitaciones, proMt2Ed, 
		zonDepartamento, zonAcronimo, proUsuario) 
		values (@padron, @direccion, @precio, @accion, @cantBaños, @cantHab, @mt2Ed, @departamento, @acronimo, @usuario)
		set @error = @@ERROR		
		
		insert Apartamento(apaPadron, apaPiso, apaAsc) values (@padron, @piso, @ascensor)
		set @error = @error + @@ERROR
	if(@error = 0)
		begin 
			commit tran;
			return 1;
		end
	else
		begin
			rollback tran;
			return -1;
		end	
END
go

-------------------------------------------------------------------------------------
----Modificacion Apartamento
CREATE PROC ModificarApartamento 
@padron int, 
@direccion varchar(60), 
@precio int, 
@accion varchar(20), 
@cantBaños int, 
@cantHab int, 
@mt2Ed int, 
@departamento char(1), 
@acronimo char(3), 
@usuario varchar(50), 
@piso int, 
@ascensor bit 
as
BEGIN
	if(not exists(select * from Propiedades  where(@padron = proPadron)))
	return -2;
	
	if(not exists(select * from Zona where(departamento = @departamento and acronZona = @acronimo)))
	return -3;

	if(not exists(select * from Empleado where (empUsuario = @usuario)))
	return -4;
	
	declare @error int
	begin tran
	update Propiedades set proDireccion = @direccion, proPrecio = @precio, proAccion = @accion, proCantBaños = @cantBaños, 
	proCantHabitaciones = @cantHab, proMt2Ed = @mt2Ed, zonDepartamento = @departamento, zonAcronimo = @acronimo, 
	proUsuario = @usuario
	where proPadron = @padron
		
		set @error = @@ERROR
		
		update Apartamento set apaPiso = @piso, apaAsc = @ascensor where apaPadron = @padron
		set @error = @error + @@ERROR
		
	if(@error = 0)
	begin 
		commit tran
		return 1
	end
	else
	begin
		rollback tran
		return -1
	end		
END
go

-------------------------------------------------------------------------------------
--Lista Apartamentos
CREATE PROCEDURE ListaApartamentos
AS
BEGIN
SELECT * FROM InfoApartamento
END
GO

-------------------------------------------------------------------------------------
--Eliminar Propiedad.
CREATE PROC EliminarPropiedad 
@padron int 
as
BEGIN
	if(not exists(SELECT * FROM Propiedades WHERE @padron = proPadron))
		return -2;

	declare @error int
	begin tran
		delete Apartamento where apaPadron = @padron
		set @error = @@ERROR
		
		delete Locales where locPadron = @padron
		set @error = @error + @@ERROR
		
		delete Casa where casPadron = @padron
		set @error = @error + @@ERROR
		
		delete Propiedades where proPadron = @padron
		set @error = @error + @@ERROR
		
		--6) Se elimina al final el dato dependiente de la visita. ERROR. 
		--PREGUNTAR
		delete Visita where visPadron = @padron
		set @error = @error + @@ERROR
	
	if(@error = 0)
	begin 
		commit tran
		return 1
	end
	else
	begin
		rollback tran
		return -1
	end	
	
END
go

--------------------------------------------------------------------------------------

--«««««««««««««««««««««««««««««««««««««  ZONAS   »»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»
--««««««««««««««««««««««««««««««««««««««««««««»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»
--Lista Zonas y las ordena por el departamento
--------------------------------------------------------------------------------------
--Busca una Zona
CREATE PROCEDURE BuscarZonaActiva
@DEPARTAMENTO char(1),
@ACRONIMO char(3)
AS
BEGIN
	SELECT * 
	FROM ZonaActiva
	WHERE ZonaActiva.departamento = @DEPARTAMENTO AND ZonaActiva.acronZona = @ACRONIMO 
END
GO
-------------------------------------------------------------------------------------
--Buscar Zonas en general activas e inactivas
CREATE PROCEDURE BuscarZonas
@DEPARTAMENTO char(1),
@ACRONIMO char(3)
AS
BEGIN
	SELECT *
	FROM Zonas
	WHERE departamento=@DEPARTAMENTO AND acronZona = @ACRONIMO
END
GO
-------------------------------------------------------------------------------------
--Alta de una Zona
CREATE PROCEDURE AltaZona
@DEPARTAMENTO char(1),
@ACRONIMO char(3),
@NOMBREOFICIAL varchar(200),
@HABITANTES int
AS
BEGIN
	if(Exists(SELECT * FROM ZonaActiva WHERE departamento = @DEPARTAMENTO and acronZona = @ACRONIMO))
	return -1
	else if(Exists(SELECT * FROM ZonaInactiva WHERE departamento = @DEPARTAMENTO and acronZona = @ACRONIMO))
	UPDATE ZonaInactiva SET bajaLogica = 0 WHERE departamento = @DEPARTAMENTO and acronZona = @ACRONIMO
	
	INSERT INTO Zona (departamento, acronZona, nombreOficial, habitantes)
	VALUES (@DEPARTAMENTO, @ACRONIMO, @NOMBREOFICIAL, @HABITANTES)
	if(@@ERROR <> 0)
	return -2
	
	else if(@@ERROR = 0)
	return 1
END
GO
-------------------------------------------------------------------------------------
--Baja de una Zona
CREATE PROCEDURE BajaZona
@DEPARTAMENTO char(1),
@ACRONIMO char(3)
AS
BEGIN
	 if(Not Exists(SELECT * FROM Zona WHERE Zona.departamento = @DEPARTAMENTO and zona.acronZona = @ACRONIMO))
	 return -1
	 else if(Exists(SELECT * FROM ZonaInactiva WHERE departamento = @DEPARTAMENTO and acronZona = @ACRONIMO))
	 return -2
	 else if(Exists(SELECT *
	 FROM Propiedades
	 WHERE Propiedades.zonAcronimo = @ACRONIMO and Propiedades.zonDepartamento = @DEPARTAMENTO))
	 BEGIN
	 UPDATE ZonaActiva SET bajaLogica = 1 WHERE departamento = @DEPARTAMENTO and acronZona = @ACRONIMO
	 return 2
	 END
	 BEGIN TRANSACTION
	 DELETE FROM ServicioZona WHERE departamento = @DEPARTAMENTO AND acronZona = @ACRONIMO
	 if(@@ERROR <> 0)
	 BEGIN
	 ROLLBACK TRANSACTION
	 return -3
	 END
	 DELETE FROM Zona WHERE departamento = @DEPARTAMENTO AND acronZona = @ACRONIMO
	 if(@@ERROR = 0)
	 COMMIT TRANSACTION
	 return 1
END
GO

-------------------------------------------------------------------------------------
--Modifica una Zona
CREATE PROCEDURE ModZona
@DEPARTAMENTO char(1),
@ACRONIMO char(3),
@NOMBREOFICIAL varchar(200),
@HABITANTES int
AS
BEGIN
	if(Not Exists(SELECT * FROM Zona WHERE departamento = @DEPARTAMENTO AND acronZona = @ACRONIMO))
	return -1
	if(Exists(SELECT * FROM ZonaInactiva WHERE departamento = @DEPARTAMENTO AND acronZona = @ACRONIMO))
	return -2
	UPDATE Zona SET nombreOficial = @NOMBREOFICIAL, habitantes = @HABITANTES 
	WHERE departamento = @DEPARTAMENTO AND acronZona = @ACRONIMO
	if(@@ERROR <> 0)
	return -3
	else if(@@ERROR = 0)
	return 1
	
END
GO
--------------------------------------------------------------------------------------

--««««««««««««««««««««««««««««««««««««  SERVICIOS »»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»
--««««««««««««««««««««««««««««««««««««««««««««»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»
-------------------------------------------------------------------------------------
CREATE PROCEDURE ListarServ_X_zona
@DEPARTAMENTO char(1),
@ACRONIMO char(3)
AS
BEGIN
	SELECT * FROM ServXZona WHERE departamento = @DEPARTAMENTO AND acronZona = @ACRONIMO
END
GO
--ALTA DE UN SERVICIO
CREATE PROCEDURE AltaServicio
@DEPARTAMENTO char(1),
@ACRONIMO char(3),
@NOMBRESERVICIO varchar(200)
AS
BEGIN
	if(Not Exists(SELECT * FROM Zona WHERE departamento = @DEPARTAMENTO AND acronZona = @ACRONIMO))
	return (-1)
		
	else if(Exists(
	SELECT * 
	FROM ServicioZona
	WHERE ServicioZona.departamento = @DEPARTAMENTO AND
	ServicioZona.acronZona = @ACRONIMO AND
	nombreServicio = @NOMBRESERVICIO))
	return (-2)
	
	else
	INSERT INTO ServicioZona(departamento, acronZona, nombreServicio)
	VALUES(@DEPARTAMENTO, @ACRONIMO, @NOMBRESERVICIO)
	
	if(@@ERROR = 0)
	return 1
END
GO

------------------------------------------------------------------------------------
--BAJA DE UN SERVICIO
CREATE PROCEDURE BajaServicio
@DEPARTAMENTO char(1),
@ACRONIMO char(3)
AS
BEGIN
	if(Not Exists(SELECT * FROM Zona 
	WHERE departamento = @DEPARTAMENTO AND acronZona = @ACRONIMO))
	return -1
	
	DELETE FROM ServicioZona
	WHERE ServicioZona.departamento = @DEPARTAMENTO AND
	ServicioZona.acronZona = @ACRONIMO
					 
END
GO
-----------------------------------------------------------------------------------

--«««««««««««««««««««««««««««««««««««  EMPLEADO »»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»
--««««««««««««««««««««««««««««««««««««««««««««»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»
--Logueo
Create procedure LogueoEmpleado 
@empUsuario varchar(50),
@Password varchar(10)
as
begin 
if(exists(select * from EmpleadoActivo where @empUsuario=empUsuario and @Password=empContraseña))
return -1 --Error en el inicio de sesion 
else
select * from Empleado where @empUsuario=empUsuario and @Password=empContraseña
end
go 
--BUSCAR EMPLEADO
Create procedure BuscarEmpleadoActivo 
@empUsuario varchar(50)
as
begin 
if(not exists(Select * from EmpleadoActivo where @empUsuario=empUsuario))
	return -1
else
	select * from EmpleadoActivo where @empUsuario=empUsuario
end
go 

Create procedure BuscarEmpleados @empUsuario varchar(50) as
begin 
	if(not exists(select * from Empleados where @empUsuario=empUsuario))
	return -1
	else
	select * from Empleados where @empUsuario=empUsuario
end
go
--------------------------------------------------------------------------------------
--Alta Empleado
Create procedure AltaEmpleado 
@empUsuario varchar(50), 
@empContraseña varchar(10),
@empContraseña1 varchar(10) 
as
begin
declare @Contra varchar(10)
if(@empContraseña!=@empContraseña1)
return -1

if(exists(select * from Empleado where @empUsuario=empUsuario and empEliminado=1))
update Empleado set empEliminado=0, empContraseña=@empContraseña

else
insert into Empleado(empUsuario,empContraseña) values (@empUsuario,@empContraseña)

end
go
--Modificacion Empleado//PROBADO Y FUNCIONANDO SIN PROBLEMAS//
create procedure ModEmpleado @empUsuario varchar(50),@empContraseña varchar(10),@empContraseña1 varchar(10) as
begin
if(@empContraseña!=@empContraseña1)
return -1

if(exists(select * from Empleado where empUsuario=@empUsuario and empEliminado=1))
return -2

if(not exists(select * from Empleado where @empUsuario=empUsuario))
return -3

else
update Empleado set empContraseña=@empContraseña where empUsuario=@empUsuario 

end
go
--------------------------------------------------------------------------------------
--Eliminar Empleado
create procedure EliminarEmpleado 
@empUsuario varchar(50),
@empContraseña varchar(10),
@empContraseña1 varchar(10) 
as
begin 
if(@empContraseña!=@empContraseña1)
return-1

if(not exists(select * from Empleado where empUsuario=@empUsuario))
return -2

else if(exists(select * from EmpleadoINActivo where empUsuario=@empUsuario))
return -3

else if(Exists(SELECT * FROM EmpleadoPropiedad WHERE empUsuario=@empUsuario))
return -4
else 
delete Empleado where empUsuario=@empUsuario
end
go 
--------------------------------------------------------------------------------------
--««««««««««««««««««««««««««««VISITA»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»
---««««««««««««««««««««««««««««»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»---
--Alta visita--//Probado y funcionando correctamente.
create procedure AltaVisita @visNombre varchar(30), @visTel int, @visFecha datetime,@proPardon int as
begin 

	if(not exists(select * from Propiedades where @proPardon=proPadron))
		return -1 -- no existe la propiedad

	if(exists(select * 
			  from Visita 
			  where @visFecha = visFecha and @proPardon = visPadron))
		return -2 --la propiedad ya esta agendada
	
	declare @Visitas int  
	
	select @Visitas=Count(visTel) 
	from Visita inner join Propiedades on Visita.visPadron=Propiedades.proPadron 
	where @visTel=visTel and Propiedades.proPadron=@proPardon
	
	if(@Visitas>1)
		return -3 --ya tiene visitas agendadas

	if(@visFecha<GETDATE())
		return -4 --la fecha es incorrecta
	else
	insert into Visita (visNombre,visTel,visFecha,visPadron) values (@visNombre,@visTel,@visFecha,@proPardon)

end 
go


--««««««««««««««««««««««««««««DATOS»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»
---««««««««««««««««««««««««««««»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»---
Exec AltaEmpleado 'Usuario 1','1234567890','1234567890'
go
Exec AltaEmpleado 'Usuario 2','1234567890','1234567890'
go
Exec AltaEmpleado 'Usuario 3','1234567890','1234567890'
go
Exec AltaEmpleado 'Usuario 4','1234567890','1234567890'
go

Exec AltaZona 'S','MDO','Montevideo',2000000
go
Exec AltaZona 'B','MLO','Maldonado',20000
go
Exec AltaZona 'M','SJE','San Jose',2000
go
Exec AltaZona 'G','ART','Artiga',100000
go
Exec AltaZona 'I','PDU','Paysandu',400000
go
Exec AltaZona 'D','TTS','Treinta y Tres',2000000
go
Exec AltaZona 'A','STL','Santa Lucia',2000000
go
Exec AltaZona 'A','CAN','Canelones',2000000
go

Exec AltaCasa 1,'charcas',123,'ALQUILER',2,2,23,'S','MDO','Usuario 1',123,1
go
Exec AltaCasa 2,'Alvacete',123,'PERMUTA',2,2,23,'S','MDO','Usuario 1',123,1
go
Exec AltaCasa 3,'Benito negro',123,'ALQUILER',2,2,23,'S','MDO','Usuario 1',123,1
go
Exec AltaCasa 4,'AV los reyes',123,'ALQUILER',2,2,23,'S','MDO','Usuario 1',123,1
go
Exec AltaCasa 5,'EH Carlito',123,'VENTA',2,2,23,'B','MLO','Usuario 1',123,1
go
Exec AltaCasa 6,'Milojas',123,'PERMUTA',2,2,23,'B','MLO','Usuario 1',123,1
go
Exec AltaCasa 7,'Cafe',123,'ALQUILER',2,2,23,'S','MDO','Usuario 1',123,1
go
Exec AltaCasa 8,'Agarrate',123,'PERMUTA',2,2,23,'S','MDO','Usuario 1',123,1
go

Exec AltaApartamentos 9,'Catalanda',2000,'VENTA',1,2,30,'G','ART','Usuario 2',3,0
go
Exec AltaApartamentos 10,'Catalanda',2000,'VENTA',1,2,30,'G','ART','Usuario 2',3,0
go
Exec AltaApartamentos 11,'Catalanda',2000,'PERMUTA',1,2,30,'G','ART','Usuario 2',3,0
go
Exec AltaApartamentos 12,'Catalanda',2000,'PERMUTA',1,2,30,'G','ART','Usuario 2',3,0
go
Exec AltaApartamentos 13,'Catalanda',2000,'VENTA',1,2,30,'G','ART','Usuario 2',3,0
go
Exec AltaApartamentos 14,'Catalanda',2000,'ALQUILER',1,2,30,'G','ART','Usuario 2',3,0
go
Exec AltaApartamentos 15,'Catalanda',2000,'ALQUILER',1,2,30,'G','ART','Usuario 2',3,0
go

Exec AltaLocales 16, 'Legnani 123', 800, 'VENTA', 1, 2, 200, 'A', 'STL', 'Usuario 1', true;  
go
Exec AltaLocales 17, 'Legnani 456', 800, 'VENTA', 1, 2, 200, 'A', 'STL', 'Usuario 1', false;  
go
Exec AltaLocales 18, 'Legnani 789', 1900, 'VENTA', 1, 2, 200, 'A', 'STL', 'Usuario 1', false;  
go
Exec AltaLocales 19, 'Legnani 147', 800, 'VENTA', 1, 2, 200, 'A', 'STL', 'Usuario 1', true;  
go
Exec AltaLocales 20, 'Legnani 258', 900, 'VENTA', 1, 2, 200, 'A', 'CAN', 'Usuario 1', false;  
go
Exec AltaLocales 21, 'Legnani 369', 800, 'VENTA', 1, 2, 200, 'A', 'STL', 'Usuario 1', true;  
go
