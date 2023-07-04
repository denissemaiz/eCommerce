/*
USE master
GO
ALTER DATABASE ProyectoEditorial SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
IF EXISTS (
    SELECT [name]
        FROM sys.databases
        WHERE [name] = N'ProyectoEditorial'
)
DROP DATABASE ProyectoEditorial
GO*/

Create Database ProyectoEditorial
Go
Use ProyectoEditorial
Go

Create table Direccion(
	ID_Direccion int identity(1,1) not null primary key,
	Calle varchar(50) not null,
	Altura smallint not null,
	Localidad varchar(80) not null,
	CP smallint not null,
	Provincia varchar(50) not null,
)
GO

Create table Usuario(
	ID_Usuario int not null identity(1,1) primary key,
	NombreUsuario varchar(50) unique not null,
	Mail varchar(100) unique not null,
    Contraseña varchar(500) not null,
	EsAdmin bit,
)
GO

Create table Datos_Usuario(
	ID_Usuario int,
	Nombre varchar(50) not null,
	Apellido varchar(50) not null,
    ID_Direccion int null foreign key references Direccion(ID_Direccion),
	Telefono bigint not null,
	Primary key(ID_Usuario),
	Foreign key(ID_Usuario) references Usuario(ID_Usuario)
)
GO

create table Genero(
	ID_Genero int not null identity(1,1) primary key,
	Nombre varchar(100) not null,
	Descripcion varchar(200) not null
)
GO

Create table Libro(
	ID_Libro int not null identity(1,1) primary key,
	Codigo varchar(50) not null,
	Titulo varchar(50) not null,
	Descripcion varchar(200) not null,
	Precio money not null,
	Stock smallint not null,
    PortadaURL varchar(500) not null
)
GO


Create table Autor(
	ID_Autor int not null identity(1,1) primary key,
	Nombre varchar(50) not null,
	Apellido varchar(50) not null
)
GO

create table Compra(
	ID_Compra int not null identity(1,1) primary key,
	ID_Usuario int not null foreign key references Usuario(ID_Usuario),
	PrecioTotal money
)
GO

Create table Genero_X_Libro(
	ID_Libro int,
	ID_Genero int,
	Primary key(ID_Libro, ID_Genero),
	Foreign key(ID_Libro) references Libro(ID_Libro),
	Foreign key(ID_Genero) references Genero(ID_Genero)
)
GO

Create table Compra_X_Libro(
	ID_Compra int,
	ID_Libro int,
	Cantidad smallint not null,
	Primary key(ID_Compra, ID_Libro),
	Foreign key(ID_Compra) references Compra(ID_Compra),
	Foreign key(ID_Libro) references Libro(ID_Libro)
)
GO

Create table Libro_X_Autor(
	ID_Libro int,
	ID_Autor int,
	Primary key(ID_Libro, ID_Autor),
	Foreign key(ID_Libro) references Libro(ID_Libro),
	Foreign key(ID_Autor) references Autor(ID_Autor)
)
GO

INSERT INTO Usuario (NombreUsuario, Mail, Contraseña, EsAdmin)
VALUES 
    ('admin', 'admin@admin.com', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 1);
GO
--INSERT INTO Direccion (Calle, Altura, Localidad, CP, Provincia)
--VALUES 
--    ('Av. Libertador', 1234, 'Buenos Aires', 1000, 'CABA'),
--    ('Av. Corrientes', 5678, 'Buenos Aires', 2000, 'CABA'),
--    ('Calle 9 de Julio', 4321, 'Córdoba', 3000, 'Córdoba'),
--    ('Calle San Martín', 8765, 'Rosario', 4000, 'Santa Fe'),
--    ('Av. Belgrano', 9876, 'Tucumán', 5000, 'Tucumán'),
--    ('Calle Mitre', 5432, 'Mendoza', 6000, 'Mendoza');
--GO
--INSERT INTO Datos_Usuario (ID_Usuario, Nombre, Apellido, ID_Direccion, Telefono)
--VALUES 
--    (1, 'Alan', 'Oriel', 1, 123456789),
--    (2, 'Denisse', 'Maiz', 2, 987654321),
--    (3, 'Agustin', 'Varas', NULL, 555555555),
--    (4, 'Rodrigo', 'García', 3, 111111111),
--    (5, 'Analia', 'Rojas', 4, 999999999),
--    (6, 'Martín', 'Suárez', NULL, 777777777),
--    (7, 'Valentina', 'Fernández', 5, 444444444),
--    (8, 'Emilio', 'Pérez', NULL, 222222222),
--    (9, 'Carolina', 'Molina', 6, 888888888),
--    (10, 'Julián', 'Rodríguez', NULL, 666666666);
--GO
INSERT INTO Autor (Nombre, Apellido)
VALUES
    ('Jorge Luis', 'Borges'),
    ('Julio', 'Cortázar'),
    ('Adolfo', 'Bioy Casares'),
    ('Silvina', 'Ocampo'),
    ('Ernesto', 'Sábato'),
    ('Victoria', 'Ocampo'),
    ('Alejandra', 'Pizarnik'),
    ('Roberto', 'Arlt'),
    ('Eduardo', 'Galeano'),
    ('Manuel', 'Puig'),
    ('César', 'Aira'),
    ('Ricardo', 'Piglia'),
    ('Leopoldo', 'Lugones'),
    ('Luisa', 'Valenzuela'),
    ('Ricardo', 'Guiraldes');
GO
INSERT INTO Genero (Nombre, Descripcion)
VALUES
    ('Novela', 'Género narrativo extenso que narra una historia ficticia.'),
    ('Poesía', 'Género literario que utiliza la belleza del lenguaje para expresar sentimientos y emociones.'),
    ('Literatura Argentina', 'Género que abarca obras literarias escritas por autores argentinos.'),
    ('Literatura Latinoamericana', 'Género que incluye obras literarias de autores de América Latina.'),
    ('Literatura Inglesa', 'Género que engloba obras literarias escritas por autores de origen inglés.'),
    ('Ciencia ficción', 'Género que utiliza conceptos científicos y tecnológicos para crear mundos imaginarios.'),
    ('Fantasía', 'Género que incluye elementos mágicos, seres sobrenaturales y mundos imaginarios.'),
    ('Policial', 'Género que se centra en la resolución de crímenes y misterios.'),
    ('Histórico', 'Género que se basa en eventos y períodos históricos reales.'),
    ('Ensayo', 'Género que presenta ideas y reflexiones sobre diversos temas de manera argumentativa.');
GO
INSERT INTO Libro (Codigo, Titulo, Descripcion, Precio, Stock, PortadaURL)
VALUES
    -- Libros de Jorge Luis Borges
    ('BORG001', 'Ficciones', 'Una colección de cuentos y relatos de ficción.', 2500.00, 8, 'https://quelibroleo.com/images/libros/libro_1362275865.jpg'),
    ('BORG002', 'El Aleph', 'Una recopilación de cuentos con temáticas metafísicas.', 2000.00, 7, 'https://quelibroleo.com/images/libros/libro_1362277233.jpg'),
    ('BORG003', 'El Hacedor', 'Un libro de poemas y relatos breves.', 1800.00, 6, 'https://www.sopadelibros.com/portadas/7b92848c1dd75c8e39f2.jpeg'),
    
    -- Libros de Ernesto Sábato
    ('SABA001', 'El Túnel', 'Una novela existencialista que explora la angustia humana.', 1800.00, 9, 'https://2.bp.blogspot.com/-du7xy-eojC4/Wh3odClOmAI/AAAAAAAAA2k/soMgHiFMsqA45Z5pcYaJ6PvHxt8FcjlKgCLcBGAs/s1600/El%2Btunel.jpg'),
    ('SABA002', 'Sobre Héroes y Tumbas', 'Una obra que mezcla historia y ficción en un entorno político.', 2200.00, 8, 'https://puntoed.com.ar/img/libros/sobre-heroes-y-tumbas.jpg'),
    ('SABA003', 'Abaddón el Exterminador', 'Una novela que reflexiona sobre la existencia y la muerte.', 2000.00, 7, 'https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1328545483i/63001.jpg'),

    -- Libros de Silvina Ocampo
    ('OCAM001', 'La Furia y Otros Cuentos', 'Una colección de cuentos con elementos fantásticos.', 1500.00, 6, 'https://m.media-amazon.com/images/I/41DFKfgUhSL._AC_UF1000,1000_QL80_.jpg'),
    ('OCAM002', 'Cornelia frente al Espejo', 'Una novela que explora la identidad y la soledad.', 1900.00, 8, 'https://images.cdn3.buscalibre.com/fit-in/360x360/40/97/4097bb923b642e2ddaf5301c16c64f07.jpg'),
    ('OCAM003', 'Las Invitadas', 'Una selección de cuentos con temáticas diversas.', 1700.00, 5, 'https://www.penguinlibros.com/uy/2663513-large_default/las-invitadas.jpg'),

    -- Libros de Alejandra Pizarnik
    ('PIZA001', 'Extracción de la Piedra de Locura', 'Una obra poética que aborda la locura y la angustia existencial.', 1600.00, 9, 'https://images.cdn3.buscalibre.com/fit-in/360x360/df/af/dfaf78d0874e410b93c3de7be884aa2a.jpg'),
    ('PIZA002', 'La tierra más ajena', 'Poemas intensos exploran soledad y angustia en La Tierra Más Ajena obra lírica de Pizarnik.', 1800.00, 7, 'https://www.clarin.com/img/2019/08/29/wk9K40979_720x0__1.jpg')
GO
INSERT INTO Compra (ID_Usuario, PrecioTotal)
SELECT TOP 25
    U.ID_Usuario,
    L.Precio
FROM Usuario U
CROSS JOIN Libro L
ORDER BY NEWID();
GO
INSERT INTO Compra_X_Libro (ID_Compra, ID_Libro, Cantidad)
SELECT TOP 30
    C.ID_Compra,
    L.ID_Libro,
    CASE WHEN RAND() < 0.9 THEN 1 ELSE 2 END
FROM Compra C
CROSS JOIN Libro L
ORDER BY NEWID();
GO
