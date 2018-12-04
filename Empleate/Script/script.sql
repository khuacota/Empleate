insert into Employees (Name, LastName, Birthdate, Gender, CivilStatus, Phone, City, Direction, Email, Image) values
('Karem', 'Huacota', CAST('3-11-1991 6:30:00 PM' AS DATETIME2), 'Femenino', 'Soltero', 72252681, 'Cochabamba', 'Quijarro 89', 'karem.huacota@gmailcom', 'image.png'),
('Gary', 'Antezana', CAST('3-11-1992 6:30:00 PM' AS DATETIME2), 'Masculino', 'Soltero', 73499111, 'Cochabamba', 'America 120', 'gary.antezana@gmail.com', 'image.png'),
('Gustavo', 'Lavadenz', CAST('3-15-1993 6:30:00 PM' AS DATETIME2), 'Masculino', 'Soltero', 73499112, 'Tarija', 'Juan 23', 'gustavo.lavadenz@gmail.com', 'image.png'),
('David', 'Sanguino', CAST('4-11-1992 6:30:00 PM' AS DATETIME2), 'Masculino', 'Soltero', 73499113, 'Tarija', 'Juan 24', 'david.sanguino@gmail.com', 'image.png'),
('Regina', 'Ayca', CAST('5-11-1996 6:30:00 PM' AS DATETIME2), 'Femenino', 'Casado', 72489113, 'La Paz', 'America 24', 'regina.ayca@gmail.com', 'image.png'),
('Alicia', 'Limachi', CAST('6-11-1994 6:30:00 PM' AS DATETIME2), 'Femenino', 'Casado', 71499113, 'La Paz', 'San Martin 125', 'alicia.limachi@gmail.com', 'image.png'),
('Leonardo', 'Leon', CAST('6-11-1995 6:30:00 PM' AS DATETIME2), 'Masculino', 'Soltero', 73445118, 'Oruro', '6 de Agosto 24', 'leo.leon@gmail.com', 'image.png');


insert into Companies (Name, Description, Entry, Address, Phone, Email, Url, Image) values
('Jala', 'Empresa de software', 'Software', 'Melchor Perez 123', 4444152, 'jala@jalasoft.com', 'www.jala.org', 'image.png'),
('Umss', 'Universidad Mayor de San Simon', 'Educacion', 'Jordan 123', 4441043, 'umss@gmail.com', 'www.umss.edu.bo', 'image.png');

insert into Offers (CompanyId, Profession, Description, MinExperience, City, StartTime, EndTime, Deadline) values
(1, 'Informatico', 'Desarrollador en angular y asp.net core', 5, 'Cochabamba',  CAST('12-21-2018 8:00:00 AM' AS DATETIME2), CAST('12-21-2018 6:30:00 PM' AS DATETIME2), CAST('1-21-2019 6:30:00 PM' AS DATETIME2)),
(1, 'Contador', 'Conocimientos en contabilidad e impuestos', 3, 'Cochabamba', CAST('12-21-2018 8:00:00 AM' AS DATETIME2), CAST('12-21-2018 6:30:00 PM' AS DATETIME2), CAST('1-21-2019 6:30:00 PM' AS DATETIME2)),
(2, 'Docente', 'Docente de calculo 1 y 2', 2, 'Cochabamba', CAST('12-21-2018 8:00:00 AM' AS DATETIME2), CAST('12-21-2018 6:30:00 PM' AS DATETIME2), CAST('1-21-2019 6:30:00 PM' AS DATETIME2)),
(2, 'Docente', 'Docente de redes', 3, 'Cochabamba', CAST('12-21-2018 8:00:00 AM' AS DATETIME2), CAST('12-21-2018 6:30:00 PM' AS DATETIME2), CAST('1-21-2019 6:30:00 PM' AS DATETIME2));
