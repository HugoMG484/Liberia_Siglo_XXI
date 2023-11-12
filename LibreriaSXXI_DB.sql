-- Crear la tabla author
CREATE TABLE author (
    id INT PRIMARY KEY IDENTITY(1,1),
    name VARCHAR(255) NOT NULL
);

-- Crear la tabla book
CREATE TABLE book (
    id INT PRIMARY KEY IDENTITY(1,1),
    title VARCHAR(255) NOT NULL,
    chapters INT NOT NULL,
    pages INT NOT NULL,
    price DECIMAL(10,2) NOT NULL,
    author_id INT,
    FOREIGN KEY (author_id) REFERENCES author(id)
);

-- Insertar datos en la tabla author
INSERT INTO author (name) VALUES
('J.K. Rowling'),
('George R.R. Martin'),
('Haruki Murakami'),
('Jane Austen'),
('Stephen King'),
('Agatha Christie'),
('Gabriel García Márquez'),
('J.R.R. Tolkien'),
('Toni Morrison'),
('Margaret Atwood');

-- Insertar datos en la tabla book
INSERT INTO book (title, chapters, pages, price, author_id) VALUES
('Harry Potter and the Sorcerer''s Stone', 17, 336, 29.99, 1),
('A Game of Thrones', 73, 694, 39.99, 2),
('Norwegian Wood', 12, 296, 24.99, 3),
('Pride and Prejudice', 23, 432, 19.99, 4),
('The Shining', 30, 450, 27.99, 5),
('Murder on the Orient Express', 12, 256, 22.99, 6),
('One Hundred Years of Solitude', 20, 417, 29.99, 7),
('The Hobbit', 19, 310, 26.99, 8),
('Beloved', 28, 324, 34.99, 9),
('The Handmaid''s Tale', 15, 311, 32.99, 10),
('The Catcher in the Rye', 26, 277, 21.99, 1),
('To Kill a Mockingbird', 31, 324, 28.99, 2),
('The Great Gatsby', 15, 180, 19.99, 3),
('1984', 23, 328, 24.99, 4),
('Brave New World', 18, 311, 22.99, 5),
('The Lord of the Rings', 65, 1178, 49.99, 8),
('The Color Purple', 21, 295, 26.99, 9),
('The Handmaid''s Tale', 15, 311, 32.99, 10),
('Moby-Dick', 135, 652, 38.99, 7),
('The Alchemist', 15, 197, 20.99, 3);





