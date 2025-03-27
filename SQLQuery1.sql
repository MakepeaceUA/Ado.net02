CREATE TABLE VegFruTable 
(
    ID INT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Type VARCHAR(10) NOT NULL,
    Calories INT NOT NULL
);

INSERT INTO VegFruTable(ID,Name, Type, Calories) VALUES
(1,'Яблоко', 'Fruit', 52),
(2,'Банан', 'Fruit', 89),
(3,'Огурец', 'Vegetable', 16),
(4,'Помидор', 'Vegetable', 18)