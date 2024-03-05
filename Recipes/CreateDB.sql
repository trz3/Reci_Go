-- Create Users table
CREATE TABLE Users (
    id INT PRIMARY KEY IDENTITY(1,1),
    name VARCHAR(255),
    email VARCHAR(255),
    password VARCHAR(255),
    username VARCHAR(255),
    is_admin BIT,
    is_blocked BIT
);

-- Create Ratings table
CREATE TABLE Ratings (
    id INT PRIMARY KEY IDENTITY(1,1),
    name VARCHAR(255)
);

-- Create Ingredients table
CREATE TABLE Ingredients (
    id INT PRIMARY KEY IDENTITY(1,1),
    name VARCHAR(255)
);

-- Create Measures table
CREATE TABLE Measures (
    id INT PRIMARY KEY IDENTITY(1,1),
    name VARCHAR(255)
);

-- Create Categories table
CREATE TABLE Categories (
    id INT PRIMARY KEY IDENTITY(1,1),
    name VARCHAR(255)
);

-- Create Difficulties table
CREATE TABLE Difficulties (
    id INT PRIMARY KEY IDENTITY(1,1),
    name VARCHAR(255)
);

-- Create Recipes table
CREATE TABLE Recipes (
    id INT PRIMARY KEY IDENTITY(1,1),
    title VARCHAR(255),
    preparation_method TEXT,
    id_category INT,
    id_difficulty INT,
    preparation_time DATETIME,
    is_approved BIT,
    id_user INT,
    FOREIGN KEY (id_category) REFERENCES Categories(id),
    FOREIGN KEY (id_difficulty) REFERENCES Difficulties(id),
    FOREIGN KEY (id_user) REFERENCES Users(id)
);

-- Create Recipe_Ingredients table
CREATE TABLE Recipe_Ingredients (
    id INT PRIMARY KEY IDENTITY(1,1),
    quantity INT,
    id_recipe INT,
    id_ingredient INT,
    id_measure INT,
    FOREIGN KEY (id_recipe) REFERENCES Recipes(id),
    FOREIGN KEY (id_ingredient) REFERENCES Ingredients(id),
    FOREIGN KEY (id_measure) REFERENCES Measures(id)
);

-- Create Reviews table
CREATE TABLE Reviews (
    id INT PRIMARY KEY IDENTITY(1,1),
    comment TEXT,
    id_user INT,
    id_rating INT,
    id_recipe INT,
    FOREIGN KEY (id_user) REFERENCES Users(id),
    FOREIGN KEY (id_rating) REFERENCES Ratings(id),
    FOREIGN KEY (id_recipe) REFERENCES Recipes(id)
);

-- Create Favourites table
CREATE TABLE Favourites (
    id INT PRIMARY KEY IDENTITY(1,1),
    id_user INT,
    id_recipe INT,
    FOREIGN KEY (id_user) REFERENCES Users(id),
    FOREIGN KEY (id_recipe) REFERENCES Recipes(id)
);


-- Seed Data

-- Insert sample data into Users table
INSERT INTO Users (name, email, password, username, is_admin, is_blocked)
VALUES
('John Doe', 'john@example.com', 'password123', 'johndoe', 0, 0),
('Jane Smith', 'jane@example.com', 'password456', 'janesmith', 0, 0),
('Admin User', 'admin@example.com', 'adminpassword', 'adminuser', 1, 0);

-- Insert sample data into Ratings table
INSERT INTO Ratings (name) VALUES ('Good'), ('Average'), ('Bad');

-- Insert sample data into Ingredients table
INSERT INTO Ingredients (name) VALUES ('Flour'), ('Sugar'), ('Eggs');

-- Insert sample data into Measures table
INSERT INTO Measures (name) VALUES ('Cups'), ('Teaspoons'), ('Ounces');

-- Insert sample data into Categories table
INSERT INTO Categories (name) VALUES ('Breakfast'), ('Lunch'), ('Dinner');

-- Insert sample data into Difficulties table
INSERT INTO Difficulties (name) VALUES ('Easy'), ('Medium'), ('Hard');

-- Insert sample data into Recipes table
INSERT INTO Recipes (title, preparation_method, id_category, id_difficulty, preparation_time, is_approved, id_user)
VALUES
('Pancakes', 'Mix flour, sugar, and eggs. Cook on a pan.', 1, 1, GETDATE(), 1, 1),
('Grilled Cheese Sandwich', 'Spread butter on bread. Add cheese. Grill.', 2, 2, GETDATE(), 1, 2);

-- Insert sample data into Recipe_Ingredients table
INSERT INTO Recipe_Ingredients (quantity, id_recipe, id_ingredient, id_measure)
VALUES
(2, 1, 1, 1), -- 2 Cups of Flour for Pancakes
(1, 1, 2, 1), -- 1 Cup of Sugar for Pancakes
(3, 1, 3, 1), -- 3 Eggs for Pancakes
(2, 2, 1, 1), -- 2 Cups of Flour for Grilled Cheese Sandwich
(1, 2, 2, 1); -- 1 Cup of Sugar for Grilled Cheese Sandwich

-- Insert sample data into Reviews table
INSERT INTO Reviews (comment, id_user, id_rating, id_recipe)
VALUES
('Delicious!', 1, 1, 1),
('Easy to make.', 2, 2, 2);

-- Insert sample data into Favourites table
INSERT INTO Favourites (id_user, id_recipe) VALUES (1, 1), (2, 2);
