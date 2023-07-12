CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';


CREATE TABLE recipes(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  title VARCHAR(500) COMMENT 'Recipe Title',
  instructions VARCHAR(500) COMMENT 'Instructions',
  img VARCHAR(500) COMMENT 'Image',
  category VARCHAR(500) COMMENT 'Category',
  archived BOOLEAN NOT NULL DEFAULT false,
  creatorId VARCHAR(255) COMMENT 'Creator Id',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

SELECT * FROM recipes;

INSERT INTO recipes
(title, instructions, img, category, archived, creatorId)
VALUES
("Cheese Fondue", "Heat cheese up.", "placeholderimg", "Dinner", false, "649caf64efdb2de0a2c28353");


CREATE TABLE ingredients(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(500) COMMENT 'Ingredient Name',
  quantity VARCHAR(500) COMMENT 'Ingredient Quantity',
  recipeId INT COMMENT 'Recipe id',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) default charset utf8 COMMENT '';

SELECT * FROM ingredients;
INSERT INTO ingredients
(name, quantity)
VALUES
("Mazda Miata", "1 Cup");

CREATE TABLE favorites(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  accountId VARCHAR(500) COMMENT 'Account Id',
  recipeId INT COMMENT 'Recipe Id',
  FOREIGN KEY (accountId) REFERENCES accounts(id) ON DELETE CASCADE,
  FOREIGN KEY (recipeId) REFERENCES recipes(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

INSERT INTO favorites
(accountId, recipeId)
VALUES("649caf64efdb2de0a2c28353", LAST_INSERT_ID());
SELECT account FROM favorites favs JOIN accounts account on account.id = fav.accountId WHERE fav.recipeId = 1;

SELECT * FROM favorites;

-- SELECT rcp.*,
--       creator.*
--       FROM recipes rcp
--       JOIN accounts creator ON rcp.creatorId = creator.id

SELECT * INTO tempRecipes FROM recipes

-- SELECT DISTINCT rcp.id, rcp.title,
-- creator.id, creator.name
-- FROM recipes rcp
-- JOIN accounts creator ON rcp.creatorId = creator.id