USE master
GO
ALTER DATABASE ProyectoEditorial SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
IF EXISTS (
    SELECT [name]
        FROM sys.databases
        WHERE [name] = N'ProyectoEditorial'
)
DROP DATABASE ProyectoEditorial
GO

USE master
GO

Create Database ProyectoEditorial
Go
Use ProyectoEditorial
Go
 
Create table Usuario(
	ID_Usuario int not null identity(1,1) primary key,
	NombreUsuario varchar(50) unique not null,
	Mail varchar(100) unique not null,
    Contraseña varchar(500) not null,
	EsAdmin bit,
)
GO

Create table Direccion(
	ID_Direccion int not null identity(1,1) primary key,
	Calle varchar(50) not null,
	Altura smallint not null,
	Localidad varchar(80) not null,
	CP smallint not null,
	Provincia varchar(50) not null,
)
GO

Create table Datos_Usuario(
	ID_Usuario int,
	Nombre varchar(50) not null,
	Apellido varchar(50) not null,
	Telefono varchar(30) null,
	Primary key(ID_Usuario),
	Foreign key(ID_Usuario) references Usuario(ID_Usuario)
)
GO

CREATE TABLE Direccion_X_Usuario(
	ID_Usuario int not null,
	ID_Direccion int not null,
	Primary Key(ID_Usuario, ID_Direccion),
	Foreign key(ID_Usuario) references Usuario(ID_Usuario),
	Foreign Key(ID_Direccion) references Direccion(ID_Direccion),
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

create table Estados(
ID_Estado int not null primary key,
TipoEstados varchar(30)
)
GO

create table Compra(
	ID_Compra int not null identity(1,1) primary key,
	ID_Usuario int not null foreign key references Usuario(ID_Usuario),
	ID_Estado int null foreign key references Estados(ID_Estado),
	FechaCompra datetime DEFAULT GETDATE(),
	PrecioTotal money
)
GO

CREATE TABLE Direccion_X_Compra(
	ID_Compra int not null,
	ID_Direccion int not null,
	Primary Key(ID_Compra, ID_Direccion),
	Foreign key(ID_Compra) references Compra(ID_Compra),
	Foreign Key(ID_Direccion) references Direccion(ID_Direccion),
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
	ID_Libro int not null,
	Cantidad int not null,
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

Create table Tokens(
	ID_Token int not null primary key identity(1,1),
	Token varchar(100) null,
	Mail varchar(100) not null,
)
GO

INSERT INTO Usuario (NombreUsuario, Mail, Contraseña, EsAdmin)
VALUES 
    ('admin', 'admin@admin.com', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 1),
	('user' , 'EditorialUTN@hotmail.com', '04F8996DA763B7A969B1028EE3007569EAF3A635486DDAB211D512C85B9DF8FB', 0),
	('aoriel' , 'alan.ibanez@alumnos.frgp.utn.edu.ar', 'f7f9fc50d23cf370e452e22daa80bea8363ae47ac4f962445b4444c4641df7a1', 0),
	('dmaiz' , 'denisse.maiz@alumnos.frgp.utn.edu.ar', 'a7318ad8038b516db90bd0d588c23b4a3c0620d413cdd100245057f33fe2d129', 0),
	('avaras' , 'Agustin.Varas@outlook.com.ar', 'ad25fc1532c8454fdda1d5e5258dd5771e919eaf4db2ca59842043804ccb6fb5', 0);
GO

INSERT INTO Direccion (Calle, Altura, Localidad, CP, Provincia)
VALUES 
    ('Av. Libertador', 1234, 'Buenos Aires', 1000, 'CABA'),
    ('Av. Corrientes', 5678, 'Buenos Aires', 2000, 'CABA'),
    ('Calle 9 de Julio', 4321, 'Córdoba', 3000, 'Córdoba'),
    ('Calle San Martín', 8765, 'Rosario', 4000, 'Santa Fe'),
    ('Av. Belgrano', 9876, 'Tucumán', 5000, 'Tucumán'),
    ('Calle Mitre', 5432, 'Mendoza', 6000, 'Mendoza');
GO

INSERT INTO Datos_Usuario (ID_Usuario, Nombre, Apellido, Telefono)
VALUES 
    (3, 'Alan', 'Oriel', 123456789),
    (4, 'Denisse', 'Maiz', 987654321),
    (5, 'Agustin', 'Varas', 555555555);
GO

INSERT INTO Direccion_X_Usuario (ID_Usuario, ID_Direccion)
VALUES
	(3, 3),
	(4, 5);
GO

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
    ('Roberto', 'Bolaño'),  /*si*/
    ('Isabel', 'Allende'), /*si*/
    ('Mario', 'Vargas Llosa'),  /*si*/
    ('Leopoldo', 'Lugones'),    /*si*/
    ('Pablo', 'Neruda'),  /*si*/
    ('Gabriel', 'García Márquez'), /*si*/
    ('Antoine', 'De Saint-Exupéry');  /*si*/
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
    ('BORG001', 'Ficciones', 'Una colección de cuentos y relatos de ficción.', 2500.00, 3, 'https://quelibroleo.com/images/libros/libro_1362275865.jpg'),
    ('BORG002', 'El Aleph', 'Una recopilación de cuentos con temáticas metafísicas.', 2000.00, 7, 'https://quelibroleo.com/images/libros/libro_1362277233.jpg'),
    ('BORG003', 'El Hacedor', 'Un libro de poemas y relatos breves.', 1800.00, 1, 'https://www.sopadelibros.com/portadas/7b92848c1dd75c8e39f2.jpeg'),
    
    -- Libros de Ernesto Sábato
    ('SABA001', 'El Túnel', 'Una novela existencialista que explora la angustia humana.', 1800.00, 0, 'https://2.bp.blogspot.com/-du7xy-eojC4/Wh3odClOmAI/AAAAAAAAA2k/soMgHiFMsqA45Z5pcYaJ6PvHxt8FcjlKgCLcBGAs/s1600/El%2Btunel.jpg'),
    ('SABA002', 'Sobre Héroes y Tumbas', 'Una obra que mezcla historia y ficción en un entorno político.', 2200.00, 8, 'https://puntoed.com.ar/img/libros/sobre-heroes-y-tumbas.jpg'),
    ('SABA003', 'Abaddón el Exterminador', 'Una novela que reflexiona sobre la existencia y la muerte.', 2000.00, 7, 'https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1328545483i/63001.jpg'),

    -- Libros de Silvina Ocampo
    ('OCAM001', 'La Furia y Otros Cuentos', 'Una colección de cuentos con elementos fantásticos.', 1500.00, 6, 'https://m.media-amazon.com/images/I/41DFKfgUhSL._AC_UF1000,1000_QL80_.jpg'),
    ('OCAM002', 'Cornelia frente al Espejo', 'Una novela que explora la identidad y la soledad.', 1900.00, 8, 'https://images.cdn3.buscalibre.com/fit-in/360x360/40/97/4097bb923b642e2ddaf5301c16c64f07.jpg'),
    ('OCAM003', 'Las Invitadas', 'Una selección de cuentos con temáticas diversas.', 1700.00, 5, 'https://www.penguinlibros.com/uy/2663513-large_default/las-invitadas.jpg'),

    -- Libros de Alejandra Pizarnik
    ('PIZA001', 'Extracción de la Piedra de Locura', 'Una obra poética que aborda la locura y la angustia existencial.', 1600.00, 9, 'https://images.cdn3.buscalibre.com/fit-in/360x360/df/af/dfaf78d0874e410b93c3de7be884aa2a.jpg'),
    ('PIZA002', 'La tierra más ajena', 'Poemas intensos exploran soledad y angustia en La Tierra Más Ajena obra lírica de Pizarnik.', 1800.00, 7, 'https://www.clarin.com/img/2019/08/29/wk9K40979_720x0__1.jpg'),

    -- Libros de Julio Cortázar
    ('CORT001', 'Rayuela', 'Una novela experimental que permite múltiples formas de lectura.', 2800.00, 5, 'https://resizer.glanacion.com/resizer/v2/la-tapa-original-de-LTKO74RIEBBJ3GFEJYWGAE6ICE.jpg?auth=3fade869166fb08b8e7b1cab8aa0cf2dfecb26a68843616051b4b6603f5985c0&width=420&height=630&quality=70&smart=true'),
    ('CORT002', 'Bestiario', 'Una colección de cuentos cortos con elementos fantásticos.', 2000.00, 8, 'https://d20ohkaloyme4g.cloudfront.net/img/document_thumbnails/5b4b64a98b9ba940d3990710170f3f8e/thumb_1200_1699.png'),
    ('CORT003', 'Cronopios y Famas', 'Una obra que presenta una serie de relatos y viñetas surrealistas.', 2400.00, 4, 'https://m.media-amazon.com/images/W/MEDIAX_792452-T2/images/I/91KRWuErG8S._AC_UF1000,1000_QL80_.jpg'),

    -- Libros de Adolfo Bioy Casares
    ('BIOY001', 'La invención de Morel', 'Una novela de ciencia ficción que explora temas de traición y lealtad.', 2100.00, 7, 'https://cdn.zendalibros.com/wp-content/uploads/2022/09/la-invencion-de-morel.jpg'),
    ('BIOY002', 'Diario de la guerra del cerdo', 'Una novela que aborda la decadencia de la sociedad.', 1900.00, 9, 'https://cdn.zendalibros.com/wp-content/uploads/2022/11/adolfo-bioy-casares-diario-de-la-guerra-del-cerdo.jpg'),

    -- Libros de Victoria Ocampo
    ('OCAM004', 'Testimonios: Primera serie', 'Ensayos y testimonios sobre la guerra y sus consecuencias.', 2500.00, 4, 'https://cdn11.bigcommerce.com/s-si4e0s8t1l/images/stencil/1280x1280/products/42266/42523/806055-MLA41981719571_052020-O__35890.1611654670.jpg?c=1'),

    -- Libros de Roberto Arlt
    ('ARLT001', 'El juguete rabioso', 'Una novela que presenta una visión cruda y realista de la vida urbana.', 2000.00, 8, 'https://tierradelsur.sutty.nl/public/szqkfe9ay202xqxfsdm20ht0oxi9/EljugueterabiosoTAPa.jpg'),
    ('ARLT002', 'Los siete locos', 'La primera parte de una obra que explora la locura y la búsqueda del sentido de la vida.', 2200.00, 5, 'https://www.escritores.org/imag/rorberto_arlit_2.jpg'),
    ('ARLT003', 'El amor brujo', 'Una colección de relatos que abordan temas como el amor y la muerte.', 1800.00, 6, 'https://static.serlogal.com/imagenes_big/9788494/978849417520.JPG'),

    -- Libros de Isabel Allende
    ('ALLE001', 'La casa de los espíritus', 'Una novela que aborda temas de amor, magia y política en una familia chilena.', 2300.00, 8, 'https://andenbuch.de/wp-content/uploads/2022/01/casa-espiritus-345x524.jpeg'),
    ('ALLE002', 'De amor y de sombra', 'Una historia de amor ambientada en un contexto político turbulento.', 2100.00, 7, 'https://quelibroleo.com/images/libros/libro_1363643718.jpg'),
    ('ALLE003', 'Retrato en sepia', 'Una novela que sigue la vida de Aurora del Valle, una fotógrafa.', 2200.00, 6, 'https://quelibroleo.com/images/libros/libro_1363641301.jpg'),
    ('ALLE004', 'Inés del alma mía', 'La historia de Inés Suárez, una mujer española que viaja al Nuevo Mundo en busca de su esposo perdido.', 2400.00, 5, 'https://www.isliada.org/static/images/2023/01/Ines-del-alma-mia-500x771.jpg'),

    -- Libro de Antoine de Saint-Exupéry
    ('EXUP001', 'El Principito', 'Un clásico de la literatura infantil que aborda temas filosóficos y existenciales.', 1800.00, 10, 'https://http2.mlstatic.com/D_NQ_NP_884290-MLC46642291217_072021-O.webp'),

    -- Libro de Gabriel García Márquez
    ('GARC001', 'Crónica de una muerte anunciada', 'Una novela que explora los eventos que llevan a la muerte de un personaje central.', 2000.00, 8, 'https://wmagazin.com/wp-content/uploads/2021/04/Cronicadeunamuerteanunciada-Colombia-1-633x1024.jpg'),

    -- Libro de Pablo Neruda
    ('NERU001', 'Veinte Poemas de Amor y Una Canción Desesperada', 'Una colección de poesía que explora temas de amor y desesperación.', 1800.00, 10, 'https://assets-global.website-files.com/6034d7d1f3e0f52c50b2adee/625453f86f695c42fd66a883_6228e16ec46732b86f7d1aa0_9788418395796.jpeg'),

    -- Libro de Roberto Bolaño
    ('BOLA001', 'Los Detectives Salvajes', 'Una novela que sigue las peripecias de un grupo de escritores jóvenes en busca de un misterioso poeta desaparecido.', 2500.00, 8, 'https://www.anagrama-ed.es/uploads/media/portadas/0001/19/61a262954208d59d9d103c74c64be29d87c32582.jpeg'),

    -- Libro de Leopoldo Lugones
    ('LUGO001', 'Los Crepúsculos del Jardín', 'Una colección de poesía que aborda temas simbolistas y modernistas.', 2200.00, 6, 'https://assets1.bmstatic.com/assets/books-covers/e2/38/cMjpdbPA-ipad.jpeg'),
    
    -- Libro de Vargas Llosa
    ('VLLO001', 'La ciudad y los perros', 'Una novela que explora la vida de cadetes en una academia militar en Lima, Perú.', 2200.00, 5, 'https://libroschorcha.files.wordpress.com/2018/01/la-ciudad-y-los-perros-mario-vargas-llosa.jpg');
GO

INSERT INTO Libro_X_Autor (ID_Libro, ID_Autor)
VALUES
    (1, 1),
    (2, 1),
    (3, 1),
    (4, 5),
    (5, 5),
    (6, 5),
    (7, 4),
    (8, 4),
    (9, 4),
    (10, 7),
    (11, 7),
    (12, 2),
    (13, 2),
    (14, 2),
    (15, 3),
    (16, 3),
    (17, 6),
    (18, 8),
    (19, 8),
    (20, 8),
    (21, 11),
    (22, 11),
    (23, 11),
    (24, 11),
    (25, 16),
    (26, 15),
    (27, 14),
    (28, 10),
    (29, 13),
    (30, 12);
GO

INSERT INTO Genero_X_Libro (ID_Libro, ID_Genero)
VALUES
    (1, 3),
    (2, 3),
    (3, 3),
    (1, 4),
    (2, 4),
    (3, 4),
    (4, 3),
    (5, 3),
    (6, 3),
    (4, 4),
    (5, 4),
    (6, 4),
    (7, 3),
    (8, 3),
    (9, 3),
    (7, 4),
    (8, 4),
    (9, 4),
    (10, 3),
    (11, 3),
    (10, 4),
    (11, 4),
    (10, 2),
    (11, 2),
    (4, 1),
    (5, 1),
    (8, 1),
    (6, 1),
    (7, 7),
    (12, 1),
    (12, 3),
    (12, 4),
    (13, 3),
    (13, 4),
    (13, 7),
    (14, 3),
    (14, 4),
    (14, 7),
    (15, 1),
    (15, 3),
    (15, 4),
    (15, 6),
    (16, 1),
    (16, 3),
    (16, 4),
    (17, 10),
    (17, 9),
    (17, 3),
    (17, 4),
    (18, 3),
    (18, 4),
    (18, 1),
    (19, 3),
    (19, 4),
    (20, 3),
    (20, 4),
    (21, 4),
    (21, 1),
    (22, 4),
    (22, 1),
    (23, 1),
    (23, 4),
    (24, 1),
    (24, 4),
    (25, 1),
    (25, 5),
    (25, 7),
    (26, 1),
    (26, 4),
    (27, 2),
    (27, 4),
    (28, 1),
    (28, 4),
    (29, 2),
    (29, 3),
    (29, 4),
    (30, 1),
    (30, 4),
    (1, 8);
GO

insert into Estados (ID_Estado, TipoEstados) values
(1, 'En proceso'),
(2, 'Enviado'),
(3, 'Completo'),
(4, 'Cancelado');
GO

<<<<<<< HEAD
INSERT INTO Compra (ID_Usuario, PrecioTotal, ID_Estado, FechaCompra)
=======
    INSERT INTO Compra (ID_Usuario, PrecioTotal, ID_Estado, FechaCompra)
>>>>>>> develop
SELECT TOP 10
    U.ID_Usuario,
    L.Precio,
    E.ID_Estado,
	DATEADD(DAY, ABS(CHECKSUM(NEWID())) % (365 * 3), '2021-01-01') AS Fecha
FROM Usuario U
CROSS JOIN Libro L
CROSS JOIN Estados E
WHERE U.ID_Usuario <> 1
ORDER BY NEWID();

INSERT INTO Compra_X_Libro (ID_Compra, ID_Libro, Cantidad)
SELECT ID_Compra, ID_Libro, 1 as Cantidad
FROM (
    SELECT 
        C.ID_Compra,
        L.ID_Libro,
        ROW_NUMBER() OVER (PARTITION BY C.ID_Compra ORDER BY NEWID()) as RowNum
    FROM Compra C
    CROSS JOIN Libro L
) AS Subquery
WHERE RowNum = 1;


INSERT INTO Direccion_X_Compra (ID_Compra, ID_Direccion) 
VALUES
	(1, 4),
	(2, 2),
	(3, 5),
	(4, 4),
	(5, 5),
	(6, 6),
	(7, 2),
	(8, 3),
	(9, 3),
	(10, 1);