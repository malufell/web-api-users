CREATE TABLE IF NOT EXISTS `users` (`id` INT PRIMARY KEY AUTO_INCREMENT,
  `name` NVARCHAR(255) NOT NULL,
  `federal_tax_id` NVARCHAR(14) NOT NULL UNIQUE,
  `age` INT NOT NULL,
  `gender` NVARCHAR(10) NOT NULL,
  `place_of_birth` NVARCHAR(255) NOT NULL
);
